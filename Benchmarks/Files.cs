using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using Sion.Useful.Files;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class Files {
		private IEnumerable<string[]> _DataNoType { get; set; }
		private IEnumerable<ItemRow> _DataType { get; set; }

		public Files() {
			_DataNoType = Enumerable.Empty<string[]>();
			_DataType = Enumerable.Empty<ItemRow>();
		}

		[GlobalSetup]
		public void Setup() {
			_DataNoType = Csv.Read(@".\assets\benchmark.csv", hasHeader: true);
			_DataType = Csv.Read<ItemRow>(@".\assets\benchmark.csv", hasHeader: true);
		}

		[Benchmark]
		public void Csv_ReadNoType() => Csv.Read(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		public void Csv_ReadType() => Csv.Read<ItemRow>(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		public void Csv_WriteNoType() => Csv.Write(_DataNoType, @".\assets\benchmark2.csv");

		[Benchmark]
		public void Csv_WriteType() => Csv.Write<ItemRow>(_DataType, @".\assets\benchmark3.csv", true);
	}
}
