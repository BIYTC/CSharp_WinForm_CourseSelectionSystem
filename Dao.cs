using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace demo
{
    class Dao
    {
        public OleDbConnection oleDb;
        public bool Connect()
        {
            try
            {
                oleDb = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\desktop\Student.mdb");
                oleDb.Open();
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }

            return true;
        }
        public bool AppendData(string sql)
        {
            try
            {
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDb);
                if (oleDbCommand.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
        public OleDbDataReader ReadData(string sql)
        {
            try
            {
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDb);
                return oleDbCommand.ExecuteReader();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
