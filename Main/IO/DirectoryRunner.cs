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
            using var CTS = new CancellationTokenSource();
            {
                Task t;
                if (Directory.Exists(path))
                    t = Run(CTS.Token);
                else
                    throw new DirectoryNotFoundException();

                Task.Delay(40).ContinueWith(
                    (t) =>
                    {
                        if (t != null && !t.IsCompleted)
                        {
                            Console.WriteLine("Canceled by timeout");
                            CTS.Cancel();
                        }
                    }
                 );
            }
        }

        public void OnFileFound<EventArgs>(Object? obj, EventArgs e) {
            Console.WriteLine(e?.ToString());
        }

        public string Path { get; init; }

        async private Task Run(CancellationToken cancellationToken)        
        {
            //todo: пробелма в неодостижимости поочередного нахождения файлов.
            await Task.Run(() => {
                var f = new DirectoryInfo(Path).EnumerateFiles();
                foreach (var f2 in f)
                {
                    new CancellationTokenSource();
                    if (!cancellationToken.IsCancellationRequested)
                        // может лучше использовать/ new FileArg(f2 as FileInfo?) /
                        FileFound(this, new FileArg(f2.FullName));
                }
            });
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
