using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyContext context = new MyContext();
            
           var builder = WebApplication.CreateBuilder(args);

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
            app.UseRouting();
            app.UseHttpsRedirection();
          
            app.UseAuthorization();

            app.MapControllers();

            app.Run(); 
        }
    }

    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
        [Required,StringLength(4)]
        public int Year { get; set; }
        public ICollection<Review> Reviews { get; } = new List<Review>();

        public Movie(string Title, int Year)
        {
            this.Title = Title;
            this.Year = Year;
        }
    }
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Director(string Name)
        {
            this.Name = Name;
        }
    }
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }

        public int MovieId {  get; set; }
        public Movie? Movie { get; set; }
        public DateTime CreatedAt { get; set; }

        public Review(int Rating, string Description, string UserName)
        {
            this.Rating = Rating;
            this.Description = Description;
            this.UserName = UserName;
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
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Nick\Desktop\WPFW\API\API\API_Db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


