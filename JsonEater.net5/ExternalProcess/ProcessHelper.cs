using System.Diagnostics;
using JsonEater.StartUp.Config;

namespace JsonEater.ExternalProcess
{
    public class ProcessHelper : IProcessHelper<PandaGeneratorConfig>
    {
        public ProcessStartInfo GetInfo(PandaGeneratorConfig config)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = config.ProcessPath;
            info.UseShellExecute = false;
            info.CreateNoWindow = false;
            info.RedirectStandardOutput = true;

            return info;
        }
    }
}
