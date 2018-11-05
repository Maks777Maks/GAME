namespace DAL
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<Player>Players { get; set; }


    }

    
}