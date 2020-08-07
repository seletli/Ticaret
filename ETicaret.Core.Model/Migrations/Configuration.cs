namespace ETicaret.Core.Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ETicaret.Core.Model.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<ETicaret.Core.Model.Entity.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationsDataLossAllowed = true;
        }

        public bool AutomaticMigrationsDataLossAllowed { get; }

        protected override void Seed(ETicaret.Core.Model.Entity.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Status> defaultStatuses = new List<Status>();
            List<User> defaultUser = new List<User>();

            defaultStatuses.Add(new Status
            {
                Name = "Ödeme Bekliyor",
                ID = 1,
                CreateUserID = 1
              
            }) ;
            defaultStatuses.Add(new Status
            {
                Name = "Ürünler Hazırlanıyor",
                ID = 3,
                CreateUserID = 1

            });
            defaultStatuses.Add(new Status
            {
                Name = "Kargoda",
                ID = 4,
                CreateUserID = 1

            });
            defaultStatuses.Add(new Status
            {
                Name = "Teslim Edildi",
                ID = 5,
                CreateUserID = 1

            });
            defaultStatuses.Add(new Status
            {
                Name = "Ödeme Kontrolü Bekliyor",
                ID = 12,
                CreateUserID = 1

            });

            defaultUser.Add(new User
            {
                ID = 1,
                Name = "Samet",
                LastName = "S",
                Email = "samet@gmail.com",
                Telephone = "1",
                Password = "1",
                TCKN = "1",
                IsActive = true,
                IsAdmin = true,
                CreateDate = DateTime.Now,
                CreateUserID = 1,



            });


        }
    }
}
