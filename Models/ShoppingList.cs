using System;
using System.Collections.Generic;

namespace ShoppingApp.API.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<ShoppingListItem> Items { get; set; }
    }
}