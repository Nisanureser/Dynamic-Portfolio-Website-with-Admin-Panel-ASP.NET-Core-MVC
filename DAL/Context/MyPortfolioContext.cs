using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Entities;
using Reference = MyPortfolioUdemy.DAL.Entities.Reference;

namespace MyPortfolioUdemy.DAL.Context
{
    public class MyPortfolioContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HBN2KAH\\SQLEXPRESS;Initial Catalog=MyPortfolioDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Reference> References { get; set; }
        


    }
}
