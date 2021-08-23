using FluentValidation;
using InventoryManagementApplication.Business.Abstract;
using InventoryManagementApplication.Business.BusinessAspects.Autofac;
using InventoryManagementApplication.Business.Constants;
using InventoryManagementApplication.Business.ValidationRules.FluentValidation;
using InventoryManagementApplication.Core.Aspects.Autofac.Validation;
using InventoryManagementApplication.Core.CrossCuttingConcerns.Validation.FluentValidation;
using InventoryManagementApplication.Core.Utilities.Business;
using InventoryManagementApplication.Core.Utilities.Results;
using InventoryManagementApplication.DataAccess.Abstract;
using InventoryManagementApplication.Entities.Concrete;
using InventoryManagementApplication.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(
            //    ChechIfProductCountOfCategoryCorrect(product.CategoryId),
            //    CheckIfProductNameExists(product.ProductName),
            //    ChechIfCategoryLimitExceded()
            //);
            
            //if(result != null)
            //{
            //    return result;
            //}

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(
                ChechIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),
                ChechIfCategoryLimitExceded()
            );
            if (result != null)
            {
                return result;
            }

            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(i => i.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.UnitPrice >= minPrice && i.UnitPrice <= maxPrice));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        private IResult ChechIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 2)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult ChechIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count;

            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
    }
}
