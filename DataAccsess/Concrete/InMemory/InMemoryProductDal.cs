using DataAccsess.Abstract;
using Entities.Concrete;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car> {

                new Car { BrandId = 1, CarId = 1, Description = "GT-R R35", ColorId = 50, DailyPrice = 100000 },
                new Car { BrandId = 2, CarId = 2, Description = "Z4 sDrive30i", ColorId = 50, DailyPrice = 1000000 },
                new Car { BrandId = 3, CarId = 3, Description = "A5 Sportback", ColorId = 200, DailyPrice = 150000 },
                new Car { BrandId = 4, CarId = 4, Description = "Model S 75D", ColorId = 30, DailyPrice = 250000 },
                new Car { BrandId = 4, CarId = 5, Description = "MODEL S P90D", ColorId = 10, DailyPrice = 500500 }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId= car.ColorId;   
            carToUpdate.Description = car.Description;  
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;  
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }
    }
}
