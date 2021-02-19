using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandal;

        public BrandManager(IBrandDal brandal)
        {
            _brandal = brandal;
        }

        public void Delete(Brand brand)
        {
            _brandal.Delete(brand);
            Console.WriteLine(brand.BrandName + " Marka silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandal.GetAll();
        }

        public Brand GetByBrandId(int id)
        {
            return _brandal.Get(b=>b.BrandId==id);
        }

        public void Add(Brand brand)
        {
            _brandal.Add(brand);
            Console.WriteLine(brand.BrandName + " Marka eklendi.");
        }

        public void Update(Brand brand)
        {
            _brandal.Update(brand);
            Console.WriteLine(brand.BrandName + " Marka güncellendi.");
        }
    }
}
