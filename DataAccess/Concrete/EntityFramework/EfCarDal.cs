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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext reCapProjectContext=new ReCapProjectContext())
            {
                var result = from c in reCapProjectContext.Cars
                             join b in reCapProjectContext.Brands
                             on c.BrandId equals b.BrandId
                             join color in reCapProjectContext.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto { CarName = c.CarName, BrandName = b.BrandName,
                                 ColorName = color.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();

            }
        }
    }
}
