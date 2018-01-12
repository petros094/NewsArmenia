namespace NewsProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=ModelConnection")
        {
        }
        public virtual DbSet<News> New { get; set; }

   
    }
}
