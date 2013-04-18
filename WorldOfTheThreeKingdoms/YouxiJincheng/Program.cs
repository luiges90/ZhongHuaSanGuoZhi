using System;

using System.Windows.Forms;

using System.IO;
using System.Threading;
using WorldOfTheThreeKingdoms.GameProcesses;

namespace WorldOfTheThreeKingdoms
{
#if WINDOWS || XBOX
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            /*bool flag;
            Mutex mutex = new Mutex(true, "WorldOfTheThreeKingdoms", out flag);
            if (!flag)
            {
                MessageBox.Show("游戏已经在运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                mutex.ReleaseMutex();
                new MainProcessManager().Processing();
            }*/
            try
            {
                new MainProcessManager().Processing();
            }
            catch (Exception e)
            {
                DateTime dt = System.DateTime.Now;
                String logPath = "CrashLog_" + dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "h" + dt.Minute + ".log";
                StreamWriter sw = new StreamWriter(new FileStream(logPath, FileMode.Create));

                sw.WriteLine("==================== Message ====================");
                sw.WriteLine(e.Message);
                sw.WriteLine("=================== StackTrace ==================");
                sw.WriteLine(e.StackTrace);

                sw.Close();
                
                MessageBox.Show("中华三国志遇到严重错误，请提交游戏目录下的'" + logPath + "'。", "游戏错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

 

#endif
}

