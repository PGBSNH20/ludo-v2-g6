﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi.Services;

namespace RestApi.Migrations
{
    [DbContext(typeof(LudoContext))]
    [Migration("20210517122257_db2")]
    partial class db2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestApi.Models.GameBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GameBoards");
                });

            modelBuilder.Entity("RestApi.Models.GamePiece", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentPosition")
                        .HasColumnType("int");

                    b.Property<Guid?>("GamePlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsInGoal")
                        .HasColumnType("bit");

                    b.Property<int>("StartingPosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.ToTable("GamePieces");
                });

            modelBuilder.Entity("RestApi.Models.GamePlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<Guid?>("GameBoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPlayersTurn")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("RestApi.Models.GamePiece", b =>
                {
                    b.HasOne("RestApi.Models.GamePlayer", null)
                        .WithMany("GamePieces")
                        .HasForeignKey("GamePlayerId");
                });

            modelBuilder.Entity("RestApi.Models.GamePlayer", b =>
                {
                    b.HasOne("RestApi.Models.GameBoard", null)
                        .WithMany("GamePlayer")
                        .HasForeignKey("GameBoardId");
                });

            modelBuilder.Entity("RestApi.Models.GameBoard", b =>
                {
                    b.Navigation("GamePlayer");
                });

            modelBuilder.Entity("RestApi.Models.GamePlayer", b =>
                {
                    b.Navigation("GamePieces");
                });
#pragma warning restore 612, 618
        }
    }
}
