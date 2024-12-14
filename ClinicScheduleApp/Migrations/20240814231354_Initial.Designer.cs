﻿// <auto-generated />
using System;
using ClinicScheduleApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicScheduleApp.Migrations
{
    [DbContext(typeof(ClinicScheduleDbContext))]
    [Migration("20240814231354_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicSchedule.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateTime?>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppointmentType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            AppointmentDate = new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "InPerson",
                            PatientName = "Groucho Marx",
                            ScheduleId = 1
                        },
                        new
                        {
                            AppointmentId = 2,
                            AppointmentDate = new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "InPerson",
                            PatientName = "Harpo Marx",
                            ScheduleId = 1
                        },
                        new
                        {
                            AppointmentId = 3,
                            AppointmentDate = new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "InPerson",
                            PatientName = "Chico Marx",
                            ScheduleId = 2
                        },
                        new
                        {
                            AppointmentId = 4,
                            AppointmentDate = new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "InPerson",
                            PatientName = "Zeppo Marx",
                            ScheduleId = 2
                        },
                        new
                        {
                            AppointmentId = 5,
                            AppointmentDate = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "InPerson",
                            PatientName = "Gummo Marx",
                            ScheduleId = 2
                        },
                        new
                        {
                            AppointmentId = 6,
                            AppointmentDate = new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Video",
                            PatientName = "John Lennon",
                            ScheduleId = 1
                        },
                        new
                        {
                            AppointmentId = 7,
                            AppointmentDate = new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Phone",
                            PatientName = "Paul McCartney",
                            ScheduleId = 1
                        },
                        new
                        {
                            AppointmentId = 8,
                            AppointmentDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Phone",
                            PatientName = "George Harrison",
                            ScheduleId = 2
                        },
                        new
                        {
                            AppointmentId = 9,
                            AppointmentDate = new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Video",
                            PatientName = "Ringo Starr",
                            ScheduleId = 2
                        },
                        new
                        {
                            AppointmentId = 10,
                            AppointmentDate = new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Phone",
                            PatientName = "Roberto",
                            ScheduleId = 1
                        },
                        new
                        {
                            AppointmentId = 11,
                            AppointmentDate = new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentType = "Phone",
                            PatientName = "Groucho Marx",
                            ScheduleId = 1
                        });
                });

            modelBuilder.Entity("ClinicSchedule.Entities.Clinician", b =>
                {
                    b.Property<int>("ClinicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicianId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessionalRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("ClinicianId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Clinicians");

                    b.HasData(
                        new
                        {
                            ClinicianId = 1,
                            FirstName = "Bart",
                            LastName = "Simpson",
                            ProfessionalRegistrationNumber = "ADF-173456",
                            ScheduleId = 1
                        },
                        new
                        {
                            ClinicianId = 2,
                            FirstName = "Lisa",
                            LastName = "Simpson",
                            ProfessionalRegistrationNumber = "DAB-997768",
                            ScheduleId = 1
                        },
                        new
                        {
                            ClinicianId = 3,
                            FirstName = "Maggie",
                            LastName = "Simpson",
                            ProfessionalRegistrationNumber = "FGK-874559",
                            ScheduleId = 2
                        },
                        new
                        {
                            ClinicianId = 4,
                            FirstName = "Marge",
                            LastName = "Simpson",
                            ProfessionalRegistrationNumber = "LMP-114092",
                            ScheduleId = 2
                        },
                        new
                        {
                            ClinicianId = 5,
                            FirstName = "Homer",
                            LastName = "Simpson",
                            ProfessionalRegistrationNumber = "ZCH-575930",
                            ScheduleId = 2
                        });
                });

            modelBuilder.Entity("ClinicSchedule.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            ScheduleId = 1,
                            DateCreated = new DateTime(2024, 8, 14, 19, 13, 54, 489, DateTimeKind.Local).AddTicks(525),
                            Name = "Main Street clinic schedule"
                        },
                        new
                        {
                            ScheduleId = 2,
                            DateCreated = new DateTime(2024, 8, 14, 19, 13, 54, 489, DateTimeKind.Local).AddTicks(565),
                            Name = "Surrey street clinic schedule"
                        });
                });

            modelBuilder.Entity("ClinicScheduleApp.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClinicSchedule.Entities.Appointment", b =>
                {
                    b.HasOne("ClinicSchedule.Entities.Schedule", "Schedule")
                        .WithMany("Appointments")
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ClinicSchedule.Entities.Clinician", b =>
                {
                    b.HasOne("ClinicSchedule.Entities.Schedule", "Schedule")
                        .WithMany("Clinicians")
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClinicScheduleApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClinicScheduleApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicScheduleApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClinicScheduleApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicSchedule.Entities.Schedule", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Clinicians");
                });
#pragma warning restore 612, 618
        }
    }
}
