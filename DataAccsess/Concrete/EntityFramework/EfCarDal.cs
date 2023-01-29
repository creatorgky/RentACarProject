using Core.DataAccsess.EnitiyFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.Cars 
                             join b in context.Brands on c.BrandId equals b.BrandId                                                  
                             join co in context.Colors on c.ColorId equals co.ColorId 
                select new CarDetailDto {
                    CarId = c.Id,
                    ColorId= c.ColorId,
                    BrandId= c.BrandId,
                    BrandName = b.BrandName, 
                    ColorName = co.ColorName,
                    ModelYear = c.ModelYear,
                    DailyPrice = c.DailyPrice, 
                    Description = c.Description };
                return result.ToList();
            }
        }
    }
}
