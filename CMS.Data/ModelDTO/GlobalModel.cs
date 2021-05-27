using CMS.Data.ModelEntity;
using System.Collections.Generic;
using System.Security.Claims;

namespace CMS.Data.ModelDTO
{
    public class GlobalModel
    {
        public int? totalUnread { get; set; }        
        public string avatar { get; set; } = "noimages.png";
        public ClaimsPrincipal user { get; set; }
        public string userId { get; set; }
    }
}