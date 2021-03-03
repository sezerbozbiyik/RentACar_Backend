using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result !=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
            
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = CheckIfCarExists(id);
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            var newCarImage = CheckIfImageIsNull(id);
            if (newCarImage != null)
            {
                return new SuccessDataResult<List<CarImage>>(newCarImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(i => i.CarId == carImage.CarId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExceeded(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult("Limit resim sayısına ulaşıldı.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarExists(int id)
        {
            var result = _carService.GetCarsById(id);
            if (result.Data == null)
            {
                return new ErrorResult("Girilen id'ye ait araç bulunamadı.");
            }
            return null;
        }

        private List<CarImage> CheckIfImageIsNull(int id)
        {
            var path = Environment.CurrentDirectory + @"\Images\default.jpg";
            var result = _carImageDal.GetAll(i => i.CarId == id);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = id, Date = DateTime.Now, ImagePath = path } };
            }
            return result;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetImagesByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i=>i.CarImageId==id));
        }
    }
}
