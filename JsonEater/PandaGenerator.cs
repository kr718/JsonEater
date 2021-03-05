using System.Diagnostics;

namespace JsonEater
{
    public class PandaGenerator
    {
        public static ProcessStartInfo CreateGeneratorProcessInfo(string filePath)
        {
            var info = new ProcessStartInfo();
            info.FileName = filePath;
            info.UseShellExecute = false;
            info.CreateNoWindow = false;
            info.RedirectStandardOutput = true;

            return info;
        }

        public static Process CreateGeneratorProcess(ProcessStartInfo info)
        {
            var process = new Process();
            process.StartInfo = info;
            process.Start();
            return process;
        }
    }
}
