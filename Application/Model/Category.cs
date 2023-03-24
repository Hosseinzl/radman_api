﻿namespace Application.Model
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public int productCounts { get; set; }
        public int? predefinedCategoryType { get; set; }
    }
}
