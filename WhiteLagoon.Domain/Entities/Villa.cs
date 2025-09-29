﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Common;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa : BaseEntity
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Price per night")]
        [Range(10, 10000)]
        public double Price { get; set; }

        public int Sqft { get; set; }

        [Range(1, 10)]
        public int Occupancy { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
    }
}
