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
      this.components = new System.ComponentModel.Container();
      this.btScan = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txNumEntries = new System.Windows.Forms.TextBox();
      this.btSchowOpen = new System.Windows.Forms.Button();
      this.tlp = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txFocusClient = new System.Windows.Forms.TextBox();
      this.btWriteJSON = new System.Windows.Forms.Button();
      this.btFocDump = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.pBar = new System.Windows.Forms.ProgressBar();
      this.btSelNone = new System.Windows.Forms.Button();
      this.btSelAll = new System.Windows.Forms.Button();
      this.txNumExc = new System.Windows.Forms.TextBox();
      this.txNumOpen = new System.Windows.Forms.TextBox();
      this.clbIgnore = new System.Windows.Forms.CheckedListBox();
      this.btShowExc = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.tabC = new System.Windows.Forms.TabControl();
      this.tP_Info = new System.Windows.Forms.TabPage();
      this.RTB_Info = new System.Windows.Forms.RichTextBox();
      this.tP_Clients = new System.Windows.Forms.TabPage();
      this.clbClients = new System.Windows.Forms.CheckedListBox();
      this.OFD = new System.Windows.Forms.OpenFileDialog();
      this.BGW_Main = new System.ComponentModel.BackgroundWorker();
      this.SFD = new System.Windows.Forms.SaveFileDialog();
      this.BGW_RTB = new System.ComponentModel.BackgroundWorker();
      this.tP_EntryExit = new System.Windows.Forms.TabPage();
      this.tP_Dump = new System.Windows.Forms.TabPage();
      this.RTB_EExit = new System.Windows.Forms.RichTextBox();
      this.RTB_Dump = new System.Windows.Forms.RichTextBox();
      this.tP_Exceptions = new System.Windows.Forms.TabPage();
      this.RTB_Exceptions = new System.Windows.Forms.RichTextBox();
      this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mSelAll = new System.Windows.Forms.ToolStripMenuItem();
      this.mCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.mCopyAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tlp.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabC.SuspendLayout();
      this.tP_Info.SuspendLayout();
      this.tP_Clients.SuspendLayout();
      this.tP_EntryExit.SuspendLayout();
      this.tP_Dump.SuspendLayout();
      this.tP_Exceptions.SuspendLayout();
      this.ctxMenu.SuspendLayout();
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
      this.panel1.Controls.Add(this.btCancel);
      this.panel1.Controls.Add(this.pBar);
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
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox1.Controls.Add(this.txFocusClient);
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
      // btCancel
      // 
      this.btCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btCancel.Location = new System.Drawing.Point(6, 250);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(177, 22);
      this.btCancel.TabIndex = 14;
      this.btCancel.Text = "CANCEL current action";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
      this.tabC.Controls.Add(this.tP_Info);
      this.tabC.Controls.Add(this.tP_Clients);
      this.tabC.Controls.Add(this.tP_EntryExit);
      this.tabC.Controls.Add(this.tP_Exceptions);
      this.tabC.Controls.Add(this.tP_Dump);
      this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabC.Location = new System.Drawing.Point(203, 3);
      this.tabC.Name = "tabC";
      this.tabC.SelectedIndex = 0;
      this.tabC.Size = new System.Drawing.Size(275, 526);
      this.tabC.TabIndex = 1;
      // 
      // tP_Info
      // 
      this.tP_Info.Controls.Add(this.RTB_Info);
      this.tP_Info.Location = new System.Drawing.Point(4, 22);
      this.tP_Info.Name = "tP_Info";
      this.tP_Info.Padding = new System.Windows.Forms.Padding(3);
      this.tP_Info.Size = new System.Drawing.Size(267, 500);
      this.tP_Info.TabIndex = 0;
      this.tP_Info.Text = "Info";
      this.tP_Info.UseVisualStyleBackColor = true;
      // 
      // RTB_Info
      // 
      this.RTB_Info.ContextMenuStrip = this.ctxMenu;
      this.RTB_Info.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RTB_Info.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RTB_Info.Location = new System.Drawing.Point(3, 3);
      this.RTB_Info.Name = "RTB_Info";
      this.RTB_Info.Size = new System.Drawing.Size(261, 494);
      this.RTB_Info.TabIndex = 1;
      this.RTB_Info.Text = "";
      this.RTB_Info.WordWrap = false;
      // 
      // tP_Clients
      // 
      this.tP_Clients.Controls.Add(this.clbClients);
      this.tP_Clients.Location = new System.Drawing.Point(4, 22);
      this.tP_Clients.Name = "tP_Clients";
      this.tP_Clients.Padding = new System.Windows.Forms.Padding(3);
      this.tP_Clients.Size = new System.Drawing.Size(267, 500);
      this.tP_Clients.TabIndex = 1;
      this.tP_Clients.Text = "Clients";
      this.tP_Clients.UseVisualStyleBackColor = true;
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
      // tP_EntryExit
      // 
      this.tP_EntryExit.Controls.Add(this.RTB_EExit);
      this.tP_EntryExit.Location = new System.Drawing.Point(4, 22);
      this.tP_EntryExit.Name = "tP_EntryExit";
      this.tP_EntryExit.Size = new System.Drawing.Size(267, 500);
      this.tP_EntryExit.TabIndex = 2;
      this.tP_EntryExit.Text = "Entry/Exits";
      this.tP_EntryExit.UseVisualStyleBackColor = true;
      // 
      // tP_Dump
      // 
      this.tP_Dump.Controls.Add(this.RTB_Dump);
      this.tP_Dump.Location = new System.Drawing.Point(4, 22);
      this.tP_Dump.Name = "tP_Dump";
      this.tP_Dump.Size = new System.Drawing.Size(267, 500);
      this.tP_Dump.TabIndex = 3;
      this.tP_Dump.Text = "Log Dump";
      this.tP_Dump.UseVisualStyleBackColor = true;
      // 
      // RTB_EExit
      // 
      this.RTB_EExit.ContextMenuStrip = this.ctxMenu;
      this.RTB_EExit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RTB_EExit.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RTB_EExit.Location = new System.Drawing.Point(0, 0);
      this.RTB_EExit.Name = "RTB_EExit";
      this.RTB_EExit.Size = new System.Drawing.Size(267, 500);
      this.RTB_EExit.TabIndex = 2;
      this.RTB_EExit.Text = "";
      this.RTB_EExit.WordWrap = false;
      // 
      // RTB_Dump
      // 
      this.RTB_Dump.ContextMenuStrip = this.ctxMenu;
      this.RTB_Dump.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RTB_Dump.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RTB_Dump.Location = new System.Drawing.Point(0, 0);
      this.RTB_Dump.Name = "RTB_Dump";
      this.RTB_Dump.Size = new System.Drawing.Size(267, 500);
      this.RTB_Dump.TabIndex = 2;
      this.RTB_Dump.Text = "";
      this.RTB_Dump.WordWrap = false;
      // 
      // tP_Exceptions
      // 
      this.tP_Exceptions.Controls.Add(this.RTB_Exceptions);
      this.tP_Exceptions.Location = new System.Drawing.Point(4, 22);
      this.tP_Exceptions.Name = "tP_Exceptions";
      this.tP_Exceptions.Size = new System.Drawing.Size(267, 500);
      this.tP_Exceptions.TabIndex = 4;
      this.tP_Exceptions.Text = "Exceptions";
      this.tP_Exceptions.UseVisualStyleBackColor = true;
      // 
      // RTB_Exceptions
      // 
      this.RTB_Exceptions.ContextMenuStrip = this.ctxMenu;
      this.RTB_Exceptions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RTB_Exceptions.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RTB_Exceptions.Location = new System.Drawing.Point(0, 0);
      this.RTB_Exceptions.Name = "RTB_Exceptions";
      this.RTB_Exceptions.Size = new System.Drawing.Size(267, 500);
      this.RTB_Exceptions.TabIndex = 2;
      this.RTB_Exceptions.Text = "";
      this.RTB_Exceptions.WordWrap = false;
      // 
      // ctxMenu
      // 
      this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSelAll,
            this.mCopy,
            this.mCopyAll});
      this.ctxMenu.Name = "ctxMenu";
      this.ctxMenu.Size = new System.Drawing.Size(150, 70);
      // 
      // mSelAll
      // 
      this.mSelAll.Name = "mSelAll";
      this.mSelAll.Size = new System.Drawing.Size(180, 22);
      this.mSelAll.Text = "Select All";
      this.mSelAll.Click += new System.EventHandler(this.mSelAll_Click);
      // 
      // mCopy
      // 
      this.mCopy.Name = "mCopy";
      this.mCopy.Size = new System.Drawing.Size(180, 22);
      this.mCopy.Text = "Copy Selected";
      this.mCopy.Click += new System.EventHandler(this.mCopy_Click);
      // 
      // mCopyAll
      // 
      this.mCopyAll.Name = "mCopyAll";
      this.mCopyAll.Size = new System.Drawing.Size(180, 22);
      this.mCopyAll.Text = "Copy All";
      this.mCopyAll.Click += new System.EventHandler(this.mCopyAll_Click);
      // 
      // Form1
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(594, 563);
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
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabC.ResumeLayout(false);
      this.tP_Info.ResumeLayout(false);
      this.tP_Clients.ResumeLayout(false);
      this.tP_EntryExit.ResumeLayout(false);
      this.tP_Dump.ResumeLayout(false);
      this.tP_Exceptions.ResumeLayout(false);
      this.ctxMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btScan;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txNumEntries;
    private System.Windows.Forms.Button btSchowOpen;
    private System.Windows.Forms.TableLayoutPanel tlp;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RichTextBox RTB_Info;
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
    private System.Windows.Forms.TabPage tP_Info;
    private System.Windows.Forms.TabPage tP_Clients;
    private System.Windows.Forms.CheckedListBox clbClients;
    private System.ComponentModel.BackgroundWorker BGW_RTB;
    private System.Windows.Forms.TextBox txFocusClient;
    private System.Windows.Forms.Button btFocDump;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.ProgressBar pBar;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TabPage tP_EntryExit;
    private System.Windows.Forms.TabPage tP_Dump;
    private System.Windows.Forms.RichTextBox RTB_EExit;
    private System.Windows.Forms.RichTextBox RTB_Dump;
    private System.Windows.Forms.TabPage tP_Exceptions;
    private System.Windows.Forms.RichTextBox RTB_Exceptions;
    private System.Windows.Forms.ContextMenuStrip ctxMenu;
    private System.Windows.Forms.ToolStripMenuItem mSelAll;
    private System.Windows.Forms.ToolStripMenuItem mCopy;
    private System.Windows.Forms.ToolStripMenuItem mCopyAll;
  }
}

