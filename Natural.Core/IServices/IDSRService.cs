﻿using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natural.Core.IServices
{
   public  interface IDSRService
    {
        Task<DsrDisplay> GetDsrAll();
        Task<DSRModel> CreateDsr(DSRModel dsr);
        Task<List<DsrDistributor>> AssignedDistributorDetailsByExecutiveId(string Id);
        Task<List<DsrRetailor>> GetAssignedRetailorDetailsByDistributorId(string DistributorId);
        Task<List<DsrProduct>> GetProductAsync();
        Task<Dsrcreate> CreateDsr();
        Task<Dsrcreate> UpdateSession(Dsrcreate ExistingSession, Dsrcreate UpadeSession);
        Task<List<DsrProduct>> SearchProductsAsync(Dsrcreate ExistingSession, Dsrcreate UpadeSession);
        Task<ProductResponse> Insert(Dsrcreate ExistingSession);

    }
}
