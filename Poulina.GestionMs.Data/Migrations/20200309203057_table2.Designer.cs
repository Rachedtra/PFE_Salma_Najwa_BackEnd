﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poulina.GestionMs.Data;

namespace Poulina.GestionMs.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200309203057_table2")]
    partial class table2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Categorie", b =>
                {
                    b.Property<Guid>("IdCategorie")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<Guid?>("demandesIdInf");

                    b.HasKey("IdCategorie");

                    b.HasIndex("demandesIdInf");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Info", b =>
                {
                    b.Property<Guid>("IdCinfo");

                    b.Property<Guid>("IdCom");

                    b.Property<Guid?>("IdInf");

                    b.HasKey("IdCinfo");

                    b.HasIndex("IdCom");

                    b.ToTable("Comm_Info");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Vote", b =>
                {
                    b.Property<Guid>("IdCVote");

                    b.Property<Guid?>("IdCom");

                    b.Property<Guid?>("IdVote");

                    b.HasKey("IdCVote");

                    b.HasIndex("IdCom");

                    b.ToTable("Comm_Vote");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Commentaire", b =>
                {
                    b.Property<Guid>("IdCom")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("IdCom");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Dem_Categorie", b =>
                {
                    b.Property<Guid?>("IdCateg");

                    b.Property<Guid>("IdCategorie");

                    b.Property<Guid>("IdInf");

                    b.HasKey("IdCateg");

                    b.HasAlternateKey("IdCategorie");

                    b.HasIndex("IdInf");

                    b.ToTable("Dem_Categorie");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Demande_information", b =>
                {
                    b.Property<Guid>("IdInf")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.HasKey("IdInf");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Vote", b =>
                {
                    b.Property<Guid>("IdVote")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Note");

                    b.HasKey("IdVote");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.sous_categorie", b =>
                {
                    b.Property<Guid>("IdSC")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategorieFK");

                    b.Property<string>("Label");

                    b.HasKey("IdSC");

                    b.HasIndex("CategorieFK");

                    b.ToTable("Sous_Categories");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Categorie", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Demande_information", "demandes")
                        .WithMany()
                        .HasForeignKey("demandesIdInf");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Info", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Demande_information", "Demande")
                        .WithMany("Comm_Infos")
                        .HasForeignKey("IdCinfo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poulina.GestionMs.Domain.Models.Commentaire", "Commentaires")
                        .WithMany("Comm_Infos")
                        .HasForeignKey("IdCom")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Vote", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Vote", "Votes")
                        .WithMany("Comm_Votes")
                        .HasForeignKey("IdCVote")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poulina.GestionMs.Domain.Models.Commentaire", "Commentaires")
                        .WithMany("Comm_Votes")
                        .HasForeignKey("IdCom");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Dem_Categorie", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Categorie", "Categories")
                        .WithMany("Dem_Categories")
                        .HasForeignKey("IdCateg")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poulina.GestionMs.Domain.Models.Demande_information", "Demandes")
                        .WithMany("Dem_Categories")
                        .HasForeignKey("IdInf")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.sous_categorie", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Categorie", "Categorie")
                        .WithMany("Sous_categories")
                        .HasForeignKey("CategorieFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
