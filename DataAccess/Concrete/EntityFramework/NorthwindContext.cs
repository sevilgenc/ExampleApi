using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	//Context : Db tabloları ile proje classlarını bağlamak***************************************
	public class NorthwindContext : DbContext
	{
		// Veri Tabanı ilişkiliği**************************************************************
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
		}

		//Hangi class'ın hangi tabloya karşılık geleceğini ayarlıyoruz (örneğin; Product class'ımız Northwind de bulunan Products tablosuna)
		public DbSet<Product>  Products   { get; set; }
	}
}
