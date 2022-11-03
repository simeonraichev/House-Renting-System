﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastructure.Data
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(2000)]
        [Column(TypeName= "money")]
        [Precision(18,2)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId{ get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; }

        public string? RenterId { get; set; }

        [ForeignKey(nameof(Renter))]
        public IdentityUser? Renter{ get; set; }
    }
}
