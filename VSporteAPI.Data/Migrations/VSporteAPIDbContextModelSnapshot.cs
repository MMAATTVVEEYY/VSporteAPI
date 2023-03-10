// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VSporteAPI.Data;

#nullable disable

namespace VSporteAPI.Data.Migrations
{
    [DbContext(typeof(VSporteAPIDbContext))]
    partial class VSporteAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VSporteAPI.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("VSporteAPI.Entities.MatchEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("integer");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("MatchTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchEvents");
                });

            modelBuilder.Entity("VSporteAPI.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronym")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("VSporteAPI.Entities.PlayerClub", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<int>("ClubId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.HasKey("PlayerId", "ClubId");

                    b.HasIndex("ClubId");

                    b.ToTable("PlayerClubs");
                });

            modelBuilder.Entity("VSporteAPI.Entities.MatchEvent", b =>
                {
                    b.HasOne("VSporteAPI.Entities.Player", null)
                        .WithMany("MatchEvents")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("VSporteAPI.Entities.PlayerClub", b =>
                {
                    b.HasOne("VSporteAPI.Entities.Club", "Club")
                        .WithMany("PlayerClubs")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSporteAPI.Entities.Player", "Player")
                        .WithMany("PlayerClubs")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("VSporteAPI.Entities.Club", b =>
                {
                    b.Navigation("PlayerClubs");
                });

            modelBuilder.Entity("VSporteAPI.Entities.Player", b =>
                {
                    b.Navigation("MatchEvents");

                    b.Navigation("PlayerClubs");
                });
#pragma warning restore 612, 618
        }
    }
}
