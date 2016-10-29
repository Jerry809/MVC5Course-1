using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(x=>x.IsDeleted == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(x => x.ProductId == id);
        }

        public IQueryable<Product> Get所有資料_依據ProductId排序(int takeSize)
        {
            return this.All().OrderBy(x => x.ProductId).Take(takeSize);
        }

        public override void Delete(Product product)
        {
            product.IsDeleted = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}