using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogcatViewer
{


    public enum LogLevel
    {
        Verbose,
        Debug,
        Information,
        Warning,
        Error
    }

    public class LogMsg
    {
        public DateTime date;
        public int pid;
        public int tid;
        public LogLevel level;
        public string tag;
        public string msg;

        const string logMetaFormatPattern = @"^\[ +(?<Date>\d{2}-\d{2} +\d{2}:\d{2}:\d{2}\.\d{1,3}) +(?<PID>[\dxXabcdefABCDEF]+): *(?<TID>[\dxXabcdefABCDEF]+) +(?<Level>[WIEVD])/(?<Tag>.+) +]$";
        const string logDateTimeFormat = "MM-dd HH:mm:ss.fff";
        static Regex MetaRegex = new Regex(logMetaFormatPattern);
        public static LogMsg Parse(string s)
        {

            if (MetaRegex.IsMatch(s))
            {
                LogMsg msg = new LogMsg();
                var match = MetaRegex.Match(s);
                DateTime dt = DateTime.ParseExact(match.Groups["Date"].Value, logDateTimeFormat, System.Globalization.CultureInfo.CurrentCulture);
                msg.date = dt;
                string pid = match.Groups["PID"].Value;
                if (pid.ToLower().StartsWith("0x"))
                {
                    msg.pid = Convert.ToInt32(pid.Substring(2), 16);
                }
                else
                {
                    msg.pid = int.Parse(pid);
                }

                string tid = match.Groups["TID"].Value;
                if (tid.ToLower().StartsWith("0x"))
                {
                    msg.tid = Convert.ToInt32(pid.Substring(1), 16);
                }
                else
                {
                    msg.tid = int.Parse(tid);
                }
                string levelStr = match.Groups["Level"].Value;
                switch (levelStr)
                {
                    case "V":
                        msg.level = LogLevel.Verbose;
                        break;
                    case "I":
                        msg.level = LogLevel.Information;
                        break;
                    case "W":
                        msg.level = LogLevel.Warning;
                        break;
                    case "E":
                        msg.level = LogLevel.Error;
                        break;
                    case "D":
                        msg.level = LogLevel.Debug;
                        break;
                }

                msg.tag = match.Groups["Tag"].Value;
                msg.tag = msg.tag.Trim();


                return msg;
            }

            return null;
        }

    }
}
