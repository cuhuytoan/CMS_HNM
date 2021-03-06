using CMS.Services.Repositories;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AspNetUsers { get; }
    
        IAdvertisingRepository Advertising { get; }
      
        IProductCategoryRepository ProductCategory { get; }

        void Save();

        Task<int> SaveChangesAsync();
    }
}