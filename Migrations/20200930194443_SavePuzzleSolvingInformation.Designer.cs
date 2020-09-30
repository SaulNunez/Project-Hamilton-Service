﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectHamiltonService.Models;

namespace ProjectHamiltonService.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20200930194443_SavePuzzleSolvingInformation")]
    partial class SavePuzzleSolvingInformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectHamiltonService.Models.Items", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("PlayersId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Prototype")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlayersId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Lobbies", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime");

                    b.Property<bool>("OnProgress")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Players")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Code");

                    b.HasIndex("Players")
                        .IsUnique();

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Players", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("AvailableMoves")
                        .HasColumnType("int");

                    b.Property<int>("Bravery")
                        .HasColumnType("int");

                    b.Property<string>("CharacterPrototypeId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Floor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("LobbyId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Physical")
                        .HasColumnType("int");

                    b.Property<int>("Sanity")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Y")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CharacterPrototypeId")
                        .IsUnique();

                    b.HasIndex("LobbyId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Puzzles", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("PlayersId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("PuzzleEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("PuzzlePrototype")
                        .HasColumnType("text");

                    b.Property<DateTime>("PuzzleStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime");

                    b.Property<bool>("SolvedCorrectly")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Puzzles");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Rooms", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("LobbyId")
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("PlayerActionAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("RoomProtoype")
                        .HasColumnType("text");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Items", b =>
                {
                    b.HasOne("ProjectHamiltonService.Models.Players", "Player")
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Lobbies", b =>
                {
                    b.HasOne("ProjectHamiltonService.Models.Players", "CurrentPlayer")
                        .WithOne("Lobby")
                        .HasForeignKey("ProjectHamiltonService.Models.Lobbies", "Players");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Rooms", b =>
                {
                    b.HasOne("ProjectHamiltonService.Models.Lobbies", "Lobby")
                        .WithMany()
                        .HasForeignKey("LobbyId");
                });
#pragma warning restore 612, 618
        }
    }
}
