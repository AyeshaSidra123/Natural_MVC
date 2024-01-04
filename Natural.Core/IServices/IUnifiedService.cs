using NatDMS.Models;
using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natural.Core.IServices
{
    public interface IUnifiedService
    {
        Task<List<StateModel>> GetStates();
        Task<List<CityModel>> GetCitiesbyStateId(string stateId);
        Task<List<AreaModel>> GetAreasByCityId(string cityId);
        Task<List<ExecutiveModel>> GetExecutives();
        Task<List<DistributorToExecutive>> GetDistributorsByExecutiveId(string executiveId);
        Task<List<RetailorToDistributor>> GetRetailorbydistributorId(string distributorId);
    }
}
