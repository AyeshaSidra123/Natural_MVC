using NatDMS.Models;
using Natural.Core.IServices;
using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naturals.Service.Service
{

    public class UnifiedService :IUnifiedService
    {

        private readonly IHttpClientWrapper _httpClientWrapper;

        public UnifiedService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }
        public async Task<List<StateModel>> GetStates()
        {
            return await _httpClientWrapper.GetAsync<List<StateModel>>("/State/");
        }
        public async Task<List<CityModel>> GetCitiesbyStateId(string stateId)
        {
            return await _httpClientWrapper.GetByIdAsync<List<CityModel>>("/City", stateId);
        }

        public async Task<List<AreaModel>> GetAreasByCityId(string cityId)
        {
            return await _httpClientWrapper.GetByIdAsync<List<AreaModel>>("/Area", cityId);
        }

        public async Task<List<ExecutiveModel>> GetExecutives()
        {
            return await _httpClientWrapper.GetAsync<List<ExecutiveModel>>("/Executive/");
        }

        public async Task<List<DistributorToExecutive>> GetDistributorsByExecutiveId(string executiveId)
        {
            return await _httpClientWrapper.GetByIdAsync<List<DistributorToExecutive>>("/AssignDistributorToExecutive", executiveId);
        }

        public async Task<List<RetailorToDistributor>> GetRetailorbydistributorId(string distributorId)
        {
            return await _httpClientWrapper.GetByIdAsync<List<RetailorToDistributor>>("/AssignRetailorToDistributor", distributorId);
        }
       
    }

}