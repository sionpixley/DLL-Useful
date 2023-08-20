using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using Benchmarks.Classes;
using Sion.Useful.Files;
using System.Collections.Generic;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class Files {
		[Benchmark]
		public void Csv_ReadNoType() {
			IEnumerable<string[]> data = Csv.Read(@".\assets\benchmark.csv", hasHeader: true);
		}

		[Benchmark]
		public void Csv_ReadType() {
			IEnumerable<ItemRow> data = Csv.Read<ItemRow>(@".\assets\benchmark.csv", hasHeader: true);
		}
	}
}
