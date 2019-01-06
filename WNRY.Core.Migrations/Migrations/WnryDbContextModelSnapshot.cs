﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WNRY.Core.Data;

namespace WNRY.Migrations.Migrations
{
    [DbContext(typeof(WnryDbContext))]
    partial class WnryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WNRY.Models.CommonModels.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ekatte");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3416c9e4-4c1c-4122-bf8a-8bb6428238f0"),
                            Ekatte = "04279",
                            Name = "Благоевград",
                            ShortName = "BLG"
                        },
                        new
                        {
                            Id = new Guid("80604f7a-59a9-420c-a256-9d9537369452"),
                            Ekatte = "07079",
                            Name = "Бургас",
                            ShortName = "BGS"
                        },
                        new
                        {
                            Id = new Guid("efa7be52-c722-4571-9a57-3c56a6dc5f2d"),
                            Ekatte = "10135",
                            Name = "Варна",
                            ShortName = "VAR"
                        },
                        new
                        {
                            Id = new Guid("ed49ff1c-8d51-4ed3-b7c6-d3ccbbad0346"),
                            Ekatte = "10447",
                            Name = "Велико Търново",
                            ShortName = "VTR"
                        },
                        new
                        {
                            Id = new Guid("bb0deaa4-104a-483d-9277-b1214388fc21"),
                            Ekatte = "10971",
                            Name = "Видин",
                            ShortName = "VID"
                        },
                        new
                        {
                            Id = new Guid("9ab12245-f3db-43d1-94a4-a6201c6a10da"),
                            Ekatte = "12259",
                            Name = "Враца",
                            ShortName = "VRC"
                        },
                        new
                        {
                            Id = new Guid("3b6bfa7f-ed7c-4082-a448-83e8d7c34d36"),
                            Ekatte = "14218",
                            Name = "Габрово",
                            ShortName = "GAB"
                        },
                        new
                        {
                            Id = new Guid("62d2f900-e7a4-46d9-9364-487bdc043e1d"),
                            Ekatte = "72624",
                            Name = "Добрич",
                            ShortName = "DOB"
                        },
                        new
                        {
                            Id = new Guid("2e12bc6b-c96b-4dd9-8ef1-1b6d3363e3f1"),
                            Ekatte = "40909",
                            Name = "Кърджали",
                            ShortName = "KRZ"
                        },
                        new
                        {
                            Id = new Guid("d258d6db-3f38-4666-a0e6-aefe1a92770d"),
                            Ekatte = "41112",
                            Name = "Кюстендил",
                            ShortName = "KNL"
                        },
                        new
                        {
                            Id = new Guid("6adfad40-9da8-4696-9938-84d1cb075c2a"),
                            Ekatte = "43952",
                            Name = "Ловеч",
                            ShortName = "LOV"
                        },
                        new
                        {
                            Id = new Guid("799a2943-fbad-4312-823a-db258193e972"),
                            Ekatte = "48489",
                            Name = "Монтана",
                            ShortName = "MON"
                        },
                        new
                        {
                            Id = new Guid("c4c39bcb-ff7d-4db4-b78b-2fb6f8fcbab0"),
                            Ekatte = "55155",
                            Name = "Пазарджик",
                            ShortName = "PAZ"
                        },
                        new
                        {
                            Id = new Guid("fe2cdb44-7033-4b87-8b29-489502b26b49"),
                            Ekatte = "55871",
                            Name = "Перник",
                            ShortName = "PER"
                        },
                        new
                        {
                            Id = new Guid("9273b9cc-2b5f-4070-9e7a-22eae3da1e85"),
                            Ekatte = "56722",
                            Name = "Плевен",
                            ShortName = "PVN"
                        },
                        new
                        {
                            Id = new Guid("07d3c423-dcb5-47bb-98dd-08c6c8643e9c"),
                            Ekatte = "56784",
                            Name = "Пловдив",
                            ShortName = "PDV"
                        },
                        new
                        {
                            Id = new Guid("d5ac9c36-dbfa-48cb-ab67-2d5f24f59567"),
                            Ekatte = "61710",
                            Name = "Разград",
                            ShortName = "RAZ"
                        },
                        new
                        {
                            Id = new Guid("4a8b860d-7729-49d3-bf86-4dedcefcc6dd"),
                            Ekatte = "63427",
                            Name = "Русе",
                            ShortName = "RSE"
                        },
                        new
                        {
                            Id = new Guid("469cd2d9-7069-4ea9-8059-1716a93c83d9"),
                            Ekatte = "66425",
                            Name = "Силистра",
                            ShortName = "SLS"
                        },
                        new
                        {
                            Id = new Guid("3caba63e-c915-46e3-b650-6f5e41138aeb"),
                            Ekatte = "67338",
                            Name = "Сливен",
                            ShortName = "SLV"
                        },
                        new
                        {
                            Id = new Guid("fe36831c-08e7-40aa-ba27-f1b3fdc56f3e"),
                            Ekatte = "67653",
                            Name = "Смолян",
                            ShortName = "SML"
                        },
                        new
                        {
                            Id = new Guid("4ae4a323-2d80-4914-ace6-5ac625cfae88"),
                            Ekatte = "68134",
                            Name = "София",
                            ShortName = "SFO"
                        },
                        new
                        {
                            Id = new Guid("8db99e27-7619-4888-a7c1-23e6683c7abb"),
                            Ekatte = "68134",
                            Name = "София (столица)",
                            ShortName = "SOF"
                        },
                        new
                        {
                            Id = new Guid("8f7ce2f1-13f6-4d5b-bf75-1b26228fe1e2"),
                            Ekatte = "68850",
                            Name = "Стара Загора",
                            ShortName = "SZR"
                        },
                        new
                        {
                            Id = new Guid("77908210-bb6e-46e0-a67b-07f364c927c1"),
                            Ekatte = "73626",
                            Name = "Търговище",
                            ShortName = "TGV"
                        },
                        new
                        {
                            Id = new Guid("f789d9ce-14cb-4271-b53c-70e947ba10d0"),
                            Ekatte = "77195",
                            Name = "Хасково",
                            ShortName = "HKV"
                        },
                        new
                        {
                            Id = new Guid("706af088-1fff-4dc1-a1bb-4f34763e1b42"),
                            Ekatte = "83510",
                            Name = "Шумен",
                            ShortName = "SHU"
                        },
                        new
                        {
                            Id = new Guid("b2d507b5-f621-4fc0-9bd2-c41ad2d73c2f"),
                            Ekatte = "87374",
                            Name = "Ямбол",
                            ShortName = "JAM"
                        });
                });

            modelBuilder.Entity("WNRY.Models.IdentityModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WNRY.Models.IdentityModels.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<long?>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WNRY.Models.IdentityModels.Customer", b =>
                {
                    b.HasOne("WNRY.Models.IdentityModels.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });
#pragma warning restore 612, 618
        }
    }
}
