namespace WTUSA
{
    partial class frmSelectSQLServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectSQLServer));
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cboxServers = new System.Windows.Forms.ComboBox();
            this.btnGetRefresh = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.radioSQLLogin = new System.Windows.Forms.RadioButton();
            this.radioWinLogin = new System.Windows.Forms.RadioButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStatus.Location = new System.Drawing.Point(3, 23);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(290, 153);
            this.txtStatus.TabIndex = 9;
            // 
            // cboxServers
            // 
            this.cboxServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxServers.FormattingEnabled = true;
            this.cboxServers.Location = new System.Drawing.Point(3, 212);
            this.cboxServers.Name = "cboxServers";
            this.cboxServers.Size = new System.Drawing.Size(287, 21);
            this.cboxServers.TabIndex = 3;
            this.cboxServers.SelectedIndexChanged += new System.EventHandler(this.cboxServers_SelectedIndexChanged_1);
            // 
            // btnGetRefresh
            // 
            this.btnGetRefresh.Location = new System.Drawing.Point(3, 182);
            this.btnGetRefresh.Name = "btnGetRefresh";
            this.btnGetRefresh.Size = new System.Drawing.Size(290, 23);
            this.btnGetRefresh.TabIndex = 1;
            this.btnGetRefresh.Text = "Get SQL Servers";
            this.btnGetRefresh.UseVisualStyleBackColor = true;
            this.btnGetRefresh.Click += new System.EventHandler(this.btnGetRefresh_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddServer.Location = new System.Drawing.Point(3, 271);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(161, 23);
            this.btnAddServer.TabIndex = 5;
            this.btnAddServer.Text = "Add server manually";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(170, 271);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(123, 23);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // radioSQLLogin
            // 
            this.radioSQLLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioSQLLogin.AutoSize = true;
            this.radioSQLLogin.Location = new System.Drawing.Point(9, 3);
            this.radioSQLLogin.Name = "radioSQLLogin";
            this.radioSQLLogin.Size = new System.Drawing.Size(97, 17);
            this.radioSQLLogin.TabIndex = 7;
            this.radioSQLLogin.TabStop = true;
            this.radioSQLLogin.Text = "Use SQL Login";
            this.radioSQLLogin.UseVisualStyleBackColor = true;
            this.radioSQLLogin.CheckedChanged += new System.EventHandler(this.radioSQLLogin_CheckedChanged);
            // 
            // radioWinLogin
            // 
            this.radioWinLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioWinLogin.AutoSize = true;
            this.radioWinLogin.Location = new System.Drawing.Point(167, 3);
            this.radioWinLogin.Name = "radioWinLogin";
            this.radioWinLogin.Size = new System.Drawing.Size(120, 17);
            this.radioWinLogin.TabIndex = 6;
            this.radioWinLogin.TabStop = true;
            this.radioWinLogin.Text = "Use Windows Login";
            this.radioWinLogin.UseVisualStyleBackColor = true;
            this.radioWinLogin.CheckedChanged += new System.EventHandler(this.radioWinLogin_CheckedChanged);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.radioSQLLogin);
            this.Panel1.Controls.Add(this.radioWinLogin);
            this.Panel1.Location = new System.Drawing.Point(3, 239);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(290, 26);
            this.Panel1.TabIndex = 8;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Controls.Add(this.txtStatus);
            this.Panel2.Controls.Add(this.cboxServers);
            this.Panel2.Controls.Add(this.Panel1);
            this.Panel2.Controls.Add(this.btnGetRefresh);
            this.Panel2.Controls.Add(this.btnAddServer);
            this.Panel2.Controls.Add(this.btnTestConnection);
            this.Panel2.Location = new System.Drawing.Point(10, 9);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(296, 300);
            this.Panel2.TabIndex = 10;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Current Status:";
            // 
            // frmSelectSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 318);
            this.Controls.Add(this.Panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectSQLServer";
            this.Text = "Select WinTool SQL Server";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtStatus;
        internal System.Windows.Forms.ComboBox cboxServers;
        internal System.Windows.Forms.Button btnGetRefresh;
        internal System.Windows.Forms.Button btnAddServer;
        internal System.Windows.Forms.Button btnTestConnection;
        internal System.Windows.Forms.RadioButton radioSQLLogin;
        internal System.Windows.Forms.RadioButton radioWinLogin;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;

    }
}