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
    public interface IAdvertisingRepository : IRepositoryBase<Advertising>
    {
       
    }

    public class AdvertisingRepository : RepositoryBase<Advertising>, IAdvertisingRepository
    {
        public AdvertisingRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

       
    }
}