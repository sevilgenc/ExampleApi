using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetAll();
		Product GetById(int productId);
		void Add(Product product);
		void Delete(int id);
	}
}
