using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.BllDalClasses.BllClass.Common
{
    public class DateDifference
    {
        /// <summary>
        /// defining Number of days in month; index 0=> january and 11=> December
        /// february contain either 28 or 29 days, that's why here value is -1
        /// which wil be calculate later.
        /// </summary>
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// contain from date
        /// </summary>
        private DateTime fromDate;

        /// <summary>
        /// contain To Date
        /// </summary>
        private DateTime toDate;

        /// <summary>
        /// this three variable for output representation..
        /// </summary>
        private int year;
        private int month;
        private int day;

        public int Years
        {
            get
            {
                return this.year;
            }
        }

        public int Months
        {
            get
            {
                return this.month;
            }
        }

        public int Days
        {
            get
            {
                return this.day;
            }
        }

        public DateDifference(DateTime d1, DateTime d2)
        {
            int increment;
            int actMnthIncrement;
            int actYrIncrement;
            
            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            /// 
            /// Day Calculation
            /// 
            increment = 0;
            actMnthIncrement = 0;
            actYrIncrement = 0;

            if (this.fromDate.Day > this.toDate.Day || this.fromDate.Month == 2 )
            {
                increment = this.monthDay[this.fromDate.Month - 1];

            }
            /// if it is february month
            /// if it's to day is less then from day
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // leap year february contain 29 days
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment == 29 || increment == 28)
            {
                if (this.toDate.Day >= increment)
                {
                    day = (this.toDate.Day - increment) - this.fromDate.Day - 1;
                    increment = 1; actMnthIncrement = 2;
                }
                else
                {
                    day = (this.toDate.Day + increment) - this.fromDate.Day + 1;
                    //int loop = 0;
                    while (day >= increment)
                    {
                        day = day - increment;
                        actMnthIncrement = 1;
                        // loop++;
                    }
                    increment = 1;// loop;
                }
            }
            else if (increment != 0)
            {
                day = (this.toDate.Day + increment) - this.fromDate.Day ;
                if (this.monthDay[this.fromDate.Month - 1] > this.monthDay[this.toDate.Month - 1])
                    day = day + (this.monthDay[this.fromDate.Month - 1] - this.monthDay[this.toDate.Month - 1]) * 2;
                else if (this.monthDay[this.fromDate.Month - 1] == this.monthDay[this.toDate.Month - 1])
                    day = day + 1;
                increment = 1;
                if (day >= this.monthDay[this.fromDate.Month - 1])
                {
                    day = day - this.monthDay[this.fromDate.Month - 1];
                    actMnthIncrement = 1;
                }
            }
            else
            {
                day = this.toDate.Day - this.fromDate.Day;
                if (this.fromDate.Month != 2 && this.toDate.Month == 2)
                {
                    if (DateTime.IsLeapYear(this.fromDate.Year))
                    {
                        // leap year february contain 29 days
                        day = day + (this.monthDay[this.fromDate.Month - 1] - 29)*2;
                    }
                    else
                    {
                        day = day + (this.monthDay[this.fromDate.Month - 1] - 28)*2;
                    }
                }
                    //if (this.monthDay[this.toDate.Month - 1] == 30)
                else if (this.monthDay[this.fromDate.Month - 1] > this.monthDay[this.toDate.Month - 1])
                    day = day + (this.monthDay[this.fromDate.Month - 1] - this.monthDay[this.toDate.Month - 1]) * 2;
                else if (this.monthDay[this.fromDate.Month - 1] == this.monthDay[this.toDate.Month - 1])
                    day = day + 1;
                    //else if (this.monthDay[this.toDate.Month - 1] == 31)
                    //    day = day - 1;
                if (day >= this.monthDay[this.fromDate.Month - 1])
                {
                    day = day - this.monthDay[this.fromDate.Month - 1];
                    actMnthIncrement = 1;
                }
            }

            ///
            ///month calculation
            ///
            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }
            if (actMnthIncrement != 0)
            {
                this.month = this.month + actMnthIncrement;
                if (this.month >= 12)
                {
                    this.month = this.month - 12;
                    actYrIncrement=1;
                }
            }
            ///
            /// year calculation
            ///
            this.year = this.toDate.Year - (this.fromDate.Year + increment);
            if (actYrIncrement != 0)
                this.year = this.year + actYrIncrement;
        }

        public override string ToString()
        {
            //return base.ToString();
            string retStr = "";
            if (this.year > 0)
                retStr = retStr + this.year + " yr";
            if (this.month > 0)
            {
                if (retStr!="")
                    retStr = retStr + ",";
                retStr = retStr + this.month + " m";
            }
            if(this.day>0)
            {
                if (retStr != "")
                    retStr = retStr + ",";
                retStr = retStr + this.day + " d";
            }
            return retStr;
        }

        public int[] yyyyMMMdd()
        {
            int[] countAll=new int[3];
            countAll[0] = this.year;
            countAll[1] = this.month;
            countAll[2] = this.day;
            return countAll;
        }

    }
}
