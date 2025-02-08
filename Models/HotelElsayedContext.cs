﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElSayedHotel.Models;

public partial class HotelElsayedContext : IdentityDbContext<ApplicationUser>
{
    public HotelElsayedContext()
    {
    }

    public HotelElsayedContext(DbContextOptions<HotelElsayedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }
     
    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillNumber).HasName("PK__Bill__C4BBE0C7B6A9ACAD");

            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.Total).HasDefaultValue(0.0);

            entity.HasOne(d => d.Guest).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__GuestId__4CA06362");

            entity.HasOne(d => d.ReservationNumberNavigation).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__Reservatio__4BAC3F29");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__0C423C12E8623CD2");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationNumber).HasName("PK__Reservat__FAA69AEADC809201");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Guest__3F466844");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Reservations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RoomN__403A8C7D");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("PK__Room__AE10E07B607B7DE1");

            entity.Property(e => e.RoomNumber).ValueGeneratedNever();
            entity.Property(e => e.Available).HasDefaultValue(true);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Rooms).HasConstraintName("FK__Room__Type__3C69FB99");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomType1).HasName("PK__RoomType__3A76E8C27BC59CB5");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB00A07EC4D23");
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => new { e.ServiceId, e.ReservationNumber }).HasName("PK__ServiceO__7AB1D9A43C930B00");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ReservationNumberNavigation).WithMany(p => p.ServiceOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Reser__46E78A0C");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Servi__45F365D3");
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}