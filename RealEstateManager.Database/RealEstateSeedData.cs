using System;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Database
{
    public static class RealEstateSeedData
    {
        public static void EnsureSeedData(this RealEstateContext db)
        {
            if (!db.Properties.Any() || !db.Payments.Any())
            {
                var properties = new List<Property>
                {
                    new Property
                    {
                         Name = "Big House",
                         City = "Pune",
                         Street = "Baner",
                         Family = "Shingares",
                         Value = 10000000,
                         Payments = new List<Payment>()
                         {
                             new Payment()
                             {
                                  DateCreated = DateTime.Now,
                                  DateOverdue = DateTime.Now.AddYears(5),
                                  Paid = true,
                                  Value = 15000000
                             }
                         }
                    }
                };

                db.Properties.AddRange(properties);
                db.SaveChanges();
            }

        }
    }
}

