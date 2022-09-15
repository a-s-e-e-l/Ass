using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Quiz.Models
{
    public partial class RestaurantMenu
    {
        public int Id { get; set; }
        public int Rid { get; set; }
        public string MealName { get; set; }
        public double PriceInNis { get; set; }
        public double PriceInUsd { get; set; }
        public int Quantity { get; set; }
        [Timestamp]
        public DateTime CraetedDate { get; set; }
        [Timestamp]
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual Restaurant RidNavigation { get; set; }
    }
}
