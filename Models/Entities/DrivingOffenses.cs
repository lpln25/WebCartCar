using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartCar.App.Models.Entities
{
    /// <summary>
    /// تخلفات رانندگی
    /// </summary>
    public class DrivingOffenses : TagCar
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "محل وقوع")]
        public string Location { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime? DateDone { get; set; }
        [Display(Name ="کد جریمه")]
        public long Code { get; set; }
        [Display(Name = "مبلغ")]
        public long Price { get; set; }
        /// <summary>
        /// حرف پلاک
        /// </summary>
        public readonly List<string> Specialcharacters = new List<string>()
        {
            "ب",
            "ج",
            "د",
            "س",
            "ص",
            "ط",
            "ق",
            "ل",
            "م",
            "ن",
            "و",
            "ه",
            "ی",
            "الف",
            "پ",
            "ت",
            "ث",
            "ز",
            "ژ",
            "ش",
            "ع",
            "ف",
            "ک",
            "گ",
            "D",
            "S"
        };

    }
}
