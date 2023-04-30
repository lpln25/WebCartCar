using CartCar.App.Context;
using CartCar.App.Models.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CartCar.App.Models.Services
{
    public interface IDrivingOffenseService
    {
        public Cartcar SearchTagCarToCartcar(string p1, Specialcharacters p2, string p3, string p4);
        public InfractionCar SearchInfractioncar(long code);
    }

    public class DrivingOffenseService : IDrivingOffenseService
    {
        private readonly DatabaseContext _db;
        public DrivingOffenseService(DatabaseContext db)
        {
            _db = db;
        }

        public InfractionCar SearchInfractioncar(long code)
        {
            //long cd = 0;
            //try
            //{ cd = Convert.ToInt64(code); }
            //catch { }
            return _db.infractionCars.SingleOrDefault(c =>
            c.Code == code);
        }

        public Cartcar SearchTagCarToCartcar(string p1, Specialcharacters p2, string p3, string p4)
        {
            var result = _db.cartcars.SingleOrDefault(c =>
            c.Part1 == p1
            && c.Part2 == p2
            && c.Part3 == p3
            && c.Part4 == p4);

            return result ?? new Cartcar();

        }
    }
}
