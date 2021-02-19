using Business.Concrete;
using DataAccess.Abstract;
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
            //CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            Console.WriteLine("-----GetAll-----");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " - " + color.ColorName);
            }

            Console.WriteLine("-----Add-----");
            colorManager.Add(new Color
            {
                ColorId = 7,
                ColorName = "Eflatun"
            });

            Console.WriteLine("-----Update-----");
            colorManager.Update(new Color
            {
                ColorId = 7,
                ColorName = "Mor"
            });

            Console.WriteLine("-----Delete-----");
            colorManager.Delete(new Color
            {
                ColorId = 7,
                ColorName = "Mor"
            });
        }

        private static void BrandTest()
        {
            Console.WriteLine("-----GetAll-----");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine(b.BrandName);
            }

            Console.WriteLine("-----GetByID-----");
            Console.WriteLine("Id = 3 olan marka: " + (brandManager.GetByBrandId(3)).BrandName);

            Console.WriteLine("-----Add-----");
            brandManager.Add(new Brand
            {
                BrandId=7,
                BrandName="BMW"
            });
            
            Console.WriteLine("-----Update-----");
            brandManager.Update(new Brand
            {
                BrandId = 7,
                BrandName = "Mercedes"
            });
            Console.WriteLine("-----Delete-----");
            brandManager.Delete(new Brand
            {
                BrandId = 7,
                BrandName = "Mercedes"
            });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----GetAll-----");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.CarDescription);
            }
            Console.WriteLine("--------GetCarsById----------");
            Console.WriteLine((carManager.GetCarsById(2)).CarName);
            
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
            carManager.Add(new Car()
            {
                Id = 10,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 0,
                CarName = "F",
                CarDescription = "Arazi için",
                ModelYear = 2018
            });
            Console.WriteLine("------GetDetail-------");
            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.BrandName + " - " + c.CarName + " - " + c.ColorName + " - " + c.DailyPrice);
            }
        }
    }
}
