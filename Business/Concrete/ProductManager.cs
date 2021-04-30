using Business.Abstract;
using Business.Constants;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(ErrorMessages.ProductNameInvalid);
            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult(SuccessMessages.ProductAdded);
            }
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new Result(true);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var t = DateTime.Now.Hour;
            if (t == 10)
            {
                return new ErrorDataResult<List<Product>>(ErrorMessages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), SuccessMessages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id), SuccessMessages.ProductListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), SuccessMessages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {

            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(ErrorMessages.MaintenanceTime);

            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new Result(true);
        }
    }
}
