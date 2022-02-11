using System.Diagnostics;

namespace JsonEater.ExternalProcess
{
    public class PandaGeneratorProcessManager
    {
        private Process? _process;
        public PandaGeneratorProcessManager(ProcessStartInfo info)
        {
            CreateGeneratorProcess(info);
        }
        private void CreateGeneratorProcess(ProcessStartInfo info)
        {
            try
            {
                _process = new Process();
                _process.StartInfo = info;
                _process.Start();
            }
            catch (Exception)
            {
                _process?.Dispose();
                throw;
            }
            
        }
    }
}
