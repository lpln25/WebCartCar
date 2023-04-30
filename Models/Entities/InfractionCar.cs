using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartCar.App.Models.Entities
{
    /// <summary>
    /// تخلفات
    /// </summary>
    public class InfractionCar
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "کد جریمه")]
        public long Code { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(1500)]
        public string Infraction { get; set; }
        [Display(Name = "قیمت گروه1")]
        public long Price1 { get; set; }
        [Display(Name = "قیمت گروه2")]
        public long Price2 { get; set; }
        [Display(Name = "قیمت گروه3")]
        public long Price3 { get; set; }


    }
}
