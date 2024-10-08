﻿// <auto-generated />
using System;
using AspNetCoreWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCoreWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240820114925_BancoAtualizado")]
    partial class BancoAtualizado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("AspNetCoreWebApp.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.FavoritoModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataHora")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.ItemPedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Quantidade")
                        .HasColumnType("REAL");

                    b.Property<decimal?>("ValorUnitario")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataHoraPedido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("ValorTotal")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Estoque")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Preco")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.VisitadoModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataHora")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("Visitados");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.ClienteModel", b =>
                {
                    b.OwnsOne("AspNetCoreWebApp.Models.EnderecoModel", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteModelIdCliente")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.HasKey("ClienteModelIdCliente");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteModelIdCliente");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.FavoritoModel", b =>
                {
                    b.HasOne("AspNetCoreWebApp.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreWebApp.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.ItemPedidoModel", b =>
                {
                    b.HasOne("AspNetCoreWebApp.Models.PedidoModel", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreWebApp.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.PedidoModel", b =>
                {
                    b.HasOne("AspNetCoreWebApp.Models.ClienteModel", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AspNetCoreWebApp.Models.EnderecoModel", "Endereco", b1 =>
                        {
                            b1.Property<int>("PedidoModelIdPedido")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.HasKey("PedidoModelIdPedido");

                            b1.ToTable("Pedidos");

                            b1.WithOwner()
                                .HasForeignKey("PedidoModelIdPedido");
                        });

                    b.Navigation("Cliente");

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.VisitadoModel", b =>
                {
                    b.HasOne("AspNetCoreWebApp.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreWebApp.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("AspNetCoreWebApp.Models.PedidoModel", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
