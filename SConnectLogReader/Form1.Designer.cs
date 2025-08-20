namespace SConnectLogReader
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if (disposing && (components != null)) {
        components.Dispose( );
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent( )
    {
      this.btScan = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txNumEntries = new System.Windows.Forms.TextBox();
      this.btSchowOpen = new System.Windows.Forms.Button();
      this.tlp = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pBar = new System.Windows.Forms.ProgressBar();
      this.btCancel = new System.Windows.Forms.Button();
      this.btFocDump = new System.Windows.Forms.Button();
      this.txFocusClient = new System.Windows.Forms.TextBox();
      this.txTimeUsed = new System.Windows.Forms.TextBox();
      this.btSelNone = new System.Windows.Forms.Button();
      this.btSelAll = new System.Windows.Forms.Button();
      this.btWriteJSON = new System.Windows.Forms.Button();
      this.txNumExc = new System.Windows.Forms.TextBox();
      this.txNumOpen = new System.Windows.Forms.TextBox();
      this.clbIgnore = new System.Windows.Forms.CheckedListBox();
      this.btShowExc = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.tabC = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.RTB = new System.Windows.Forms.RichTextBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.clbClients = new System.Windows.Forms.CheckedListBox();
      this.OFD = new System.Windows.Forms.OpenFileDialog();
      this.BGW_Main = new System.ComponentModel.BackgroundWorker();
      this.SFD = new System.Windows.Forms.SaveFileDialog();
      this.BGW_RTB = new System.ComponentModel.BackgroundWorker();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tlp.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabC.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btScan
      // 
      this.btScan.Location = new System.Drawing.Point(6, 190);
      this.btScan.Name = "btScan";
      this.btScan.Size = new System.Drawing.Size(80, 40);
      this.btScan.TabIndex = 0;
      this.btScan.Text = "Scan";
      this.btScan.UseVisualStyleBackColor = true;
      this.btScan.Click += new System.EventHandler(this.btScan_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(92, 190);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Num Entries:";
      // 
      // txNumEntries
      // 
      this.txNumEntries.Location = new System.Drawing.Point(95, 206);
      this.txNumEntries.Name = "txNumEntries";
      this.txNumEntries.ReadOnly = true;
      this.txNumEntries.Size = new System.Drawing.Size(91, 22);
      this.txNumEntries.TabIndex = 2;
      this.txNumEntries.TabStop = false;
      // 
      // btSchowOpen
      // 
      this.btSchowOpen.Location = new System.Drawing.Point(6, 287);
      this.btSchowOpen.Name = "btSchowOpen";
      this.btSchowOpen.Size = new System.Drawing.Size(80, 22);
      this.btSchowOpen.TabIndex = 3;
      this.btSchowOpen.Text = "Entry/Exit";
      this.btSchowOpen.UseVisualStyleBackColor = true;
      this.btSchowOpen.Click += new System.EventHandler(this.btSchowOpen_Click);
      // 
      // tlp
      // 
      this.tlp.ColumnCount = 2;
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlp.Controls.Add(this.panel1, 0, 0);
      this.tlp.Controls.Add(this.tabC, 1, 0);
      this.tlp.Location = new System.Drawing.Point(12, 12);
      this.tlp.Name = "tlp";
      this.tlp.RowCount = 1;
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlp.Size = new System.Drawing.Size(481, 532);
      this.tlp.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.pBar);
      this.panel1.Controls.Add(this.txTimeUsed);
      this.panel1.Controls.Add(this.btSelNone);
      this.panel1.Controls.Add(this.btSelAll);
      this.panel1.Controls.Add(this.txNumExc);
      this.panel1.Controls.Add(this.txNumOpen);
      this.panel1.Controls.Add(this.clbIgnore);
      this.panel1.Controls.Add(this.btShowExc);
      this.panel1.Controls.Add(this.btSchowOpen);
      this.panel1.Controls.Add(this.txNumEntries);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btScan);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(194, 526);
      this.panel1.TabIndex = 0;
      // 
      // pBar
      // 
      this.pBar.Location = new System.Drawing.Point(6, 234);
      this.pBar.MarqueeAnimationSpeed = 500;
      this.pBar.Name = "pBar";
      this.pBar.Size = new System.Drawing.Size(180, 10);
      this.pBar.TabIndex = 15;
      this.pBar.Value = 50;
      // 
      // btCancel
      // 
      this.btCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btCancel.Location = new System.Drawing.Point(100, 49);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(80, 22);
      this.btCancel.TabIndex = 14;
      this.btCancel.Text = "CANCEL";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btFocDump
      // 
      this.btFocDump.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btFocDump.Location = new System.Drawing.Point(3, 49);
      this.btFocDump.Name = "btFocDump";
      this.btFocDump.Size = new System.Drawing.Size(80, 22);
      this.btFocDump.TabIndex = 13;
      this.btFocDump.Text = "Dump Log";
      this.btFocDump.UseVisualStyleBackColor = true;
      this.btFocDump.Click += new System.EventHandler(this.btFocDump_Click);
      // 
      // txFocusClient
      // 
      this.txFocusClient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txFocusClient.Location = new System.Drawing.Point(2, 21);
      this.txFocusClient.Name = "txFocusClient";
      this.txFocusClient.ReadOnly = true;
      this.txFocusClient.Size = new System.Drawing.Size(178, 22);
      this.txFocusClient.TabIndex = 12;
      this.txFocusClient.TabStop = false;
      // 
      // txTimeUsed
      // 
      this.txTimeUsed.Location = new System.Drawing.Point(3, 250);
      this.txTimeUsed.Name = "txTimeUsed";
      this.txTimeUsed.ReadOnly = true;
      this.txTimeUsed.Size = new System.Drawing.Size(180, 22);
      this.txTimeUsed.TabIndex = 11;
      this.txTimeUsed.TabStop = false;
      // 
      // btSelNone
      // 
      this.btSelNone.Location = new System.Drawing.Point(111, 161);
      this.btSelNone.Name = "btSelNone";
      this.btSelNone.Size = new System.Drawing.Size(80, 23);
      this.btSelNone.TabIndex = 10;
      this.btSelNone.Text = "Select NONE";
      this.btSelNone.UseVisualStyleBackColor = true;
      this.btSelNone.Click += new System.EventHandler(this.btSelNone_Click);
      // 
      // btSelAll
      // 
      this.btSelAll.Location = new System.Drawing.Point(1, 161);
      this.btSelAll.Name = "btSelAll";
      this.btSelAll.Size = new System.Drawing.Size(80, 23);
      this.btSelAll.TabIndex = 9;
      this.btSelAll.Text = "Select ALL";
      this.btSelAll.UseVisualStyleBackColor = true;
      this.btSelAll.Click += new System.EventHandler(this.btSelAll_Click);
      // 
      // btWriteJSON
      // 
      this.btWriteJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btWriteJSON.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btWriteJSON.Location = new System.Drawing.Point(2, 152);
      this.btWriteJSON.Name = "btWriteJSON";
      this.btWriteJSON.Size = new System.Drawing.Size(80, 22);
      this.btWriteJSON.TabIndex = 8;
      this.btWriteJSON.Text = "Write JSON";
      this.btWriteJSON.UseVisualStyleBackColor = true;
      this.btWriteJSON.Click += new System.EventHandler(this.btWriteJSON_Click);
      // 
      // txNumExc
      // 
      this.txNumExc.Location = new System.Drawing.Point(92, 315);
      this.txNumExc.Name = "txNumExc";
      this.txNumExc.ReadOnly = true;
      this.txNumExc.Size = new System.Drawing.Size(91, 22);
      this.txNumExc.TabIndex = 7;
      this.txNumExc.TabStop = false;
      // 
      // txNumOpen
      // 
      this.txNumOpen.Location = new System.Drawing.Point(92, 287);
      this.txNumOpen.Name = "txNumOpen";
      this.txNumOpen.ReadOnly = true;
      this.txNumOpen.Size = new System.Drawing.Size(91, 22);
      this.txNumOpen.TabIndex = 7;
      this.txNumOpen.TabStop = false;
      // 
      // clbIgnore
      // 
      this.clbIgnore.CheckOnClick = true;
      this.clbIgnore.FormattingEnabled = true;
      this.clbIgnore.Location = new System.Drawing.Point(1, 19);
      this.clbIgnore.Name = "clbIgnore";
      this.clbIgnore.Size = new System.Drawing.Size(190, 140);
      this.clbIgnore.TabIndex = 6;
      // 
      // btShowExc
      // 
      this.btShowExc.Location = new System.Drawing.Point(6, 315);
      this.btShowExc.Name = "btShowExc";
      this.btShowExc.Size = new System.Drawing.Size(80, 22);
      this.btShowExc.TabIndex = 5;
      this.btShowExc.Text = "Show EXC";
      this.btShowExc.UseVisualStyleBackColor = true;
      this.btShowExc.Click += new System.EventHandler(this.btShowExc_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(147, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Ignore the following types:";
      // 
      // tabC
      // 
      this.tabC.Controls.Add(this.tabPage1);
      this.tabC.Controls.Add(this.tabPage2);
      this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabC.Location = new System.Drawing.Point(203, 3);
      this.tabC.Name = "tabC";
      this.tabC.SelectedIndex = 0;
      this.tabC.Size = new System.Drawing.Size(275, 526);
      this.tabC.TabIndex = 1;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.RTB);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(267, 500);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "TEXT";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // RTB
      // 
      this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RTB.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RTB.Location = new System.Drawing.Point(3, 3);
      this.RTB.Name = "RTB";
      this.RTB.Size = new System.Drawing.Size(261, 494);
      this.RTB.TabIndex = 1;
      this.RTB.Text = "";
      this.RTB.WordWrap = false;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.clbClients);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(267, 500);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Clients";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // clbClients
      // 
      this.clbClients.CheckOnClick = true;
      this.clbClients.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clbClients.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.clbClients.FormattingEnabled = true;
      this.clbClients.Location = new System.Drawing.Point(3, 3);
      this.clbClients.Name = "clbClients";
      this.clbClients.Size = new System.Drawing.Size(261, 494);
      this.clbClients.Sorted = true;
      this.clbClients.TabIndex = 0;
      this.clbClients.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbClients_ItemCheck);
      // 
      // OFD
      // 
      this.OFD.DefaultExt = "log";
      this.OFD.FileName = "simconnect000.log";
      this.OFD.Filter = "LogFiles|*.log|All files|*.*";
      this.OFD.SupportMultiDottedExtensions = true;
      // 
      // BGW_Main
      // 
      this.BGW_Main.WorkerReportsProgress = true;
      this.BGW_Main.WorkerSupportsCancellation = true;
      this.BGW_Main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_Main_DoWork);
      this.BGW_Main.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_Main_ProgressChanged);
      this.BGW_Main.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_Main_RunWorkerCompleted);
      // 
      // SFD
      // 
      this.SFD.DefaultExt = "json";
      this.SFD.SupportMultiDottedExtensions = true;
      // 
      // BGW_RTB
      // 
      this.BGW_RTB.WorkerSupportsCancellation = true;
      this.BGW_RTB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_RTB_DoWork);
      this.BGW_RTB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RTB_RunWorkerCompleted);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox1.Controls.Add(this.txFocusClient);
      this.groupBox1.Controls.Add(this.btCancel);
      this.groupBox1.Controls.Add(this.btWriteJSON);
      this.groupBox1.Controls.Add(this.btFocDump);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(3, 343);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(188, 180);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Focused Client:";
      // 
      // Form1
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(539, 563);
      this.Controls.Add(this.tlp);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MinimumSize = new System.Drawing.Size(520, 600);
      this.Name = "Form1";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "SimConnect Logfile";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tlp.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tabC.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btScan;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txNumEntries;
    private System.Windows.Forms.Button btSchowOpen;
    private System.Windows.Forms.TableLayoutPanel tlp;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RichTextBox RTB;
    private System.Windows.Forms.OpenFileDialog OFD;
    private System.Windows.Forms.Button btShowExc;
    private System.Windows.Forms.CheckedListBox clbIgnore;
    private System.Windows.Forms.Label label2;
    private System.ComponentModel.BackgroundWorker BGW_Main;
    private System.Windows.Forms.TextBox txNumExc;
    private System.Windows.Forms.TextBox txNumOpen;
    private System.Windows.Forms.Button btWriteJSON;
    private System.Windows.Forms.SaveFileDialog SFD;
    private System.Windows.Forms.Button btSelAll;
    private System.Windows.Forms.Button btSelNone;
    private System.Windows.Forms.TabControl tabC;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.CheckedListBox clbClients;
    private System.Windows.Forms.TextBox txTimeUsed;
    private System.ComponentModel.BackgroundWorker BGW_RTB;
    private System.Windows.Forms.TextBox txFocusClient;
    private System.Windows.Forms.Button btFocDump;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.ProgressBar pBar;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}

