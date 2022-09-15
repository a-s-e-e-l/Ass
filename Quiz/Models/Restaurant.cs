using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Quiz.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantMenus = new HashSet<RestaurantMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Timestamp]
        public DateTime CraetedDate { get; set; }
        [Timestamp]
        public DateTime UpdatedDate { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<RestaurantMenu> RestaurantMenus { get; set; }
    }
}
