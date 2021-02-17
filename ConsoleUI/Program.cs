using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----GetAll-----");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.CarDescription);
            }
            Console.WriteLine("--------GetCarsById----------");
            foreach (var c in carManager.GetCarsById(2))
            {
                Console.WriteLine(c.ModelYear);
            }
            Console.WriteLine("--------GetCarsByBrandId----------");
            foreach (var c in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(c.ColorId);
            }
            Console.WriteLine("--------GetCarsByColorId----------");
            foreach (var c in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(c.CarName);
            }
            Console.WriteLine("---------ADD---------");
            carManager.Add(new Car() { Id = 10, BrandId = 2, ColorId = 3, DailyPrice = 0, CarName = "F", CarDescription = "Arazi için", ModelYear = 2018 });
        }
    }
}
