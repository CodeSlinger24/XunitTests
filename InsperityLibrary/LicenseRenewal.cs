using System;

namespace InsperityLibrary
{
    public class LicenseRenewal
    {
        public Guid Id { get; set; }

        public DateTime SalesDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public LicenseRenewal(DateTime salesDate)
        {
            SalesDate = salesDate;

            SetExpirationDate();
        }

        private void SetExpirationDate()
        {

            if(SalesDate.Day < DateTime.DaysInMonth(SalesDate.Year, SalesDate.Month))
            {
                ExpirationDate = new DateTime(SalesDate.Year, SalesDate.Month, DateTime.DaysInMonth(SalesDate.Year, SalesDate.Month));
            }
            else
            {
                if(SalesDate.Month < 12)
                {
                    ExpirationDate = new DateTime(SalesDate.Year, SalesDate.Month + 1, DateTime.DaysInMonth(SalesDate.Year, SalesDate.Month + 1));
                }
                else
                {
                    ExpirationDate = new DateTime(SalesDate.Year + 1, 1, DateTime.DaysInMonth(SalesDate.Year + 1, 1));

                }
            }
        }
    }
}
