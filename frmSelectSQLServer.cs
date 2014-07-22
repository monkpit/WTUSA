using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTUSA
{
    public partial class frmSelectSQLServer : Form
    {

        public frmSelectSQLServer()
        {
            InitializeComponent();
            //FormClosing += frmSelectSQLServer_FormClosing;
            Load += frmSelectSQLServer_Load;
        }


        private void frmSelectSQLServer_Load(System.Object sender, System.EventArgs e)
        {
            cboxServers.Visible = false;
            btnTestConnection.Enabled = false;
            WriteStatus(@"Click ""Get SQL Servers"" to fetch a list of servers from the network." + Environment.NewLine 
                      + @"Click ""Add server manually"" to manually add a hostname & instance to the list." + Environment.NewLine);
            //If WTConnection_CommandFactory.isOpen() Then
            //    WriteStatus(vbCrLf & "Connection information found." & vbCrLf & _
            //                "Click Test Connection to test the connection to:" & vbCrLf & _
            //                WTConnection_CommandFactory.Connection.DataSource.ToString & vbCrLf)
            //    btnTestConnection.Enabled = True
            //End If
        }

        private void btnGetRefresh_Click(System.Object sender, System.EventArgs e)
        {
            btnGetRefresh.Enabled = false;
            btnGetRefresh.Text = "Working...";
            WriteStatus("Fetching SQL Servers from network...");
            System.Threading.Thread.Sleep(200);
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            foreach (DataRow row in instance.GetDataSources().Rows)
            {
                cboxServers.Items.Add(row[0].ToString() + "\\" + row[1].ToString());
                WriteStatus(row[0].ToString() + "\\" + row[1].ToString());
            }
            if (cboxServers.Items.Count > 0)
            {
                WriteStatus(Environment.NewLine + "Found SQL Servers on the network." + Environment.NewLine + "Please select a server from the dropdown menu." + Environment.NewLine + "Click Refresh SQL Servers to fetch the list from the network again.");
                btnGetRefresh.Text = "Refresh SQL Servers";
                btnGetRefresh.Enabled = true;
                cboxServers.Visible = true;
            }

        }

        
        private void btnTestConnection_Click(System.Object sender, System.EventArgs e)
        {
            //close form and check connection back in WTConnection
            this.Close();
        }

        private void WriteStatus(string str)
        {
            txtStatus.AppendText(str + Environment.NewLine);
        }

        

        
        //private void RunConnectionTests()
        //{
        //    dynamic cString = new System.Data.SqlClient.SqlConnectionStringBuilder();
        //    cString.DataSource = cboxServers.SelectedItem.ToString();
        //    cString.IntegratedSecurity = true;
        //    cString.InitialCatalog = "WTData";
        //    cString.AsynchronousProcessing = true;
        //    var wtreg = new WTRegistry();
        //    wtreg.WriteBytesToRegistry(cString);
        //    if (radioSQLLogin.Checked)
        //    {
        //        ///get the sql credentials

        //    }
        //    else
        //    {
        //    }
        //    //WriteStatus(Environment.NewLine + "========================" + Environment.NewLine + "Testing current configuration...");
        //    //WTConnection.SetConnection(cString);
            

        //}


        

        //private void frmSelectSQLServer_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        //{
        //    //if ( IsConnectionActive == true)
        //    //{
        //    //    MessageBox.Show(this, "Cannot close the form until " + "the pending asynchronous command has completed. Please wait...");
        //    //    e.Cancel = true;
        //    //}

        //}

        private void radioSQLLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxServers.SelectedItem != null)
            {
                btnTestConnection.Enabled = true;
            }
        }

        private void radioWinLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxServers.SelectedItem != null)
            {
                btnTestConnection.Enabled = true;
            }
        }

        private void cboxServers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((radioSQLLogin.Checked == true) || (radioWinLogin.Checked == true))
            {
                btnTestConnection.Enabled = true;
            }
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            frmServerInputDialog input = new frmServerInputDialog();
            input.ShowDialog(this);

            if (!string.IsNullOrEmpty(input.txtResponse.Text))
            {
                cboxServers.Visible = true;
                cboxServers.Items.Add(input.txtResponse.Text);
                cboxServers.SelectedItem = input.txtResponse.Text;
            }
        }
    }
}
