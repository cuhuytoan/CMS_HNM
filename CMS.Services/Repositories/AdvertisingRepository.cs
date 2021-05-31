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
        Task<List<AdvertisingBlock>> AdvertisingBlocksGetAll();

        Task<List<AdvertisingBlockDetail>> AdvertisingBlockDetailsGetByBlockId(int adBlockId);

        
        
    }

    public class AdvertisingRepository : RepositoryBase<Advertising>, IAdvertisingRepository
    {
        public AdvertisingRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

        public async Task<List<AdvertisingBlockDetail>> AdvertisingBlockDetailsGetByBlockId(int adBlockId)
        {
            List<AdvertisingBlockDetail> lstOutPut = new();
            try
            {
                lstOutPut = await CmsContext.AdvertisingBlockDetail.Where(x => x.AdBlockId == adBlockId).ToListAsync();
            }
            catch
            {

            }
            return lstOutPut;
        }

        public async Task<List<AdvertisingBlock>> AdvertisingBlocksGetAll()
        {
            List<AdvertisingBlock> lstOutPut = new();
            try
            {
                lstOutPut = await CmsContext.AdvertisingBlock.Where(x => x.AdvertisingBlockId >= 20).ToListAsync();
            }
            catch
            {

            }
            return lstOutPut;
        }
    }
}