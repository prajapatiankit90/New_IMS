using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace demo
{
    class Projset

    {
       
        public void addrecord(string sql)
        {
            OleDbConnection conn = new OleDbConnection(Module.ConnString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();            
        }

        public DataTable FillDataTable(string SqlString)
        {

            OleDbConnection sqlconn = new OleDbConnection(Module.ConnString);
            OleDbDataAdapter da = new OleDbDataAdapter(SqlString, sqlconn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object GetValue(string SqlString)
        {
            object obj = new object();
            OleDbConnection Conn = new OleDbConnection(Module.ConnString);
            OleDbCommand Mycmd = new OleDbCommand(SqlString, Conn);
            Conn.Open();
           obj = Mycmd.ExecuteScalar();
            Conn.Close();
            Conn = null;
            Mycmd = null;
            return obj;
        }
        public void FillText(string SqlString, TextBox txt)
        {
            AutoCompleteStringCollection autostr = new AutoCompleteStringCollection();
            using (OleDbConnection Conn = new OleDbConnection(Module.ConnString))
            {
                OleDbCommand cmd = new OleDbCommand(SqlString, Conn);
                Conn.Open();
                OleDbDataReader Reader = null;
                Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    autostr.Add(Reader[0].ToString().Trim());
                }
                Conn.Close();
                txt.AutoCompleteCustomSource = autostr;
            }

        }
                
    }
}

