using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class ProcessExtension
    {
        public static long CalculateMemory(this Process[] processes)
        {
            long memory = 0;
            foreach (var process in processes)
            {
                memory += process.PrivateMemorySize64;
            }
            return memory;
        }
    }
}
