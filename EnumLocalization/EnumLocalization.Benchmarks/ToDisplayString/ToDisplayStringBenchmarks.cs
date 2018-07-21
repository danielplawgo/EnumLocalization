using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using EnumLocalization.Models;

namespace EnumLocalization.Benchmarks.ToDisplayString
{
    public class ToDisplayStringBenchmarks
    {
        protected OrderStatus OrderStatus { get; set; }

        public ToDisplayStringBenchmarks()
        {
            OrderStatus = OrderStatus.Completed;
        }

        [Benchmark]
        public string Resources()
        {
            return OrderStatus.ToDisplayStringResources();
        }

        [Benchmark]
        public string Reflection()
        {
            return OrderStatus.ToDisplayStringReflection();
        }

        [Benchmark]
        public string CreatingResourceManager()
        {
            return OrderStatus.ToDisplayStringCreatingResourceManager();
        }

        [Benchmark]
        public string UsingResourceManager()
        {
            return OrderStatus.ToDisplayStringUsingResourceManager();
        }

        [Benchmark]
        public string UsingResourceManagerAndCache()
        {
            return OrderStatus.ToDisplayStringUsingResourceManagerAndCache();
        }

        [Benchmark]
        public string EnumToString()
        {
            return OrderStatus.ToString();
        }
    }
}
