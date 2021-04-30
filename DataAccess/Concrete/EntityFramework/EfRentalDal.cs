using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext reCapProjectContext=new ReCapProjectContext())
            {
                var result = from rnt in filter is null ? reCapProjectContext.Rentals : reCapProjectContext.Rentals.Where(filter)
                             join c in reCapProjectContext.Cars
                             on rnt.CarId equals c.Id
                             join customer in reCapProjectContext.Customers
                             on rnt.CustomerId equals customer.Id
                             join b in reCapProjectContext.Brands
                             on c.BrandId equals b.BrandId
                             join color in reCapProjectContext.Colors
                             on c.ColorId equals color.ColorId
                             join user in reCapProjectContext.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = color.ColorName,
                                 CustomerName = user.FirstName + user.LastName,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate,
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList();

                           
                            
                            

                            




            }
        }
    }
}
