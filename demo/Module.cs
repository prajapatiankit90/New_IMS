using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public static class Module
    {
        // public static String ConnString = "Data Source=grading11;Initial Catalog = test; Integrated Security = True";
         public static int CompanyId;
         public static string ServerName;
         public static string Database;
         public static string UserId;
         public static string Password;
        public static string ConnString = string.Empty;
        public static int FindId = 0;

        public static void ReadFile ()
        {
            string FileName = "Connection.ini";
            if(System.IO.File.Exists(FileName)== true)
            {
                System.IO.StreamReader Reader = new System.IO.StreamReader(FileName);
                do
                {
                    ServerName = Reader.ReadLine();
                    Database = Reader.ReadLine();
                    UserId = Reader.ReadLine();
                    Password = Reader.ReadLine();
                } while (Reader.Peek() != -1);
                Reader.Close();

                System.Data.OleDb.OleDbConnectionStringBuilder objConnBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
                objConnBuilder.Provider = ServerName;
                objConnBuilder.DataSource = Database;

                ConnString = objConnBuilder.ConnectionString + ";Jet OLEDB:Database Password = " + Password + "; ";
            }
            else
            {
                System.IO.File.Create(FileName).Close();
                System.Windows.Forms.MessageBox.Show("Connection File not Found","Connection Error",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            }
            }
        }

    }

