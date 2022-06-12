using System;

namespace Laba_2
{
    public class Wine:Product
    {
        DateTime issueYear { get; set; }

        public override float quality => 0.5f * (float)(DateTime.Now - issueYear).TotalDays + base.quality;

        public Wine(string name, float price, int count, DateTime issueYear) :base(name, price, count)
        {
            this.issueYear = issueYear;
        }
        public override string ToString()
        {
            return $"Год выпуска: {issueYear}\n" + base.ToString();
        }

        public override void ToGridRow(string[] row)
        {
            base.ToGridRow(row);
            row[4]=issueYear.ToString();
        }
    }
}
