using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EnterLeftDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using(EnterLeftDbContext context = new EnterLeftDbContext())
            {
                var result = from p in context.Product
                             join c in context.Categories on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto
                             { 
                                 ProductID = p.ProductID,
                                 ProductName= p.ProductName,
                                 CategoryName =c.CategoryName
                             };

                return result.ToList();
            }
        }
    }
}
