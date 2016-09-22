namespace LogcatViewer
{
    partial class LogcatViewer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogcatViewer));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All");
            this.button_run = new System.Windows.Forms.Button();
            this.imageList_icon = new System.Windows.Forms.ImageList(this.components);
            this.checkBox_autoscroll = new System.Windows.Forms.CheckBox();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.treeView_apps = new DoubleBufferTreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView_log = new DoubleBufferListView();
            this.Msg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_log_msg = new System.Windows.Forms.TextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.timer_addlog = new System.Windows.Forms.Timer(this.components);
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_refresh_processList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(12, 23);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(75, 23);
            this.button_run.TabIndex = 1;
            this.button_run.Text = "run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // imageList_icon
            // 
            this.imageList_icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_icon.ImageStream")));
            this.imageList_icon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_icon.Images.SetKeyName(0, "icon_info.png");
            this.imageList_icon.Images.SetKeyName(1, "icon_warring.png");
            this.imageList_icon.Images.SetKeyName(2, "icon_error.png");
            // 
            // checkBox_autoscroll
            // 
            this.checkBox_autoscroll.AutoSize = true;
            this.checkBox_autoscroll.Location = new System.Drawing.Point(105, 67);
            this.checkBox_autoscroll.Name = "checkBox_autoscroll";
            this.checkBox_autoscroll.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autoscroll.TabIndex = 3;
            this.checkBox_autoscroll.Text = "自动滚动";
            this.checkBox_autoscroll.UseVisualStyleBackColor = true;
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_main.Location = new System.Drawing.Point(12, 92);
            this.splitContainer_main.Name = "splitContainer_main";
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.Controls.Add(this.treeView_apps);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer_main.Panel2.Resize += new System.EventHandler(this.splitContainer_main_Panel2_Resize);
            this.splitContainer_main.Size = new System.Drawing.Size(918, 536);
            this.splitContainer_main.SplitterDistance = 306;
            this.splitContainer_main.TabIndex = 4;
            // 
            // treeView_apps
            // 
            this.treeView_apps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_apps.Location = new System.Drawing.Point(0, 0);
            this.treeView_apps.Name = "treeView_apps";
            treeNode1.Name = "RootNode";
            treeNode1.Text = "All";
            this.treeView_apps.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView_apps.Size = new System.Drawing.Size(304, 534);
            this.treeView_apps.TabIndex = 0;
            this.treeView_apps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_apps_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView_log);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_log_msg);
            this.splitContainer1.Size = new System.Drawing.Size(606, 534);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 4;
            // 
            // listView_log
            // 
            this.listView_log.BackColor = System.Drawing.SystemColors.Control;
            this.listView_log.BackgroundImageTiled = true;
            this.listView_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Msg});
            this.listView_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_log.FullRowSelect = true;
            this.listView_log.GridLines = true;
            this.listView_log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_log.LabelWrap = false;
            this.listView_log.Location = new System.Drawing.Point(0, 0);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(606, 378);
            this.listView_log.SmallImageList = this.imageList_icon;
            this.listView_log.TabIndex = 4;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            this.listView_log.View = System.Windows.Forms.View.Details;
            this.listView_log.SelectedIndexChanged += new System.EventHandler(this.listView_log_SelectedIndexChanged_1);
            // 
            // Msg
            // 
            this.Msg.Text = "Msg";
            this.Msg.Width = 603;
            // 
            // textBox_log_msg
            // 
            this.textBox_log_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_log_msg.Location = new System.Drawing.Point(0, 0);
            this.textBox_log_msg.Multiline = true;
            this.textBox_log_msg.Name = "textBox_log_msg";
            this.textBox_log_msg.ReadOnly = true;
            this.textBox_log_msg.Size = new System.Drawing.Size(606, 152);
            this.textBox_log_msg.TabIndex = 0;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(93, 23);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // timer_addlog
            // 
            this.timer_addlog.Interval = 1000;
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(216, 24);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(614, 21);
            this.textBox_search.TabIndex = 6;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // button_refresh_processList
            // 
            this.button_refresh_processList.Location = new System.Drawing.Point(12, 63);
            this.button_refresh_processList.Name = "button_refresh_processList";
            this.button_refresh_processList.Size = new System.Drawing.Size(75, 23);
            this.button_refresh_processList.TabIndex = 7;
            this.button_refresh_processList.Text = "Refresh";
            this.button_refresh_processList.UseVisualStyleBackColor = true;
            this.button_refresh_processList.Click += new System.EventHandler(this.button_refresh_processList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "fliter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "eg: pid=1;msg=xxx;tag=Unity;lv=e/i/w";
            // 
            // LogcatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 706);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_refresh_processList);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.splitContainer_main);
            this.Controls.Add(this.checkBox_autoscroll);
            this.Controls.Add(this.button_run);
            this.Name = "LogcatViewer";
            this.Text = "LogCatViewer";
            this.Load += new System.EventHandler(this.LogcatViewer_Load);
            this.Resize += new System.EventHandler(this.LogcatViewer_Resize);
            this.splitContainer_main.Panel1.ResumeLayout(false);
            this.splitContainer_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.ImageList imageList_icon;
        private System.Windows.Forms.CheckBox checkBox_autoscroll;
        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Timer timer_addlog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DoubleBufferListView listView_log;
        private System.Windows.Forms.ColumnHeader Msg;
        private System.Windows.Forms.TextBox textBox_log_msg;
        private DoubleBufferTreeView treeView_apps;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_refresh_processList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

