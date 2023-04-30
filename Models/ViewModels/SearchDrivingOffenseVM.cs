using CartCar.App.Models.Entities;

namespace CartCar.App.Models.ViewModels
{
    public class SearchDrivingOffenseVM
    {
        /// <summary>
        /// جنبه نمایشی دارد
        /// </summary>
        public Cartcar Cartcar { get; set; } = new Cartcar();
        /// <summary>
        /// جنبه نمایشی دارد
        /// </summary>
        public InfractionCar InfractionCar { get; set; } = new InfractionCar();
        public DrivingOffenses drivingOffenses { get; set; } = new DrivingOffenses();
        public List<DrivingOffenses> ResultSearchDrivingOffenses { get; set; } = new List<DrivingOffenses>();
    }
}
