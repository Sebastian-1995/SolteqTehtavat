namespace EnergyUsageWebApp.Models
{
    public class monthlyData
    {

        public DateTime month;
        public double total;

        public DateTime Month { get => month; set => month = value; }
        public double Total { get => Math.Round(total,2); set => total = value; }
        public DateTime DateTime { get; }

        public monthlyData()
        {
            
        }

        public monthlyData(DateTime t, double v)
        {
            Month = t;
            Total = v;
        }



        public static List<monthlyData> getData(List<energyData> energyDatas)
        {


            DateTime dt = new DateTime();

            List<monthlyData> mList = new List<monthlyData>();

            double sum = 0;
            for (int i = 1; i <= 12; i++)
            {
                foreach (var s in energyDatas)
                {
                    if (s.TimeStamp.Month.Equals(i))
                    {
                        sum += s.Value;
                    }
                }
                mList.Add(new monthlyData(dt.AddMonths(i-1), sum));
                sum = 0;
            }

            return mList;
        }


    }
}
