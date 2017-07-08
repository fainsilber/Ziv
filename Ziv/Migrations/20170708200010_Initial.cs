using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ziv.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(maxLength: 7, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    CanTalk = table.Column<bool>(nullable: true),
                    FeathersColor = table.Column<string>(nullable: true),
                    AmountOfTeeth = table.Column<int>(nullable: true),
                    NeedSaltWater = table.Column<bool>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
