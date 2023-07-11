using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class DirectoryRunner
    {
        private event EventHandler<EventArgs> FileFound;
        public DirectoryRunner(string path) {
            Path = path;
            if (Directory.Exists(path))
                Run();
            else
                throw new DirectoryNotFoundException();
        }

        public string Path { get; init; }

        private void Run() {
            new DirectoryInfo(Path).EnumerateFiles()

        }
    }
}
