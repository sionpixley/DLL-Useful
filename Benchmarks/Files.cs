using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using Sion.Useful.Files;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public async Task Setup() {
			Task<IEnumerable<string[]>> dataNo = Csv.ReadAsync(@".\assets\benchmark.csv", hasHeader: true);
			Task<IEnumerable<ItemRow>> dataType = Csv.ReadAsync<ItemRow>(@".\assets\benchmarkCopy.csv", hasHeader: true);
			await Task.WhenAll(dataNo, dataType);
			_DataNoType = dataNo.Result;
			_DataType = dataType.Result;
		}

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Read_NoType() => _ = Csv.Read(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Read_TwoFiles() {
			_ = Csv.Read(@".\assets\benchmark.csv", hasHeader: true);
			_ = Csv.Read(@".\assets\benchmarkCopy.csv", hasHeader: true);
		}

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Read_Type() => _ = Csv.Read<ItemRow>(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_ReadAsync_NoType() => _ = await Csv.ReadAsync(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_ReadAsync_TwoFiles() {
			Task<IEnumerable<string[]>> data = Csv.ReadAsync(@".\assets\benchmark.csv", hasHeader: true);
			Task<IEnumerable<string[]>> data2 = Csv.ReadAsync(@".\assets\benchmarkCopy.csv", hasHeader: true);
			await Task.WhenAll(data, data2);
		}

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_ReadAsync_Type() => _ = await Csv.ReadAsync<ItemRow>(@".\assets\benchmark.csv", hasHeader: true);

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Write_NoType() => Csv.Write(_DataNoType, @".\assets\benchmark2.csv");

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Write_TwoFiles() {
			Csv.Write(_DataNoType, @".\assets\benchmark2.csv");
			Csv.Write(_DataType, @".\assets\benchmark3.csv", true);
		}

		[Benchmark]
		[MaxIterationCount(20)]
		public void Csv_Write_Type() => Csv.Write(_DataType, @".\assets\benchmark3.csv", true);

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_WriteAsync_NoType() => await Csv.WriteAsync(_DataNoType, @".\assets\benchmark2.csv");

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_WriteAsync_TwoFiles() {
			Task write = Csv.WriteAsync(_DataNoType, @".\assets\benchmark2.csv");
			Task write2 = Csv.WriteAsync(_DataType, @".\assets\benchmark3.csv", true);
			await Task.WhenAll(write, write2);
		}

		[Benchmark]
		[MaxIterationCount(20)]
		public async Task Csv_WriteAsync_Type() => await Csv.WriteAsync(_DataType, @".\assets\benchmark3.csv", true);
	}
}
