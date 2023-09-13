﻿namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public bool HasDelievery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }


    }
}