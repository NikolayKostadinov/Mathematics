/// <summary>
/// Summary description for DataSery
/// </summary>
namespace Mathematics.Infrastructure.Chart
{
    public class Pair <XType,YType>
    {
        public Pair(){}

        public Pair(XType xValue, YType yValue)
        {
            this.X = xValue;
            this.Y = yValue;
        }
        public XType X { get; set; }
        public YType Y { get; set; }      
        
    }
}
