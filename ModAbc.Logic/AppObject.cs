using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModAbc.Logic
{
    public class AppObject
    {
        public int InputChannel { get; set; }

        public string FileName { get; set; }

        public string WorkingDirectory { get; set; }

        public AppObject(int inputChannel, string fileName, string workingDirectory)
        {
            InputChannel = inputChannel;
            FileName = fileName;
            WorkingDirectory = workingDirectory;
        }
    }
}
