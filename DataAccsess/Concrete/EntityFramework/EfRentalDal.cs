using Core.DataAccsess.EnitiyFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarsContext> , IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.Id equals b.BrandId
                             join customer in context.Customers on r.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto { 
                                 RentalId = r.RentalId,
                                 BrandName = b.BrandName, 
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate= r.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
