using Mer1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Mer1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
         
        public DbSet<ItemTwoM> _item2M {  get; set; }
    }
}
