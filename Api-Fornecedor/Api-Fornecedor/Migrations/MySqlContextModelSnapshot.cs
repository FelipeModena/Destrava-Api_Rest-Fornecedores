﻿// <auto-generated />
using System;
using ApiRestComASPNet.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Fornecedor.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Api_Fornecedor.Model.Empresas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Cnpj")
                        .HasColumnType("longtext")
                        .HasColumnName("empresas_cnpj");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Api_Fornecedor.Model.Fornecedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Cnpj")
                        .HasColumnType("longtext")
                        .HasColumnName("cnpj");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<long?>("EmpresasId")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("longtext")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("longtext")
                        .HasColumnName("razao_social");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EmpresasId");

                    b.ToTable("fornecedor");
                });

            modelBuilder.Entity("Api_Fornecedor.Model.LogDesenvolvedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_time");

                    b.Property<string>("Error")
                        .HasColumnType("longtext")
                        .HasColumnName("error");

                    b.HasKey("Id");

                    b.ToTable("log_desenvolvedor");
                });

            modelBuilder.Entity("Api_Fornecedor.Model.Fornecedor", b =>
                {
                    b.HasOne("Api_Fornecedor.Model.Empresas", "Empresas")
                        .WithMany("Fornecedores")
                        .HasForeignKey("EmpresasId");

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("Api_Fornecedor.Model.Empresas", b =>
                {
                    b.Navigation("Fornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
