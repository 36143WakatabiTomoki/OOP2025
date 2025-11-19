using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDi {
    public class LineToHalfNumberService : ITextFileService {
        public void Initialize(string fname) {
            
        }

        public void Execute(string line) {
            var lowerNumber = new string(
                line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray()
            );
            Console.WriteLine(lowerNumber);
        }

        public void Terminate() {
        }
    }
}
