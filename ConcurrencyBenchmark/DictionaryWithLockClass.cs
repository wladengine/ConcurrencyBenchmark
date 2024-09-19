namespace ConcurrencyBenchmark
{
    using System.Collections.Generic;

    public partial class MyGridBenchmarks
    {
        public class DictionaryWithLockClass
        {
            private readonly Dictionary<int, double> _cacheValues = new Dictionary<int, double>();

            protected double? GetValue(int analyticId, ColumnTypeEnum columnType) => 0d;

            public double GetValueViaCache(int analyticId, ColumnTypeEnum columnType)
            {
                double uaValue = 0.0D;

                lock (_cacheValues)
                {
                    if (!_cacheValues.TryGetValue(analyticId, out uaValue))
                    {
                        uaValue = GetValue(analyticId, columnType).GetValueOrDefault();
                        _cacheValues.Add(analyticId, uaValue);
                    }
                }

                return uaValue;
            }
        }
    }
}
