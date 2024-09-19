namespace ConcurrencyBenchmark
{
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public partial class MyGridBenchmarks
    {
        private DictionaryWithLockClass lockBased;
        private ConcurrentDictionaryClass concurrentBased;

        [GlobalSetup]
        public void Setup()
        {
            lockBased = new DictionaryWithLockClass();
            concurrentBased = new ConcurrentDictionaryClass();
        }

        [Benchmark]
        public ParallelLoopResult TestLockBased_MostlyReads()
        {
            return Parallel.For(0, 1000, i =>
            {
                lockBased.GetValueViaCache(i % 10, ColumnTypeEnum.SomeType);
            });
        }

        [Benchmark]
        public ParallelLoopResult TestConcurrent_MostlyReads()
        {
            return Parallel.For(0, 1000, i =>
            {
                concurrentBased.GetValueViaCache(i % 10, ColumnTypeEnum.SomeType);
            });
        }

        [Benchmark]
        public ParallelLoopResult TestLockBased_MostlyWrites()
        {
            return Parallel.For(0, 1000, i =>
            {
                lockBased.GetValueViaCache(i, ColumnTypeEnum.SomeType);
            });
        }

        [Benchmark]
        public ParallelLoopResult TestConcurrent_MostlyWrites()
        {
            return Parallel.For(0, 1000, i =>
            {
                concurrentBased.GetValueViaCache(i, ColumnTypeEnum.SomeType);
            });
        }
    }
}
