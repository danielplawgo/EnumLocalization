using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using EnumLocalization.Benchmarks.ToDisplayString;
using EnumLocalization.Models;
using EnumLocalization.Resources;

namespace EnumLocalization.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ToDisplayStringBenchmarks>();
        }
    }
}
