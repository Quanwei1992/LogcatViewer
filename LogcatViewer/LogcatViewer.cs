using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogcatViewer
{
    public partial class LogcatViewer : Form
    {

        private LogCat logcat = new LogCat();
        List<LogMsg> logs = new List<LogMsg>();
        LogFliter fliter = new LogFliter();
        public LogcatViewer()
        {
            InitializeComponent();
            logcat.OnRecvLog = OnRecvLog;
            RefreshProcessList();
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (button_run.Text == "run")
            {
                logcat.run();
                button_run.Text = "stop";
            }
            else if (button_run.Text == "stop") {
                logcat.stop();
                button_run.Text = "run";
            }
        }


        private void OnRecvLog(LogMsg log)
        {
            RunInMainthread(()=> {
                addLog(log);
            });
        }

        Dictionary<int, int> logCountDic = new Dictionary<int, int>();
        void addLog(LogMsg log,bool update=false)
        {



            int iconIndex = 0;
            if (log.level == LogLevel.Error)
            {
                iconIndex = 2;
            }
            else if (log.level == LogLevel.Warning)
            {
                iconIndex = 1;
            }

            if (!update)
            {
                logs.Add(log);
                //if (!logCountDic.ContainsKey(log.pid)) {
                //    logCountDic[log.pid] = 0;
                //}

                //logCountDic[log.pid] += 1;


                //if (nodesDic.ContainsKey(log.pid)) {
                //    var node = nodesDic[log.pid];
                //    node.Text = node.Name + "(" + logCountDic[log.pid] + ")";
                //}
            }



            ListViewItem item = new ListViewItem();
            item.ImageIndex = iconIndex;
            item.Text = string.Format("[{0}]{1}",log.tag,log.msg);
            item.Tag = log;

            if (fliter.isMatch(log)) {
                listView_log.Items.Add(item);
                if (checkBox_autoscroll.Checked && !update) {
                    item.EnsureVisible();
                }
            }
        }

        private void LogcatViewer_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        void RunAsync(Action action)
        {
            ((Action)(delegate ()
            {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate ()
            {
                action?.Invoke();
            }));
        }



        private void LogcatViewer_Resize(object sender, EventArgs e)
        {
            splitContainer_main.Width = this.Width - 40;
            splitContainer_main.Height = this.Height - 120;
        }

        private void treeView_apps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = treeView_apps.SelectedNode;
            if (node == treeView_apps.Nodes[0]) {
                fliter.pid = string.Empty;
            } else {
                fliter.pid = node.Tag.ToString();
            }
            textBox_search.Text = fliter.ToString();
        }

        void refresh()
        {
            
            listView_log.BeginUpdate();
            listView_log.Items.Clear();
            foreach (var log in logs) {
                addLog(log, true);
            }
            listView_log.EndUpdate();
        }


        private void button_clear_Click(object sender, EventArgs e)
        {
            logs.Clear();
            listView_log.Items.Clear();
        }

        private void listView_log_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Dictionary<int, TreeNode> nodesDic = new Dictionary<int, TreeNode>();
        private void RefreshProcessList()
        {
            List<AndroidProcessInfo> infoList = new List<AndroidProcessInfo>();
            infoList.AddRange(logcat.GetProcessList());
            infoList.Sort((a, b) => {
                if (a.NAME.StartsWith("com.") && b.NAME.StartsWith("com.")) {
                    return a.NAME.CompareTo(b.NAME);
                } else if (a.NAME.StartsWith("com.")) {
                    return -1;
                } else if(b.NAME.StartsWith("com.")) {
                    return 1;
                }
                return a.PID - b.PID;
            });
            treeView_apps.Nodes[0].Nodes.Clear();
            foreach (var info in infoList) {
                TreeNode node = new TreeNode();
                node.Tag = info.PID;
                node.Name = info.NAME;
                node.Text = info.NAME;
                treeView_apps.Nodes[0].Nodes.Add(node);
                nodesDic[info.PID] = node;
            }
            treeView_apps.ExpandAll();
        }

        private void splitContainer_main_Panel2_Resize(object sender, EventArgs e)
        {
            if (listView_log.Columns.Count > 0) {
                listView_log.Columns[0].Width = listView_log.Width - 32;
            }
            
        }

        private void listView_log_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView_log.SelectedItems.Count > 0) {
                string text = "";
                foreach (ListViewItem item in listView_log.SelectedItems) {
                    var log = item.Tag as LogMsg;
                    text = text + log.msg + "\r\n";
                }
                
                textBox_log_msg.Text = text;
            }

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            fliter.Parse(textBox_search.Text);
            refresh();
        }

        private void button_refresh_processList_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }
    }
}
