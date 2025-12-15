using BenchmarkDotNet.Running;
using Benchmarks;

_ = BenchmarkRunner.Run<Files>();
_ = BenchmarkRunner.Run<Security>();
