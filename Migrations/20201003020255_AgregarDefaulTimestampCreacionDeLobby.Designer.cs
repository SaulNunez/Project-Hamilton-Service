﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectHamiltonService.Models;

namespace ProjectHamiltonService.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20201003020255_AgregarDefaulTimestampCreacionDeLobby")]
    partial class AgregarDefaulTimestampCreacionDeLobby
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProjectHamiltonService.Models.Items", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uuid");

                    b.Property<string>("Prototype")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlayersId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Lobbies", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("OnProgress")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("Players")
                        .HasColumnType("uuid");

                    b.HasKey("Code");

                    b.HasIndex("Players")
                        .IsUnique();

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Players", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableMoves")
                        .HasColumnType("integer");

                    b.Property<int>("Bravery")
                        .HasColumnType("integer");

                    b.Property<string>("CharacterPrototypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("LobbyId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Physical")
                        .HasColumnType("integer");

                    b.Property<int>("Sanity")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Y")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PuzzleEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PuzzlePrototype")
                        .HasColumnType("text");

                    b.Property<DateTime>("PuzzleStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("SolvedCorrectly")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Puzzles");
                });

            modelBuilder.Entity("ProjectHamiltonService.Models.Rooms", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("LobbyId")
                        .HasColumnType("text");

                    b.Property<bool>("PlayerActionAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("RoomProtoype")
                        .HasColumnType("text");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

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
