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

        public List<Car> GetAll()
        {
            return _icarDal.GetAll();
        }
        public List<Car> GetById(int[] id)
        {
            return _icarDal.GetById(id);
        }
    }
}
