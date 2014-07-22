using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.SqlClient;
using System.Windows;
using WTUSA;

namespace WTUSA
{
    /// <summary>
    /// A singleton that keeps a single connection to the WTData database.
    /// Queries should be performed via dapper and its' IDbConnection.Query<...>() extension.
    /// </summary>
    public sealed class WTConnection : System.Data.IDbConnection
    {
        private static readonly WTConnection _instance = new WTConnection();
        private SqlConnection WTSQLConnection;
        //! private SqlCommand sc;
        private WTRegistry WTReg;

        public static WTConnection GetConnection() { return _instance; }
        public static SqlCommand GetCommand() { return _instance.WTSQLConnection.CreateCommand(); }

        private WTConnection()
        {
            WTReg = new WTRegistry();
            string connectionString = "";
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            try
            {
                connectionString = System.Text.Encoding.ASCII.GetString(WTReg.GetBytesFromRegistry());
                csb = new SqlConnectionStringBuilder(connectionString);
                csb.MultipleActiveResultSets = true;
                csb.AsynchronousProcessing = true;
                WTSQLConnection = new SqlConnection(csb.ConnectionString);
                
            }
            catch (Exception)
            {
                //! TODO: Handle this!!!
                //throw;
                var msgResult =
                    MessageBox.Show(
                        "No valid WinTool SQL Connection was found." + Environment.NewLine +
                        "Show configuration screen?", "Error!", MessageBoxButton.YesNo);
                if (msgResult == MessageBoxResult.Yes)
                {
                    frmSelectSQLServer frmSqlSelection = new frmSelectSQLServer();
                    while (WTSQLConnection == null)
                    {
                        frmSqlSelection.ShowDialog();
                        csb = new SqlConnectionStringBuilder();
                        csb.MultipleActiveResultSets = true;
                        csb.AsynchronousProcessing = true;
                        csb.DataSource = frmSqlSelection.cboxServers.SelectedItem.ToString();
                        csb.IntegratedSecurity = frmSqlSelection.radioWinLogin.Checked;
                        csb.InitialCatalog = "WTData";
                        WTSQLConnection = new SqlConnection(csb.ConnectionString);
                    }
                }
                else
                {
                    throw new System.TimeoutException("Could not connect to the database.");
                }
            }
            //nothing was in the registry, that's bad
            //Let's find from the user how to create connection
            WTSQLConnection.Open();
            (new WTRegistry()).WriteBytesToRegistry(csb);
        }

        #region "IDBConnection Support"

        IDbTransaction IDbConnection.BeginTransaction(IsolationLevel il)
        {
            return WTConnection._instance.WTSQLConnection.BeginTransaction(il);
        }

        IDbTransaction IDbConnection.BeginTransaction()
        {
            return WTConnection._instance.WTSQLConnection.BeginTransaction();
        }

        void IDbConnection.ChangeDatabase(string databaseName)
        {
            WTConnection._instance.WTSQLConnection.ChangeDatabase(databaseName);
        }

         void IDbConnection.Close()
        {
            WTConnection._instance.WTSQLConnection.Close();
        }

         string IDbConnection.ConnectionString
        {
            get
            {
                return WTConnection._instance.WTSQLConnection.ConnectionString;
            }
            set
            {
                WTConnection._instance.WTSQLConnection.ConnectionString = value;
            }
        }

         int IDbConnection.ConnectionTimeout
        {
            get { return WTConnection._instance.WTSQLConnection.ConnectionTimeout; }
        }

         IDbCommand IDbConnection.CreateCommand()
        {
            return WTConnection._instance.WTSQLConnection.CreateCommand();
        }

         string IDbConnection.Database
        {
            get { return WTConnection._instance.WTSQLConnection.Database; }
        }

         void IDbConnection.Open()
        {
            WTConnection._instance.WTSQLConnection.Open();
        }

         ConnectionState IDbConnection.State
        {
            get { return WTConnection._instance.WTSQLConnection.State; }
        }

        void IDisposable.Dispose()
        {
            WTConnection._instance.WTSQLConnection.Dispose();
        }

        #endregion

    }

}