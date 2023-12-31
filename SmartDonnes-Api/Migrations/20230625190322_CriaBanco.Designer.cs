﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDonnes_Api.Models;

#nullable disable

namespace SmartDonnes_Api.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20230625190322_CriaBanco")]
    partial class CriaBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartDonnes_Api.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("mesAno")
                        .HasColumnType("datetime2");

                    b.Property<string>("motivoAvaliacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("notaAvaliacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("SmartDonnes_Api.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataCliente")
                        .HasColumnType("datetime2");

                    b.Property<string>("PessoaContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SmartDonnes_Api.Models.ClienteAvaliacao", b =>
                {
                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "AvaliacaoId");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("ClientesAvaliacoes");
                });

            modelBuilder.Entity("SmartDonnes_Api.Models.Avaliacao", b =>
                {
                    b.HasOne("SmartDonnes_Api.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SmartDonnes_Api.Models.ClienteAvaliacao", b =>
                {
                    b.HasOne("SmartDonnes_Api.Models.Avaliacao", "Avaliacao")
                        .WithMany("clientesAvaliados")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartDonnes_Api.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Avaliacao");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SmartDonnes_Api.Models.Avaliacao", b =>
                {
                    b.Navigation("clientesAvaliados");
                });
#pragma warning restore 612, 618
        }
    }
}
