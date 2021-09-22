﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Razor.Models;

namespace WebAPI_Razor.Migrations
{
    [DbContext(typeof(ComidaDBContext))]
    partial class ComidaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI_Razor.Models.ComidaModel", b =>
                {
                    b.Property<int>("ComidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calorias")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoComidaId")
                        .HasColumnType("int");

                    b.HasKey("ComidaId");

                    b.HasIndex("TipoComidaId");

                    b.ToTable("Comidas");
                });

            modelBuilder.Entity("WebAPI_Razor.Models.PersonaModel", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComidaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.HasKey("PersonaId");

                    b.HasIndex("ComidaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("WebAPI_Razor.Models.TipoComidaModel", b =>
                {
                    b.Property<int>("TipoComidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoComidaId");

                    b.ToTable("TipoComidas");
                });

            modelBuilder.Entity("WebAPI_Razor.Models.ComidaModel", b =>
                {
                    b.HasOne("WebAPI_Razor.Models.TipoComidaModel", "TipoComida")
                        .WithMany()
                        .HasForeignKey("TipoComidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoComida");
                });

            modelBuilder.Entity("WebAPI_Razor.Models.PersonaModel", b =>
                {
                    b.HasOne("WebAPI_Razor.Models.ComidaModel", "Comida")
                        .WithMany()
                        .HasForeignKey("ComidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comida");
                });
#pragma warning restore 612, 618
        }
    }
}
