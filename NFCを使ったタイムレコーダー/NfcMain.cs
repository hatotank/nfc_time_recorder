using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace nfc_time_recorder
{
    enum State
    {
        ready,
        running,
        wait,
    }
    /// <summary>
    /// PC/SCメイン(http://tomosoft.jp/design/?p=5543)
    /// 変更点
    /// ・ReadResultクラス使わないけど無かったので追加
    /// ・Command2を作成(汎用)
    /// ・ポーリングをスレッドにて行うように変更
    /// ・使わないメソッドをコメント
    /// </summary>
    public class NfcMain
    {
        public bool IsReaderRemoved { get; private set; }
        public bool IsCurrentCard { get; private set; }
        public bool IsNfcFaild { get; private set; }
        public NfcApi.SCARD_READERSTATE[] readerStateArray;

        static State sThreadState;
        private Thread pollingThread = null;
        private IntPtr context;
        private List<string> readersList = null;

        //リーダー取得
        public bool Reader()
        {
            bool rtn = true;
            IsReaderRemoved = false;
            IsNfcFaild = false;

            //リソースマネージャ接続
            context = establishContext();
            if (context == IntPtr.Zero)
            {
                IsReaderRemoved = true;
                return false;
            }

            //カードリーダー取得
            //List<string> 
            readersList = getReaders(context);
            if (readersList.Count == 0)
            {
                IsReaderRemoved = true;
                return false;
            }

            /*
            readerStateArray = initializeReaderState(context, readersList);
            IsReaderRemoved = true;
            */
            return rtn;
        }

        //接続終了
        public bool DisConnectReader()
        {
            uint ret = NfcApi.SCardReleaseContext(context);
            return true;
        }

        /* del
        public void start()
        {
            IntPtr context = establishContext();

            List<string> readersList = getReaders(context);

            NfcApi.SCARD_READERSTATE[] readerStateArray = initializeReaderState(context, readersList);

            bool quit = false;
            while (!quit)
            {
                waitReaderStatusChange(context, readerStateArray, 1000);
                if ((readerStateArray[0].dwEventState & NfcConstant.SCARD_STATE_PRESENT) == NfcConstant.SCARD_STATE_PRESENT)
                {
                    ReadResult result2 = readCard(context, readerStateArray[0].szReader);
                    SendCommand(context, readerStateArray[0].szReader);
                    quit = true;
                }
            }
            uint ret = NfcApi.SCardReleaseContext(context);
        }
        */

        // add
        public byte[] SendCommand2(byte[] command)
        {
            IntPtr hCard = connect(context, readerStateArray[0].szReader);
            byte[] recvBuffer = new byte[262];

            int recvLength = transmit(hCard, command, recvBuffer);

            disconnect(hCard);

            byte[] statsu = new[] {recvBuffer[recvLength - 2],
                                   recvBuffer[recvLength - 1]
            };

            if (recvLength > 0)
            {
                byte[] tmpBuffer = new byte[recvLength - 2];
                Array.Copy(recvBuffer, tmpBuffer, recvLength - 2);
                return tmpBuffer;
            }
            else
            {
                return new byte[0];
            }
        }

        //ポーリングスタート
        public void StartPolling()
        {
            if (sThreadState == State.ready)
            {
                pollingThread = new Thread(new ThreadStart(this.Polling));
                pollingThread.Start();
                sThreadState = State.running;
                Debug.WriteLine("INFO:StartPolling");
            }
        }

        //ポーリングストップ
        public void stopPolling()
        {
            if (sThreadState != State.ready)
            {
                pollingThread.Abort();
                sThreadState = State.ready;
                Debug.WriteLine("INFO:StopPolling");
            }
        }

        //ポーリング
        private void Polling()
        {
            try
            {
                //初回ステータス取得
                while (true)
                {
                    readerStateArray = initializeReaderState(context, readersList);

                    if (readerStateArray.Length > 0)
                    {
                        Debug.WriteLine("INFO:GetStatus1");
                        break;
                    }
                }

                //２回目以降の状態変化を取得
                while (true)
                {
                    waitReaderStatusChange(context, readerStateArray, 300);
                    //カードが載っている場合
                    if ((readerStateArray[0].dwEventState & NfcConstant.SCARD_STATE_PRESENT) != 0)
                    {
                        if (IsCurrentCard == false)
                        {
                            Debug.WriteLine("INFO:SCARD_STATE_PRESENT");
                        }
                        IsCurrentCard = true;
                    }
                    //カードが取り外された場合
                    else if ((readerStateArray[0].dwEventState & NfcConstant.SCARD_STATE_EMPTY) != 0)
                    {
                        if (IsCurrentCard == true)
                        {
                            Debug.WriteLine("INFO:SCARD_STATE_EMPTY");
                        }
                        IsCurrentCard = false;
                    }
                    //リーダーが取り外された場合
                    else if ((readerStateArray[0].dwEventState & NfcConstant.SCARD_STATE_UNAVAILABLE) != 0)
                    {
                        Debug.WriteLine("INFO:SCARD_STATE_UNAVAILABLE");
                        IsCurrentCard = false;
                    }
                }
            }
            catch (ApplicationException e)
            {
                Debug.WriteLine("INFO:ApplicationException");
                //MessageBox.Show(e.Message);
                IsReaderRemoved = true;
                stopPolling();
                IsNfcFaild = true;
            }
        }

        //----------------------------------
        //リソースマネージャ接続
        private IntPtr establishContext()
        {
            IntPtr context = IntPtr.Zero;

            uint ret = NfcApi.SCardEstablishContext(NfcConstant.SCARD_SCOPE_USER, IntPtr.Zero, IntPtr.Zero, out context);
            //Return Valueについてはこちら
            //https://technet.microsoft.com/ja-jp/library/aa374738.aspx#smart_card_return_values
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                string message;
                switch (ret)
                {
                    case NfcConstant.SCARD_E_NO_SERVICE:
                        message = "サービスが起動されていません。" + ret;
                        break;
                    default:
                        message = "Smart Cardサービスに接続できません。code = " + ret;
                        break;
                }
                Debug.WriteLine(message);
                return IntPtr.Zero;
            }
            Debug.WriteLine("Smart Cardサービスに接続しました。");
            return context;
        }

        //カードリーダーの名前取得(1台のみ)
        List<string> getReaders(IntPtr hContext)
        {
            uint pcchReaders = 0;

            //一覧取得に必要とされるバッファサイズを取得
            uint ret = NfcApi.SCardListReaders(hContext, null, null, ref pcchReaders);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                return new List<string>();//リーダーの情報が取得できません。
            }

            //バッファを確保
            byte[] mszReaders = new byte[pcchReaders * 2]; // 1文字2byte

            //一覧を取得する
            ret = NfcApi.SCardListReaders(hContext, null, mszReaders, ref pcchReaders);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                return new List<string>();//リーダーの情報が取得できません。
            }

            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            string readerNameMultiString = unicodeEncoding.GetString(mszReaders);

            Debug.WriteLine("リーダー名を\\0で接続した文字列: " + readerNameMultiString);
            Debug.WriteLine(" ");

            List<string> readersList = new List<string>();
            int nullindex = readerNameMultiString.IndexOf((char)0);   // 装置は１台のみ
            readersList.Add(readerNameMultiString.Substring(0, nullindex));
            //readersList.Add(readerNameMultiString.Split(nullindex,StringSplitOptions.RemoveEmptyEntries); //保留
            return readersList;
        }

        NfcApi.SCARD_READERSTATE[] initializeReaderState(IntPtr hContext, List<string> readerNameList)
        {
            //NfcApi.SCARD_READERSTATE[] 
            readerStateArray = new NfcApi.SCARD_READERSTATE[readerNameList.Count];
            int i = 0;
            foreach (string readerName in readerNameList)
            {
                readerStateArray[i].dwCurrentState = NfcConstant.SCARD_STATE_UNAWARE;
                readerStateArray[i].szReader = readerName;
                i++;
            }
            uint ret = NfcApi.SCardGetStatusChange(hContext, 0/*msec*/, readerStateArray, readerStateArray.Length);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                throw new ApplicationException("リーダーの初期状態の取得に失敗。code = " + ret);
            }

            return readerStateArray;
        }

        void waitReaderStatusChange(IntPtr hContext, NfcApi.SCARD_READERSTATE[] readerStateArray, int timeoutMillis)
        {
            uint ret = NfcApi.SCardGetStatusChange(hContext, timeoutMillis/*msec*/, readerStateArray, readerStateArray.Length);
            switch (ret)
            {
                case NfcConstant.SCARD_S_SUCCESS:
                    break;
                case NfcConstant.SCARD_E_TIMEOUT:
                    throw new TimeoutException();
                default:
                    throw new ApplicationException("リーダーの状態変化の取得に失敗。code = " + ret);
            }
        }

        /* del
        ReadResult readCard(IntPtr context, string readerName)
        {
            IntPtr hCard = connect(context, readerName);
            string readerSerialNumber = readReaderSerialNumber(hCard);
            string cardId = readCardId(hCard);
            //            Debug.WriteLine(readerName + " (S/N " + readerSerialNumber + ") から、カードを読み取りました。" + cardId);
            Console.WriteLine(readerName + " (S/N " + readerSerialNumber + ") から、カードを読み取りました。");
            Console.WriteLine("CardID:" + cardId);

            disconnect(hCard);

            ReadResult result = new ReadResult();
            result.readerSerialNumber = readerSerialNumber;
            result.cardId = cardId;
            return result;
        }

        string readReaderSerialNumber(IntPtr hCard)
        {
            int controlCode = 0x003136b0; // SCARD_CTL_CODE(3500) の値 
            // IOCTL_PCSC_CCID_ESCAPE
            // SONY SDK for NFC M579_PC_SC_2.1j.pdf 3.1.1 IOCTRL_PCSC_CCID_ESCAPE
            byte[] sendBuffer = new byte[] { 0xc0, 0x08 }; // ESC_CMD_GET_INFO / Product Serial Number 
            byte[] recvBuffer = new byte[64];
            int recvLength = control(hCard, controlCode, sendBuffer, recvBuffer);

            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            string serialNumber = asciiEncoding.GetString(recvBuffer, 0, recvLength - 1); // recvBufferには\0で終わる文字列が取得されるので、長さを-1する。
            return serialNumber;
        }

        string readCardId(IntPtr hCard)
        {
            byte maxRecvDataLen = 64;
            byte[] recvBuffer = new byte[maxRecvDataLen + 2];
            byte[] sendBuffer = new byte[] { 0xff, 0xca, 0x00, 0x00, maxRecvDataLen };
            int recvLength = transmit(hCard, sendBuffer, recvBuffer);

            string cardId = BitConverter.ToString(recvBuffer, 0, recvLength - 2).Replace("-", "");
            return cardId;
        }

        void SendCommand(IntPtr hContext, string readerName)
        {
            int dwResponseSize;
            byte[] response = new byte[2048];
            long lResult;

            byte[] commnadSelectFile = { 0xff, 0xA4, 0x00, 0x01, 0x02, 0x0f, 0x09 };
            byte[] commnadReadBinary = { 0xff, 0xb0, 0x00, 0x00, 0x00 };

            IntPtr SCARD_PCI_T1 = getPciT1();
            NfcApi.SCARD_IO_REQUEST ioRecv = new NfcApi.SCARD_IO_REQUEST();
            ioRecv.cbPciLength = 2048;
            IntPtr hCard = connect(hContext, readerName);

            dwResponseSize = response.Length;
            lResult = NfcApi.SCardTransmit(hCard, SCARD_PCI_T1, commnadSelectFile, commnadSelectFile.Length, ioRecv, response, ref dwResponseSize);
            if (lResult != NfcConstant.SCARD_S_SUCCESS)
            {
                Debug.WriteLine("SelectFile error\n");
                return;
            }
            dwResponseSize = response.Length;
            lResult = NfcApi.SCardTransmit(hCard, SCARD_PCI_T1, commnadReadBinary, commnadReadBinary.Length, ioRecv, response, ref dwResponseSize);
            if (lResult != NfcConstant.SCARD_S_SUCCESS)
            {
                Debug.WriteLine("ReadBinary error\n");
                return;
            }
            parse_tag(response);
        }

        private void parse_tag(byte[] data)
        {
            //int loop = 0;
            //            Debug.WriteLine("\nSuica履歴データ：" + BitConverter.ToString(data,0,20) + "\n");
            Console.WriteLine("\nSuica履歴データ：" + BitConverter.ToString(data, 0, 20) + "\n");
        }
        */

        private IntPtr getPciT1()
        {
            IntPtr handle = NfcApi.LoadLibrary("Winscard.dll");
            IntPtr pci = NfcApi.GetProcAddress(handle, "g_rgSCardT1Pci");
            NfcApi.FreeLibrary(handle);
            return pci;
        }

        IntPtr connect(IntPtr hContext, string readerName)
        {
            IntPtr hCard = IntPtr.Zero;
            IntPtr activeProtocol = IntPtr.Zero;
            uint ret = NfcApi.SCardConnect(hContext, readerName, NfcConstant.SCARD_SHARE_SHARED, NfcConstant.SCARD_PROTOCOL_T1, ref hCard, ref activeProtocol);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                throw new ApplicationException("カードに接続できません。code = " + ret);
            }
            return hCard;
        }

        void disconnect(IntPtr hCard)
        {
            uint ret = NfcApi.SCardDisconnect(hCard, NfcConstant.SCARD_LEAVE_CARD);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                throw new ApplicationException("カードとの接続を切断できません。code = " + ret);
            }
        }

        int control(IntPtr hCard, int controlCode, byte[] sendBuffer, byte[] recvBuffer)
        {
            int bytesReturned = 0;
            uint ret = NfcApi.SCardControl(hCard, controlCode, sendBuffer, sendBuffer.Length, recvBuffer, recvBuffer.Length, ref bytesReturned);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                throw new ApplicationException("カードへの制御命令送信に失敗しました。code = " + ret);
            }
            return bytesReturned;
        }

        int transmit(IntPtr hCard, byte[] sendBuffer, byte[] recvBuffer)
        {
            NfcApi.SCARD_IO_REQUEST ioRecv = new NfcApi.SCARD_IO_REQUEST();
            ioRecv.cbPciLength = 255;

            int pcbRecvLength = recvBuffer.Length;
            int cbSendLength = sendBuffer.Length;
            IntPtr SCARD_PCI_T1 = getPciT1();
            uint ret = NfcApi.SCardTransmit(hCard, SCARD_PCI_T1, sendBuffer, cbSendLength, ioRecv, recvBuffer, ref pcbRecvLength);
            if (ret != NfcConstant.SCARD_S_SUCCESS)
            {
                throw new ApplicationException("カードへの送信に失敗しました。code = " + ret);
            }
            return pcbRecvLength; // 受信したバイト数(recvBufferに受け取ったバイト数)
        }
    }

    /* del
    class ReadResult
    {
        public string readerSerialNumber;
        public string cardId;
    }
    */
}
