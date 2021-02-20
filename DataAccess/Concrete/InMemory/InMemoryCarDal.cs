using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

    //    public int BrandId { get; private set; }

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
             

                new Car { Id = 1, BrandId = 1, ColorId = 1,  CarName= "Toyota", ModelYear = 2020, DailyPrice = 100, Description = "Mercedes marka,üstü açık, 2020 Model, siyah araba" },
                new Car { Id = 2, BrandId = 1, ColorId = 2,  CarName= "Broadway", ModelYear = 2015, DailyPrice = 50, Description = "Mercedes marka, 2015 Model beyaz araba" },
                new Car {Id = 3,  BrandId = 2, ColorId = 1,  CarName= "Toyota", ModelYear = 2018, DailyPrice = 60, Description = "TOYOTA marka,2018 model, siyah araba" },
                new Car { Id = 4, BrandId = 2, ColorId = 2,  CarName= "Broadway", ModelYear = 2020, DailyPrice = 30, Description = "TOYOTA marka,2020 model,beyaz araba" },

            };
        }

        public InMemoryCarDal(List<Car> cars)
        {
            _cars = cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ -Language Integrated Query

            
                Car carToDelete = _cars.SingleOrDefault(c => car.Id == car.Id);
                _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün Id'sine sahip ürünü  bul
            Car carToDelete = _cars.SingleOrDefault(c => car.Id == car.Id);
            carToDelete.BrandId = car.BrandId;
            carToDelete.CarName = car.CarName;
            carToDelete.ColorId = car.ColorId;
            carToDelete.ModelYear = car.ModelYear;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;
        }

        public List<Car> GetAllByBrand( int brandId)
        {
           return _cars.Where(c => c.BrandId== brandId).ToList();
        }

        List<Car> ICarDal.GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        

    }
}
