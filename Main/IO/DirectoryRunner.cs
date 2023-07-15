using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Main.IO
{
    public class DirectoryRunner
    {
        public event EventHandler<EventArgs> FileFound;
        public DirectoryRunner(string path)
        {
            Path = path;
            //config 
            FileFound += new EventHandler<EventArgs>(OnFileFound);
            //var cancel = new CancellationToken();
            if (Directory.Exists(path))
                Run();
            else
                throw new DirectoryNotFoundException();
        }

        public void OnFileFound<EventArgs>(Object? obj, EventArgs e) {
            Console.WriteLine(e.ToString());
        }

        public string Path { get; init; }

        //async private Task Run(CancellationToken cancellationToken)
        private void Run()
        {
            //todo: пробелма в неодостижимости поочередного нахождения файлов.
            var f = new DirectoryInfo(Path).EnumerateFiles();
            foreach (var f2 in f)
            {   
                //if(!cancellationToken.IsCancellationRequested)                
                    // может лучше использовать/ new FileArg(f2 as FileInfo?) /
                    FileFound(this, new FileArg(f2.FullName));
            }
        }
        class FileArg : EventArgs
        {
            public string Path { get; init; }
            public FileArg(string path) =>
                Path = path;
            public override string ToString() =>
                $"{Path}";
        }

    }
}
