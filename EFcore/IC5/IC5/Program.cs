using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Windows.Markup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

    public class Program
    {
        public static void Main(string[] args)
        {
            MyContext context = new MyContext();

            /* var builder = WebApplication.CreateBuilder(args);

             // Add services to the container.

             builder.Services.AddControllers();
             // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
             builder.Services.AddEndpointsApiExplorer();
             builder.Services.AddSwaggerGen();

             var app = builder.Build();

             // Configure the HTTP request pipeline.
             if (app.Environment.IsDevelopment())
             {
                 app.UseSwagger();
                 app.UseSwaggerUI();
             }

             app.UseHttpsRedirection();

             app.UseAuthorization();

             app.MapControllers();

             app.Run(); */
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int Year { get; set; }
        public ICollection<Review> Reviews { get; } = new List<Review>();

        public Movie(string title, int year)
        {
            Title = title;
            Year = year;
        }
    }
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Director(string name)
        {
            Name = name;
        }
    }
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public DateTime CreatedAt { get; set; }

        public Review(int rating, string description, string username)
        {
            Rating = rating;
            Description = description;
            UserName = username;
            CreatedAt = DateTime.Now;
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<Review> Review { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Director> Director { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"C:\Users\Nick\Desktop\WPFW\API\API\API_Db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    
}
