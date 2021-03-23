using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarID = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarDescription = c.CarDescription
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int id)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in context.Cars
                             where c.BrandId==id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarID = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarDescription = c.CarDescription
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsByCarId(int id)
        {
            return GetCarDetails().Where(c => c.CarID == id).SingleOrDefault();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int id)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in context.Cars
                             where c.ColorId==id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarID = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarDescription = c.CarDescription
                             };
                return result.ToList();
            }
        }
    }
}
