using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WNRY.Migrations.Migrations
{
    public partial class seedRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Ekatte = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Ekatte", "Name", "ShortName" },
                values: new object[,]
                {
                    { new Guid("3416c9e4-4c1c-4122-bf8a-8bb6428238f0"), "04279", "Благоевград", "BLG" },
                    { new Guid("f789d9ce-14cb-4271-b53c-70e947ba10d0"), "77195", "Хасково", "HKV" },
                    { new Guid("77908210-bb6e-46e0-a67b-07f364c927c1"), "73626", "Търговище", "TGV" },
                    { new Guid("8f7ce2f1-13f6-4d5b-bf75-1b26228fe1e2"), "68850", "Стара Загора", "SZR" },
                    { new Guid("8db99e27-7619-4888-a7c1-23e6683c7abb"), "68134", "София (столица)", "SOF" },
                    { new Guid("4ae4a323-2d80-4914-ace6-5ac625cfae88"), "68134", "София", "SFO" },
                    { new Guid("fe36831c-08e7-40aa-ba27-f1b3fdc56f3e"), "67653", "Смолян", "SML" },
                    { new Guid("3caba63e-c915-46e3-b650-6f5e41138aeb"), "67338", "Сливен", "SLV" },
                    { new Guid("469cd2d9-7069-4ea9-8059-1716a93c83d9"), "66425", "Силистра", "SLS" },
                    { new Guid("4a8b860d-7729-49d3-bf86-4dedcefcc6dd"), "63427", "Русе", "RSE" },
                    { new Guid("d5ac9c36-dbfa-48cb-ab67-2d5f24f59567"), "61710", "Разград", "RAZ" },
                    { new Guid("07d3c423-dcb5-47bb-98dd-08c6c8643e9c"), "56784", "Пловдив", "PDV" },
                    { new Guid("9273b9cc-2b5f-4070-9e7a-22eae3da1e85"), "56722", "Плевен", "PVN" },
                    { new Guid("fe2cdb44-7033-4b87-8b29-489502b26b49"), "55871", "Перник", "PER" },
                    { new Guid("c4c39bcb-ff7d-4db4-b78b-2fb6f8fcbab0"), "55155", "Пазарджик", "PAZ" },
                    { new Guid("799a2943-fbad-4312-823a-db258193e972"), "48489", "Монтана", "MON" },
                    { new Guid("6adfad40-9da8-4696-9938-84d1cb075c2a"), "43952", "Ловеч", "LOV" },
                    { new Guid("d258d6db-3f38-4666-a0e6-aefe1a92770d"), "41112", "Кюстендил", "KNL" },
                    { new Guid("2e12bc6b-c96b-4dd9-8ef1-1b6d3363e3f1"), "40909", "Кърджали", "KRZ" },
                    { new Guid("62d2f900-e7a4-46d9-9364-487bdc043e1d"), "72624", "Добрич", "DOB" },
                    { new Guid("3b6bfa7f-ed7c-4082-a448-83e8d7c34d36"), "14218", "Габрово", "GAB" },
                    { new Guid("9ab12245-f3db-43d1-94a4-a6201c6a10da"), "12259", "Враца", "VRC" },
                    { new Guid("bb0deaa4-104a-483d-9277-b1214388fc21"), "10971", "Видин", "VID" },
                    { new Guid("ed49ff1c-8d51-4ed3-b7c6-d3ccbbad0346"), "10447", "Велико Търново", "VTR" },
                    { new Guid("efa7be52-c722-4571-9a57-3c56a6dc5f2d"), "10135", "Варна", "VAR" },
                    { new Guid("80604f7a-59a9-420c-a256-9d9537369452"), "07079", "Бургас", "BGS" },
                    { new Guid("706af088-1fff-4dc1-a1bb-4f34763e1b42"), "83510", "Шумен", "SHU" },
                    { new Guid("b2d507b5-f621-4fc0-9bd2-c41ad2d73c2f"), "87374", "Ямбол", "JAM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
