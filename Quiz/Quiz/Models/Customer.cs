using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Quiz.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Timestamp]
        public DateTime CraetedDate { get; set; }
        [Timestamp]
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }
    }
}
