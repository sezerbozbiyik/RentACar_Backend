using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("-----GetAll-----");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("-----GetById-----");
            foreach (var c in carManager.GetById(new int[] {1,2}))
            {
                Console.WriteLine(c.Description);
            }
        }
    }
}
