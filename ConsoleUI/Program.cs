using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserAdd();
            //UserDelete();
            //Rental rent1 = new Rental { CarId = 1, Id = 1, CustomerId = 1,
             //   RentDate = new DateTime(2019, 11, 10) };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(rent1);
            Rental rent2 = new Rental{CarId = 2,Id = 4,CustomerId = 1,RentDate = new DateTime(2019, 11, 10)};
            var result=rentalManager.Add(rent2);
            if (result.Success == false)
            {
                Console.WriteLine("Araba EKLENEMEDİ");
            }

            //rentalManager.Delete(rent2);
            //var result= rentalManager.GetRentalDetails().Data;
            //foreach (var rental in result)
            //{
            //    Console.WriteLine(rental.BrandName+"----"+rental.CustomerName+"---"+rental.DailyPrice);
            //}
            
            


        }

        private static void UserDelete()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user3 = new User { Id = 3, FirstName = "Karan", LastName = "Arslan", UserEmail = "arslan.halbrahim@gmail.com", UserPassword = "123476" };
            userManager.Add(user3);
            userManager.Delete(user3);
        }

        private static void UserAdd()
        {
            User user1 = new User { Id = 1, FirstName = "Halil", LastName = "Arslan", UserEmail = "arslan.halbrahim@gmail.com", UserPassword = "123476" };
            UserManager userManager = new UserManager(new EfUserDal());
            User user2 = new User { Id = 2, FirstName = "Harun", LastName = "Samancı", UserEmail = "samancı.harun@gmail.com", UserPassword = "143476" };

            userManager.Add(user1);
            userManager.Add(user2);
        }
    }
}
