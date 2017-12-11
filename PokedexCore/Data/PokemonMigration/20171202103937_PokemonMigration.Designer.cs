﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PokedexCore.Data;
using System;

namespace PokedexCore.Data.PokemonMigration
{
    [DbContext(typeof(PokemonDbContext))]
    [Migration("20171202103937_PokemonMigration")]
    partial class PokemonMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokedexCore.Models.FavoritePokemons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AspNetUserId");

                    b.Property<string>("SelectedPokemons");

                    b.HasKey("Id");

                    b.ToTable("FavoritePokemons");
                });
#pragma warning restore 612, 618
        }
    }
}