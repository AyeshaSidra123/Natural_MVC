using Natural.Core.IServices;
using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naturals.Service.Service
{
    public class DsrService : IDsrService
    {
        private readonly IHttpClientWrapper _HttpCleintWrapper;
        private readonly IUnifiedService _unifiedService;

        public DsrService(IHttpClientWrapper httpCleintWrapper, IUnifiedService unifiedService)
        {
            _HttpCleintWrapper = httpCleintWrapper;
            _unifiedService = unifiedService;
        }

        public async Task<List<DsrModel>> GetDsrAll()
        {
            var response = await _HttpCleintWrapper.GetAsync<List<DsrModel>>("/Dsr/");
            return response;
        }
        public async Task<DsrModel> CreateDsr(DsrModel dsr)
        {
            
            var result = await _HttpCleintWrapper.PostAsync<DsrModel>("/AssignDistributorToExecutive", dsr);

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;

            }

            var resul = await _HttpCleintWrapper.PostAsync<DsrModel>("/AssignRetailorToDistributor", dsr);


            if (resul != null)
            {
                return resul;
            }
            else
            {
                return null;
            }
             
          
        }
      
    }
}

