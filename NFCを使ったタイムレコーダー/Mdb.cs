using System;
using System.Data;
using System.Data.OleDb;

namespace nfc_time_recorder
{
    /// <summary>
    /// Mdb簡易ラッパー
    /// </summary>
    public class Mdb
    {
        public const int MDB_VER_JET = 0;
        public const int MDB_VER_ACE = 1;

        private OleDbConnection conn;
        private OleDbCommand comm;
        private OleDbDataReader reader;

        // コンストラクタ
        public Mdb(String source, int mdbVer)
        {
            conn = new OleDbConnection();
            comm = new OleDbCommand();

            // MDBのバージョンによりデータソースを変更
            switch (mdbVer)
            {
                case MDB_VER_JET:
                    conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + source;
                    break;
                case MDB_VER_ACE:
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + source;
                    break;
                default:
                    break;
            }
        }

        // デストラクタ
        ~Mdb()
        {
            // 接続解除
            if (conn.State == ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public bool DbOpen()
        {
            try{
                conn.Open();
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        public bool DbClose()
        {
            // 接続解除
            if (conn.State == ConnectionState.Closed)
            {
                conn.Close();
            }
            return true;
        }

        // クエリ発行
        public OleDbDataReader executeQuery(String SQL)
        {
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }
            comm.CommandText = SQL;
            comm.Connection = conn;
            reader = comm.ExecuteReader();
            return reader;
        }

        // クエリ発行(UPDATE,DELETE,INSERT)
        public int executeNonQuery(String SQL)
        {
            int result;
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }
            comm.CommandText = SQL;
            comm.Connection = conn;
            result = comm.ExecuteNonQuery();
            return result;
        }
    }
}
