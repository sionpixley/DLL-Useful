using BenchmarkDotNet.Attributes;
using Sion.Useful.Security;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class Security
    {
        [Benchmark]
        [MaxIterationCount(20)]
        public void Random_Double_MinAndMax()
        {
            double min = 8.2;
            double max = 2000.812;
            for(int i = 0; i < 1000000; i += 1)
            {
                Random.Double(min, max);
            }
        }

        [Benchmark]
        [MaxIterationCount(20)]
        public void Random_Float_MinAndMax()
        {
            float min = 67.2F;
            float max = 73.08F;
            for(int i = 0; i < 1000000; i += 1)
            {
                Random.Float(min, max);
            }
        }

        [Benchmark]
        [MaxIterationCount(20)]
        public void Random_Int_MinAndMax()
        {
            int min = -63;
            int max = 300;
            for(int i = 0; i < 1000000; i += 1)
            {
                Random.Int(min, max);
            }
        }
    }
}
