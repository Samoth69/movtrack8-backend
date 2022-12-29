﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using movtrack8_backend.Models;

#nullable disable

namespace movtrack8backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221229100858_constraint jackett id website id")]
    partial class constraintjackettidwebsiteid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("movtrack8_backend.Models.TEpisode", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<Instant?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<string>("DlLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("JackettId")
                        .HasColumnType("bigint");

                    b.Property<long>("OeuvreId")
                        .HasColumnType("bigint");

                    b.Property<Instant>("PubDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("WebsiteId")
                        .HasColumnType("bigint");

                    b.Property<string>("WebsiteLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("JackettId");

                    b.HasIndex("OeuvreId");

                    b.HasIndex("Title");

                    b.HasIndex("UpdatedAt");

                    b.HasIndex("WebsiteId");

                    b.HasIndex("WebsiteId", "JackettId")
                        .IsUnique();

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("movtrack8_backend.Models.TOeuvre", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<Instant?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("OeuvreRegex")
                        .HasColumnType("text");

                    b.Property<Instant?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Oeuvres");
                });

            modelBuilder.Entity("movtrack8_backend.Models.TWebsite", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<bool>("CloudFlareProtected")
                        .HasColumnType("boolean");

                    b.Property<Instant?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<Instant>("LastSuccessfulFetch")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MainAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RssAddress")
                        .HasColumnType("text");

                    b.Property<Instant?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WebsiteRegex")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("movtrack8_backend.Models.TEpisode", b =>
                {
                    b.HasOne("movtrack8_backend.Models.TOeuvre", "Oeuvre")
                        .WithMany("Episodes")
                        .HasForeignKey("OeuvreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movtrack8_backend.Models.TWebsite", "Website")
                        .WithMany("Episodes")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oeuvre");

                    b.Navigation("Website");
                });

            modelBuilder.Entity("movtrack8_backend.Models.TOeuvre", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("movtrack8_backend.Models.TWebsite", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
