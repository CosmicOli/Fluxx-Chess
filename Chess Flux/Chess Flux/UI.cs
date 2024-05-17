using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class UI
    {
        public UI()
        {
            
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
