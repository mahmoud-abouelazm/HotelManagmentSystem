﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElSayedHotel.Models;

[Table("Bill")]
public partial class Bill
{
    [Key]
    public int BillNumber { get; set; }

    public int ReservationNumber { get; set; }

    [Required]
    [StringLength(25)]
    public string GuestId { get; set; }

    public double? Total { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public bool? IsPaid { get; set; }

    [ForeignKey("GuestId")]
    [InverseProperty("Bills")]
    public virtual Guest Guest { get; set; }

    [ForeignKey("ReservationNumber")]
    [InverseProperty("Bills")]
    public virtual Reservation ReservationNumberNavigation { get; set; }
}