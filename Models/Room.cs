﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElSayedHotel.Models;

[Table("Room")]
public partial class Room
{
    [Key]
    public int RoomNumber { get; set; }

    public double Price { get; set; }

    public bool Available { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    public int Type { get; set; }

    [InverseProperty("RoomNumberNavigation")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [ForeignKey("Type")]
    [InverseProperty("Rooms")]
    public virtual RoomType TypeNavigation { get; set; }
}