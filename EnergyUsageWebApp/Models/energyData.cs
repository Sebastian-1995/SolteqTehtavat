
namespace EnergyUsageWebApp
{
    public class energyData
    {
        private DateTime timeStamp;
        private string reportingGroup;
        private string locationName;
        private double value;
        private string unit;
        
        public energyData()
        {

        }

        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        public string ReportingGroup { get => reportingGroup; set => reportingGroup = value; }
        public string LocationName { get => locationName; set => locationName = value; }
        public double Value { get => Math.Round(value,2); set => this.value = value; }
        public string Unit { get => unit; set => unit = value; }
        
        public energyData(DateTime t,string r,string l,double v,string u)
        {
            TimeStamp = t;
            ReportingGroup = r;
            LocationName = l;
            Value = v;
            Unit = u;
        }

  

    }
}
