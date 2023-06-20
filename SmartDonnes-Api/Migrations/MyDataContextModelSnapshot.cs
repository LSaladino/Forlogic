﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDonnes_Api;
using SmartDonnes_Api.Models;

#nullable disable

namespace SmartDonnes_Api.Migrations
{
    [DbContext(typeof(MyDataContext))]
    partial class MyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartDonnes_Api.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MesAnoRef")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotivoNota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("SmartDonnes_Api.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCliente")
                        .HasColumnType("datetime2");

                    b.Property<string>("PessoaContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SmartDonnes_Api.ClienteAvaliacao", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "AvaliacaoId");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("ClientesAvaliacoes");
                });

            modelBuilder.Entity("SmartDonnes_Api.ClienteAvaliacao", b =>
                {
                    b.HasOne("SmartDonnes_Api.Avaliacao", "Avaliacao")
                        .WithMany("ClienteAvaliacao")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartDonnes_Api.Cliente", "Cliente")
                        .WithMany("ClienteAvaliacao")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SmartDonnes_Api.Avaliacao", b =>
                {
                    b.Navigation("ClienteAvaliacao");
                });

            modelBuilder.Entity("SmartDonnes_Api.Cliente", b =>
                {
                    b.Navigation("ClienteAvaliacao");
                });
#pragma warning restore 612, 618
        }
    }
}
