using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Core.Entities.Concrete;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            //CustomerTest()
            //UserTest();
            //RentalTest();

        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("-----Add-----");
            var result = customerManager.Add(new Customer
            {
                Id = 6,
                CompanyName = "Vural a.ş.",
                UserId = 2,
            });
            Console.WriteLine(result.Message);

            Console.WriteLine("-----Update---- -");
            var result1 = customerManager.Update(new Customer
            {
                Id = 6,
                CompanyName = "Vural a.ş.",
                UserId = 5,
            });
            Console.WriteLine(result1.Message);

            Console.WriteLine("-----Delete-----");
            var result2 = customerManager.Delete(new Customer
            {
                Id = 6,
                CompanyName = "Vural a.ş.",
                UserId = 5,
            });
            Console.WriteLine(result2.Message);
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5)
            });
            Console.WriteLine(result.Message);
        }

        private static void UserTest()
        {
            Console.WriteLine("-----Add-----");
            UserManager userManager = new UserManager(new EfUserDal());
            var result1 = userManager.Add(new User { Id=7,FirstName = "sezer", LastName = "bozbıyık", Email = "sezerb@gmail.com",});
            Console.WriteLine(result1.Message);
        }

        private static void ColorTest()
        {
            Console.WriteLine("-----GetAll-----");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Id + " - " + color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("-----Add-----");
            var result1 = colorManager.Add(new Color
            {
                Id = 7,
                ColorName = "Eflatun"
            });
            Console.WriteLine(result1.Message);

            Console.WriteLine("-----Update-----");
            var result2 = colorManager.Update(new Color
            {
                Id = 7,
                ColorName = "Mor"
            });
            Console.WriteLine(result2.Message);

            Console.WriteLine("-----Delete-----");
            var result3 = colorManager.Delete(new Color
            {
                Id = 7,
                ColorName = "Mor"
            });
            Console.WriteLine(result3.Message);
        }

        private static void BrandTest()
        {
            Console.WriteLine("-----GetAll-----");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var b in result.Data)
                {
                    Console.WriteLine(b.Id+" "+b.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }          

            Console.WriteLine("-----GetByID-----");
            var resultId = brandManager.GetByBrandId(3);
            Console.WriteLine("Id = 3 olan marka: " + resultId.Data.BrandName);

            Console.WriteLine("-----Add-----");
            var result1 = brandManager.Add(new Brand
            {
                Id = 7,
                BrandName = "BMW"
            });
            Console.WriteLine(result1.Message);

            Console.WriteLine("-----Update-----");
            var result2 = brandManager.Update(new Brand
            {
                Id = 7,
                BrandName = "Mercedes"
            });
            Console.WriteLine(result2.Message);

            Console.WriteLine("-----Delete-----");
            var result3 = brandManager.Delete(new Brand
            {
                Id = 7,
                BrandName = "Mercedes"
            });
            Console.WriteLine(result3.Message);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----GetAll-----");
            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarDescription);
                }
            }
            Console.WriteLine(result.Message);
            
            Console.WriteLine("--------GetCarsById----------");
            Console.WriteLine(carManager.GetCarsById(2).Data.CarName);
            
            Console.WriteLine("--------GetCarsByBrandId----------");
            foreach (var c in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(c.ColorId);
            }
            Console.WriteLine("--------GetCarsByColorId----------");
            foreach (var c in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(c.CarName);
            }
            Console.WriteLine("---------ADD---------");
            var result1 = carManager.Add(new Car()
            {
                Id = 10,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 950,
                CarName = "F",
                CarDescription = "Arazi için",
                ModelYear = 2018
            });
            if (result.Success==true)
            {
                Console.WriteLine(result1.Message);
            }
            else
            {
                Console.WriteLine(result1.Message);
            }

            Console.WriteLine("------GetDetail-------");
            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.BrandName + " - " + c.CarName + " - " + c.ColorName + " - " + c.DailyPrice);
            }
        }
    }
}
