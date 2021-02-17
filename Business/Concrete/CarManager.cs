using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icarDal;

        public CarManager(ICarDal icarDal)
        {
            _icarDal = icarDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _icarDal.Add(car);
                    Console.WriteLine("Ekleme Gerçekleştirildi.");
                }
                else
                {
                    Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalıdır!!");
                }
            }
            else
            {
                Console.WriteLine("Arabanın ismi minimum 2 karakter olmalıdır!!");
            }
        }

        public List<Car> GetAll()
        {
            return _icarDal.GetAll();
        }
        public List<Car> GetCarsById(int id)
        {
            return _icarDal.GetAll(c=>c.Id==id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _icarDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _icarDal.GetAll(c => c.ColorId == id);
        }

    }
}
