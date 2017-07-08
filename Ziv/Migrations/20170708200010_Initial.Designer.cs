using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ziv.Models;

namespace Ziv.Migrations
{
    [DbContext(typeof(ZivContext))]
    [Migration("20170708200010_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ziv.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Weight");

                    b.HasKey("ID");

                    b.ToTable("Animal");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");
                });

            modelBuilder.Entity("Ziv.Models.Gorilla", b =>
                {
                    b.HasBaseType("Ziv.Models.Animal");

                    b.Property<int>("Age");

                    b.Property<string>("HairColor");

                    b.ToTable("Gorilla");

                    b.HasDiscriminator().HasValue("Gorillas");
                });

            modelBuilder.Entity("Ziv.Models.Parrot", b =>
                {
                    b.HasBaseType("Ziv.Models.Animal");

                    b.Property<bool>("CanTalk");

                    b.Property<string>("FeathersColor");

                    b.ToTable("Parrot");

                    b.HasDiscriminator().HasValue("Parrots");
                });

            modelBuilder.Entity("Ziv.Models.Shark", b =>
                {
                    b.HasBaseType("Ziv.Models.Animal");

                    b.Property<int>("AmountOfTeeth");

                    b.Property<bool>("NeedSaltWater");

                    b.Property<string>("SkinColor");

                    b.ToTable("Shark");

                    b.HasDiscriminator().HasValue("Sharks");
                });
        }
    }
}
