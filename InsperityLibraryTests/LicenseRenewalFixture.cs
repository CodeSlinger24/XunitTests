using InsperityLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace InsperityLibraryTests
{
    public class LicenseRenewalFixture
    {
        public static IEnumerable<object[]> NotEndOfMonthTestData =>
            new List<object[]>()
            {
                new object[]{ new DateTime(2021, 1, 1)},
                new object[]{ new DateTime(2021, 2, 1)},
                new object[]{ new DateTime(2021, 3, 1)},
                new object[]{ new DateTime(2021, 4, 1)},
            };

        public static IEnumerable<object[]> EndOfMonthTestData =>
            new List<object[]>()
            {
                new object[]{ new DateTime(2021, 1, DateTime.DaysInMonth(2021, 1))},
                new object[]{ new DateTime(2021, 2, DateTime.DaysInMonth(2021, 2))},
                new object[]{ new DateTime(2021, 3, DateTime.DaysInMonth(2021, 3))},
                new object[]{ new DateTime(2021, 4, DateTime.DaysInMonth(2021, 4))},
            };

        public static IEnumerable<object[]> EndOfMonthAndYearTestData =>
            new List<object[]>()
            {
                new object[]{ new DateTime(2021, 12, DateTime.DaysInMonth(2021, 12))},
                new object[]{ new DateTime(2020, 12, DateTime.DaysInMonth(2020, 12))},
                new object[]{ new DateTime(2019, 12, DateTime.DaysInMonth(2019, 12))},
                new object[]{ new DateTime(2018, 12, DateTime.DaysInMonth(2018, 12))},
            };

        [Theory]
        [MemberData(nameof(NotEndOfMonthTestData))]
        public void ExpirationDateShouldExpireEndOfMonth(DateTime datetime)
        {
            LicenseRenewal license = new LicenseRenewal(datetime);

            datetime = new DateTime(datetime.Year, datetime.Month, DateTime.DaysInMonth(datetime.Year, datetime.Month));

            Assert.True(DateTime.Compare(datetime, license.ExpirationDate) == 0);
        }

        [Theory]
        [MemberData(nameof(EndOfMonthTestData))]
        public void ExpirationDateShouldExpireEndOfNextMonth(DateTime datetime)
        {
            LicenseRenewal license = new LicenseRenewal(datetime);

            datetime = new DateTime(datetime.Year, datetime.Month + 1, DateTime.DaysInMonth(datetime.Year, datetime.Month + 1));

            Assert.True(DateTime.Compare(datetime, license.ExpirationDate) == 0);
        }

        [Theory]
        [MemberData(nameof(EndOfMonthAndYearTestData))]
        public void ExpirationDateShouldExpireEndOfFirstMonthOfNextYear(DateTime datetime)
        {
            LicenseRenewal license = new LicenseRenewal(datetime);

            datetime = new DateTime(datetime.Year + 1, 1, DateTime.DaysInMonth(datetime.Year + 1, 1));

            Assert.True(DateTime.Compare(datetime, license.ExpirationDate) == 0);
        }
    }
}
