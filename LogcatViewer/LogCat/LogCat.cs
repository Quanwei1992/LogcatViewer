using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace LogcatViewer
{
    public class LogCat
    {

        public Action<LogMsg> OnRecvLog;
        private DateTime lastLogDate = DateTime.MinValue;



        private Process mADBProcess = null;
        bool isRunning = false;
        public void run()
        {
            if (isRunning) return;



            ClearCache();
            ProcessStartInfo info = new ProcessStartInfo("adb", "logcat -v long");
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            mADBProcess = System.Diagnostics.Process.Start(info);
            if (mADBProcess != null) {
                isRunning = true;
                mADBProcess.EnableRaisingEvents = true;
                mADBProcess.OutputDataReceived += onReveOutputData;
                mADBProcess.BeginOutputReadLine();
                mADBProcess.Exited += (sender, e) =>
                {
                    mADBProcess = null;
                    if (isRunning) {
                        isRunning = false;
                        Debug.WriteLine("Restart log cat");
                        run();
                    }               
                };
                
            }
          
        }


        public void ClearCache()
        {
            ProcessStartInfo info = new ProcessStartInfo("adb", "logcat -c");
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            Process.Start(info);
        }

        public void stop()
        {
            if (!isRunning) return;
            if (mADBProcess != null && !mADBProcess.HasExited) {
                mADBProcess.Kill();
                mADBProcess = null;
                isRunning = false;
            }      
        }


        public AndroidProcessInfo[] GetProcessList()
        {
            ProcessStartInfo info = new ProcessStartInfo("adb", "shell ps");
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.StandardOutputEncoding = Encoding.UTF8;
            mADBProcess = System.Diagnostics.Process.Start(info);
            //mADBProcess.WaitForInputIdle();
            string output = mADBProcess.StandardOutput.ReadToEnd();
            //mADBProcess.Kill();
            string[] lines = output.Split('\n');
            List<AndroidProcessInfo> ret = new List<AndroidProcessInfo>();
            foreach (var line in lines) {
                var pinfo = AndroidProcessInfo.Parse(line);
                if (pinfo != null) {
                    ret.Add(pinfo);
                }

            }
            return ret.ToArray();

        }


        string msgCache = null;
        LogMsg logCache = null;
        void onReveOutputData(object sender, DataReceivedEventArgs e)
        {
            if (e == null || e.Data == null) return;
            var bytes = Encoding.GetEncoding("GB2312").GetBytes(e.Data);
            string str = Encoding.UTF8.GetString(bytes);
            if (str.StartsWith("[") && str.EndsWith("]")) {
                if (logCache != null) {
                    if (msgCache!=null && msgCache.EndsWith("\n")) {
                        msgCache = msgCache.Substring(0, msgCache.Length - 1);
                    }
                    logCache.msg = msgCache;
                    if (logCache.msg == null) {
                        logCache.msg = "";
                    }
                    if (logCache.date >= lastLogDate) {
                        lastLogDate = logCache.date;
                        OnRecvLog?.Invoke(logCache);
                    }

                }
                msgCache = null;
                logCache = LogMsg.Parse(str);
            } else {
                if (!string.IsNullOrWhiteSpace(str)) {
                    msgCache += str+"\n";
                }
               
            }
        }
    }
}
