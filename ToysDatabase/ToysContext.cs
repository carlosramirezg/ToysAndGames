using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ToysApi.Models;

namespace ToysDatabase
{
	public class ToysContext : DbContext
	{
		public ToysContext(DbContextOptions<ToysContext> options): base(options)
		{
			if(!this.Toys.Any())
				LoadToys();
		}
		public DbSet<Toy> Toys { get; set; }

		public void LoadToys()
		{
			this.Add(new Toy { Id = 1, Name = "GI Joe", AgeRestriction = 10, Company = "Hasbro", Description = "GI Joe", Price = 30 });
			this.Add(new Toy { Id = 2, Name = "Barbie", AgeRestriction = 7, Company = "Mattel", Description = "Barbie", Price = 50 });
			this.Add(new Toy { Id = 3, Name = "Playstation", AgeRestriction = 5, Company = "Sony", Description = "Playstation", Price = 500 });
			this.Add(new Toy { Id = 4, Name = "Xbox", AgeRestriction = 4, Company = "Microsoft", Description = "Xbox", Price = 400 });
			this.Add(new Toy { Id = 5, Name = "Soccer ball", AgeRestriction = 2, Company = "Nike", Description = "Soccer ball", Price = 20 });
			this.Add(new Toy { Id = 6, Name = "Tablet", AgeRestriction = 10, Company = "Samsung", Description = "Tablet", Price = 200 });
			this.SaveChanges();
		}
	}
}
