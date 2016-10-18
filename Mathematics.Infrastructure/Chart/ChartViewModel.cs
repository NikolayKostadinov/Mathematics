namespace Mathematics.Infrastructure.Chart
{
    using System.Collections.Generic;

    public class ChartViewModel<XType, YType>
    {
        public string Title { get; set; }
        public IEnumerable<DataSery<XType, YType>> DataSeries { get; set; }

        public int? Height { get; set; }
    }
}