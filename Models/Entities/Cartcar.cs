using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartCar.App.Models.Entities
{
    /// <summary>
    /// کارت ماشین
    /// </summary>
    public class Cartcar : TagCar
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "نام مالک")]
        public string OwnerName { get; set; }
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name = "نام پدر/نماینده سازمان")]
        public string Fathername { get; set; }
        [Display(Name = "VIN")]
        public string VIN { get; set; }
        [Display(Name = "نوع")]
        public string ModelCar { get; set; }
        [Display(Name = "سیستم")]
        public string SystemCar { get; set; }
        [Display(Name = "تیپ")]
        public string Tip { get; set; }
        [Display(Name = "رنگ")]
        public string Color { get; set; }
        [Display(Name = "مدل")]
        public string DateCreated { get; set; }
        [Display(Name = "سوخت")]
        public SpecialFuelType FuelType { get; set; }
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
        /// <summary>
        /// نوع سوخت
        /// </summary>
        public readonly List<string> SpecialFuelTypes = new List<string>()
        {
            "بنزین",
            "گازوییل",
            "اتانول",
            "گاز نفت",
            "گاز طبیعی",
            "زیستی",
            "هیدروژن"
        };
        [Display(Name = "ظرفیت")]
        public byte Copacity { get; set; }
        [Display(Name = "شماره موتور")]
        public string EngineNumber { get; set; }
        [Display(Name = "شماره شاسی")]
        public string ChassisNumber { get; set; }
        [Display(Name = "شماره مسلسل")]
        public string SerialNumber { get; set; }

        //public static string Specialcharacters_ToString(Specialcharacters specialcharacters)
        //{
        //    return Enum.GetName(typeof(Specialcharacters), specialcharacters);
        //}
    }

    /// <summary>
    /// حروف تخصصی پلاک
    /// </summary>
    public enum Specialcharacters
    {
        ب = 0,
        ج,
        د,
        س,
        ص,
        ط,
        ق,
        ل,
        م,
        ن,
        و,
        ه,
        ی,
        الف,
        پ,
        ت,
        ث,
        ز,
        ژ,
        ش,
        ع,
        ف,
        ک,
        گ,
        D,
        S
    }

    /// <summary>
    /// نوع سوخت
    /// </summary>
    public enum SpecialFuelType
    {
        بنزین = 0,
        گازوییل,
        اتانول,
        گازنفت,
        گازطبیعی,
        زیستی,
        هیدروژن
    }

    /// <summary>
    /// پلاک خودرو
    /// </summary>
    public abstract class TagCar
    {
        [Display(Name = "دو رقمی")]
        public string Part1 { get; set; }
        [Display(Name = "حرف")]
        public Specialcharacters Part2 { get; set; }
        [Display(Name = "سه رقمی")]
        public string Part3 { get; set; }
        [Display(Name = "دو رقمی ناحیه")]
        public string Part4 { get; set; }
    }
}
