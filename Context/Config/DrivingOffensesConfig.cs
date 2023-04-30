using CartCar.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace CartCar.App.Context.Config
{
    public class DrivingOffensesConfig : IEntityTypeConfiguration<DrivingOffenses>
    {
        public void Configure(EntityTypeBuilder<DrivingOffenses> builder)
        {
            builder.Ignore(p => p.Specialcharacters);
            builder.Property(p => p.DateDone)
                .HasConversion(p => DateIR_To_DateUTC((DateTime)p),p => DateUTC_To_DateIR(p));

        }

        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="DateIR">تاریخ شمسی</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime DateIR_To_DateUTC(DateTime DateIR)
        {
            return new DateTime(DateIR.Year, DateIR.Month, DateIR.Day, new PersianCalendar());
        }

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="DateUTC">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی</returns>
        public static DateTime DateUTC_To_DateIR(DateTime DateUTC)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(DateUTC.Year, DateUTC.Month, DateUTC.Day);
            return new DateTime(pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
        }
    }
}
