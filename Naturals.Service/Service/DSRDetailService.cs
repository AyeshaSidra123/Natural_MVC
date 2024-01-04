using Natural.Core.IServices;
using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naturals.Service.Service
{
    public class DSRDetailService : IDsrDetailsService
    {
        private readonly IHttpClientWrapper _HttpCleintWrapper;

        public DSRDetailService(IHttpClientWrapper httpCleintWrapper)
        {
            _HttpCleintWrapper = httpCleintWrapper;
        }
        public async Task<DSRDetailsModel> CreateDSRDetails(DSRDetailsModel dsr)
        {
            var result = await _HttpCleintWrapper.PostAsync<DSRDetailsModel>("/DsrDetail/", dsr);
            return result;
        }

        public async Task<List<DSRDetailsModel>> GetDsrDetailsAll()
        {
            var response = await _HttpCleintWrapper.GetAsync<List<DSRDetailsModel>>("/DsrDetail/");
            return response;
        }
    }
}
