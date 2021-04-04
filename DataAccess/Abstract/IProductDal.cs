
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IProductDal 
	{
		List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
		Product Get(Expression<Func<Product, bool>> filter = null);
		void Add(Product entity);
		void Update(Product entity);
		void Delete(Product entity);
	}
}
