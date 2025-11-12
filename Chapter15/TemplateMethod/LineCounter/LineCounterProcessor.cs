using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;

        private string readText = "";

        protected override void Initialize(string fname) {
            _count = 0;
            Console.Write("検索したい単語：");
            readText = Console.ReadLine();
        }

        protected override void Execute(string line) {
            if (line.Contains(readText)) {
                _count++;
            }
        }

        protected override void Terminate() => Console.WriteLine("単語が含まれた行 {0}", _count);
    }
}
