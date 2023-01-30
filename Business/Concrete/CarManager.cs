using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal iCarDal)
        {
            _carDal = iCarDal;
        }
        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarCountOfBrand(car.BrandId)
              );
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        //[CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByAllBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByAllColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                _carDal.GetCarDetail().Where(c => c.BrandId == brandId).ToList());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfCarCountOfBrand(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
               _carDal.GetCarDetail().Where(c => c.ColorId == colorId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                 _carDal.GetCarDetail()
                 .Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }
    }
}
