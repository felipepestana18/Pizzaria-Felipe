﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzaria.PizzaAPI.Model.Context;

#nullable disable

namespace Pizzaria.PedidoAPI.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20230323150541_FixIdCliente")]
    partial class FixIdCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pizzaria.PedidoAPI.Model.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("QtdBebidas")
                        .HasColumnType("int");

                    b.Property<int>("QtdPedido")
                        .HasColumnType("int");

                    b.Property<int>("QtdPizza")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPedido")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Pizzaria.PedidoAPI.Model.PedidoBebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdBebida")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PedidoBebidas");
                });

            modelBuilder.Entity("Pizzaria.PedidoAPI.Model.PedidoPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdPizza")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PedidoPizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
