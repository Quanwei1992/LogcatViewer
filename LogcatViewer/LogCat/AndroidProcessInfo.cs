using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace LogcatViewer
{
    public class AndroidProcessInfo
    {
        public string USER;
        public int PID;
        public int PPID;
        public int VSIZE;
        public int RSS;
        public string WCHAN;
        public string PC;
        public string State;
        public string NAME;

        public static AndroidProcessInfo Parse(string s)
        {
            //USER     PID   PPID  VSIZE  RSS     WCHAN    PC         NAME
            //shell     30118 25016 1248   244   00000000 401bd570 R ps
            //s = "u0_a12    994   154   563256 24812 ffffffff 00000000 S com.google.process.location";
            string str = s.Replace(" ", "#");
            while (str.Contains("##")) {
                str = str.Replace("##", "#");
            }
            
            var args = str.Split('#');
            if (args.Length != 9) {
                Debug.WriteLine("Parse failed:" + s);
                return null;
            }

            AndroidProcessInfo info = new AndroidProcessInfo();
            info.USER = args[0];
            info.PID = int.Parse(args[1]);
            info.PPID = int.Parse(args[2]);
            info.VSIZE = int.Parse(args[3]);
            info.RSS = int.Parse(args[4]);
            info.WCHAN = args[5];
            info.PC = args[6];
            info.State = args[7];
            info.NAME = args[8];
            return info;
        }
    }
}
