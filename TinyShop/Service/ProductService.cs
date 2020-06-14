using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Service
{
    public ProductDO Update(ProductDO product)
    {
        var productExists:bool= _context.Set<ProductDO>().Any(t: ProductDO => t.Id = product.Id);
        if (!productExists)
        {
            throw new Exception("没有找到指定 ID的产品记录");
        }
        _context.Set<ProductDO>().Updata(product);
        _Context.SaveChanges();
        return product;
    }
    public void Delete(long id) {

        var product = _context.Set<ProductD0>().First0rDefault(t: ProductDO = t.Id = id);

        if (product = null)

            throw new Exception("没有找到指定 ID的产品记录");
        context.Set<ProductD0>().Remove(product);

        context.SaveChanges();
    }

    class ProductService
    {
        private readonly DataContext_context;
            public ProductService(DataContext context)
        {
            _context = context;
        }
        public ProductDO Inset(ProductDO product)
        {
            _context.Set<ProductDO>().Add(product);
            _context.SaveChanges();

            return product;
        }
        public IEnumerable<ProductDO> GetAll()
        {
            return _context.Set<ProductDO>();
        }
    }
}
