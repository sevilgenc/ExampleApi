using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : IProductDal
	{
		public void Add(Product product)
		{
			// IDisposable pattern implemention of c# ( garbage collector beni hemen ram'den çıkar/sil)
			using (NorthwindContext context = new NorthwindContext())
			{
				var addedEntity = context.Entry(product);        /// Referansı yakala
				addedEntity.State = EntityState.Added;          ///  O eklenecek bir nesne
				context.SaveChanges();                          /// ve ekle  (3 satırın sırası ile anlamları.)
			}
		}

		public void Delete(Product product)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var deletedEntity = context.Entry(product);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Product Get(Expression<Func<Product, bool>> filter = null)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				return context.Set<Product>().SingleOrDefault(filter);
			}
		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				//Set<Product> context'timiz  NorthwindContext olduğu için product dediğimizde oradaki DbSet<product>'ta yerleşiyor.
				return filter == null
					? context.Set<Product>().ToList()
					: context.Set<Product>().Where(filter).ToList();
			}
		}

		public void Update(Product product)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var updatedEntity = context.Entry(product);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
