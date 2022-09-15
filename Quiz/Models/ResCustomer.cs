using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Quiz.Models
{
    public partial class ResCustomer
    {
        public int Id { get; set; }
        public int Rid { get; set; }
        public int Cid { get; set; }
        [Timestamp]
        public DateTime CraetedDate { get; set; }
        [Timestamp]
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual Customer CidNavigation { get; set; }
        public virtual RestaurantMenu RidNavigation { get; set; }
    }
}
