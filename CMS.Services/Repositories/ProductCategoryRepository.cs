using CMS.Common;
using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        Task<List<ProductCategory>> ProductCategoriesGetLstByParentId(int parentId);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

        public async Task<List<ProductCategory>> ProductCategoriesGetLstByParentId(int parentId)
        {
            List<ProductCategory> lstOutput = new();
            try
            {
                lstOutput = await CmsContext.ProductCategory.Where(x => x.ParentId == parentId).ToListAsync();
            }
            catch
            {

            }
            return lstOutput;
        }
    }
}
