using Microsoft.EntityFrameworkCore;
using ShoppingApp.API.Models;

namespace ShoppingApp.API.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    }
}