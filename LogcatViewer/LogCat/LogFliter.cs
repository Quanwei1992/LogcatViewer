using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogcatViewer
{
    public class LogFliter
    {
        public string tag = string.Empty;
        public string msg = string.Empty;
        public string pid = string.Empty;
        public string lv = string.Empty;

        public bool isMatch(LogMsg log)
        {
            if (!string.IsNullOrEmpty(pid)) {
                if (pid != log.pid.ToString()) {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(tag)) {
                if (!log.tag.Contains(tag)) {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(msg)) {
                if (!log.msg.Contains(msg)) {
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(lv)) {
                if (lv == "i" && (log.level == LogLevel.Error || log.level == LogLevel.Warning)) return false;
                if (lv == "e" && log.level != LogLevel.Error) return false;
                if (lv == "w" && log.level != LogLevel.Warning) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string ret = "";
            if (!string.IsNullOrEmpty(pid)) {
                ret += "pid=" + pid+";";
            }
            if (!string.IsNullOrEmpty(msg)) {
                ret += "msg=" + msg + ";";
            }
            if (!string.IsNullOrEmpty(tag)) {
                ret += "tag=" + tag + ";";
            }
            if (!string.IsNullOrEmpty(lv)) {
                ret += "lv=" + lv + ";";
            }
            return ret;
        }

        public void Parse(string s)
        {
            pid = string.Empty;
            tag = string.Empty;
            msg = string.Empty;
            var args = s.Split(';');
            foreach (var arg in args) {
                if (arg.StartsWith("pid=")) {
                    pid = arg.Replace("pid=", "");
                    continue;
                }
                if (arg.StartsWith("msg=")) {
                    msg = arg.Replace("msg=", "");
                    continue;
                }
                if (arg.StartsWith("tag=")) {
                    tag = arg.Replace("tag=", "");
                    continue;
                }
                if (arg.StartsWith("lv=")) {
                    lv = arg.Replace("lv=", "");
                    continue;
                }
            }
        }
    }
}
