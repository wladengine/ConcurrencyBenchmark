namespace ConcurrencyBenchmark
{
    using System.Collections.Concurrent;

    public partial class MyGridBenchmarks
    {
        public class ConcurrentDictionaryClass
        {
            private readonly ConcurrentDictionary<int, double> _uaValues = new ConcurrentDictionary<int, double>();

            protected double? GetValue(int analyticId, ColumnTypeEnum columnType) => 0d;

            public double GetValueViaCache(int analyticId, ColumnTypeEnum columnType)
            {
                return _uaValues.GetOrAdd(analyticId, key =>
                {
                    return GetValue(key, columnType).GetValueOrDefault();
                });
            }
        }
    }
}
