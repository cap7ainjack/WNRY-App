using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WNRY.Models.CommonModels;
using WNRY.Models.Enums;
using WNRY.Models.IdentityModels;

namespace WNRY.Core.Data
{
    public class WnryDbContext : IdentityDbContext
    {
        public WnryDbContext(DbContextOptions<WnryDbContext> options)
            : base(options)
        {
        }

        // public DbSet<Customer> Customers { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ContactDetails> ContactsDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<XRefOrderProducts> XRefOrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().HasData(new Region { Name = "Благоевград", Ekatte = "04279", ShortName = "BLG", Id = new Guid("3416C9E4-4C1C-4122-BF8A-8BB6428238F0") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Бургас", Ekatte = "07079", ShortName = "BGS", Id = new Guid("80604F7A-59A9-420C-A256-9D9537369452") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Варна", Ekatte = "10135", ShortName = "VAR", Id = new Guid("EFA7BE52-C722-4571-9A57-3C56A6DC5F2D") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Велико Търново", Ekatte = "10447", ShortName = "VTR", Id = new Guid("ED49FF1C-8D51-4ED3-B7C6-D3CCBBAD0346") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Видин", Ekatte = "10971", ShortName = "VID", Id = new Guid("BB0DEAA4-104A-483D-9277-B1214388FC21") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Враца", Ekatte = "12259", ShortName = "VRC", Id = new Guid("9AB12245-F3DB-43D1-94A4-A6201C6A10DA") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Габрово", Ekatte = "14218", ShortName = "GAB", Id = new Guid("3B6BFA7F-ED7C-4082-A448-83E8D7C34D36") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Добрич", Ekatte = "72624", ShortName = "DOB", Id = new Guid("62D2F900-E7A4-46D9-9364-487BDC043E1D") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Кърджали", Ekatte = "40909", ShortName = "KRZ", Id = new Guid("2E12BC6B-C96B-4DD9-8EF1-1B6D3363E3F1") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Кюстендил", Ekatte = "41112", ShortName = "KNL", Id = new Guid("D258D6DB-3F38-4666-A0E6-AEFE1A92770D") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Ловеч", Ekatte = "43952", ShortName = "LOV", Id = new Guid("6ADFAD40-9DA8-4696-9938-84D1CB075C2A") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Монтана", Ekatte = "48489", ShortName = "MON", Id = new Guid("799A2943-FBAD-4312-823A-DB258193E972") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Пазарджик", Ekatte = "55155", ShortName = "PAZ", Id = new Guid("C4C39BCB-FF7D-4DB4-B78B-2FB6F8FCBAB0") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Перник", Ekatte = "55871", ShortName = "PER", Id = new Guid("FE2CDB44-7033-4B87-8B29-489502B26B49") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Плевен", Ekatte = "56722", ShortName = "PVN", Id = new Guid("9273B9CC-2B5F-4070-9E7A-22EAE3DA1E85") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Пловдив", Ekatte = "56784", ShortName = "PDV", Id = new Guid("07D3C423-DCB5-47BB-98DD-08C6C8643E9C") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Разград", Ekatte = "61710", ShortName = "RAZ", Id = new Guid("D5AC9C36-DBFA-48CB-AB67-2D5F24F59567") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Русе", Ekatte = "63427", ShortName = "RSE", Id = new Guid("4A8B860D-7729-49D3-BF86-4DEDCEFCC6DD") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Силистра", Ekatte = "66425", ShortName = "SLS", Id = new Guid("469CD2D9-7069-4EA9-8059-1716A93C83D9") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Сливен", Ekatte = "67338", ShortName = "SLV", Id = new Guid("3CABA63E-C915-46E3-B650-6F5E41138AEB") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Смолян", Ekatte = "67653", ShortName = "SML", Id = new Guid("FE36831C-08E7-40AA-BA27-F1B3FDC56F3E") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "София", Ekatte = "68134", ShortName = "SFO", Id = new Guid("4AE4A323-2D80-4914-ACE6-5AC625CFAE88") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "София (столица)", Ekatte = "68134", ShortName = "SOF", Id = new Guid("8DB99E27-7619-4888-A7C1-23E6683C7ABB") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Стара Загора", Ekatte = "68850", ShortName = "SZR", Id = new Guid("8F7CE2F1-13F6-4D5B-BF75-1B26228FE1E2") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Търговище", Ekatte = "73626", ShortName = "TGV", Id = new Guid("77908210-BB6E-46E0-A67B-07F364C927C1") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Хасково", Ekatte = "77195", ShortName = "HKV", Id = new Guid("F789D9CE-14CB-4271-B53C-70E947BA10D0") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Шумен", Ekatte = "83510", ShortName = "SHU", Id = new Guid("706AF088-1FFF-4DC1-A1BB-4F34763E1B42") });
            modelBuilder.Entity<Region>().HasData(new Region { Name = "Ямбол", Ekatte = "87374", ShortName = "JAM", Id = new Guid("B2D507B5-F621-4FC0-9BD2-C41AD2D73C2F") });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Kind = WineKind.Merlot,
                WineColor = WineColor.Red,
                Size = 0.7,
                BottleKind = BottleKind.Glass,
                PhotoUrl = "https://i.ibb.co/ckmdNgN/5.jpg",
                Price = 11m,
                Description = "Description here...",
                Id = new Guid("C51E8CE1-C6CC-4F08-86BD-E5016EFA00BF"),
                DisplayName = "Мерло",
                Weight = 1.1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Kind = WineKind.CabernetSauvignon,
                WineColor = WineColor.Red,
                Size = 0.7,
                BottleKind = BottleKind.Glass,
                PhotoUrl = "https://i.ibb.co/1bdMmvp/cabernet-resized.jpg",
                Price = 11m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Id = new Guid("FBDEB80E-8348-4233-99B7-0C79780398AA"),
                DisplayName = "Каберне Совиньон",
                Weight = 1.1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Kind = WineKind.Rose,
                WineColor = WineColor.Rose,
                Size = 0.7,
                BottleKind = BottleKind.Glass,
                PhotoUrl = "https://i.ibb.co/gghGqWM/rose-resized.jpg",
                Price = 9m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Id = new Guid("32E90A4A-9955-42F6-B172-12296CDEE653"),
                DisplayName = "Розе",
                Weight = 1.1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Kind = WineKind.Chardonnay,
                WineColor = WineColor.White,
                Size = 0.7,
                BottleKind = BottleKind.Glass,
                PhotoUrl = "https://i.ibb.co/sbgkKjH/Chardonnay-resized.jpg",
                Price = 9m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Id = new Guid("FF8FFE32-2E84-4C4F-9205-49794FBDF5B7"),
                DisplayName = "Шардоне",
                Weight = 1.1
            });

        }
    }
}