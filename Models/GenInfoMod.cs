﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyCarbonFootprintCalculator;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyCarbonFootprintCalculator.Models
{
    public class GenInfoMod
    {
        private string _pword;
        
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }      
        [AllowNull]
        //[MaxLength(50, ErrorMessage = "More than 50 characters")]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        //[MaxLength(5, ErrorMessage = "More than 5 digits")]
        public int ZipCode { get; set; }
        [AllowNull]
        public int AnnualIncome { get; set; } 
    }
}
