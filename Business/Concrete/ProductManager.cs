using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void Add(Product product)
		{
			_productDal.Add(product);
		
		}

		public void Delete(int id)
		{
			Product product = new Product {ProductId=id };
			_productDal.Delete(product);
		}

		public List<Product> GetAll()
		{
			return _productDal.GetAll();
		}

		
		public Product GetById(int productId)
		{
			return _productDal.Get(p => p.ProductId == productId);  // predicate yapı
		}

		

		
	}
}


