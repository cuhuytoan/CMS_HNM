using CMS.Data.ModelEntity;
using CMS.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IDbContextFactory<CmsContext> _cmsContext { get; set; }
        private IAccountRepository _accountRepository;
     
        private IAdvertisingRepository _advertisingRepository;

        private IProductCategoryRepository _productCategoryRepository;


        public RepositoryWrapper(IDbContextFactory<CmsContext> CmsContext)
        {
            _cmsContext = CmsContext;
        }

        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if (_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_cmsContext.CreateDbContext());
                }

                return _productCategoryRepository;
            }
        }

        public IAccountRepository AspNetUsers
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_cmsContext.CreateDbContext());
                }

                return _accountRepository;
            }
        }

        public IAdvertisingRepository Advertising
        {
            get
            {
                if (_advertisingRepository == null)
                {
                    _advertisingRepository = new AdvertisingRepository(_cmsContext.CreateDbContext());
                }

                return _advertisingRepository;
            }
        }


        public void Save()
        {
            using var CmsContext = _cmsContext.CreateDbContext();
            CmsContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            using var CmsContext = _cmsContext.CreateDbContext();
            return CmsContext.SaveChangesAsync();
        }
    }
}