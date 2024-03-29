﻿using Natural.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Natural.Core.IServices
{
    public interface IExecutiveService
    {
        Task<List<ExecutiveModel>> GetAllExecutives();
        Task<List<GetExecutive>> GetAllExecutivesAsync();
        Task<ExecutiveModel> GetExecutiveById(string Id);
        Task<ExecutiveModel> GetExecutiveDetailsById(string ID);
        Task<GetExecutive> GetExecutiveDetailsByIdAsync(string ID);
        Task<ExecutiveModel> CreateExecutive(ExecutiveModel mdl);
        Task<ExecutiveModel> UpdateExecutive(string ExecutiveId, ExecutiveModel executive);
        Task<bool> DeleteExecutive(string executiveId);        
      Task<List<ExecutiveModel>> SearchExecutive(SearchModel searchexecutive);

        Task<List<DistributorModel>> GetNonAssignedDistributors();
        Task<List<DistributorModel>> SearchNonAssignedDistributors(SearchModel searchdistributor);
        Task<string> DeleteAssignedDistributor(string DistributorId, string executiveId);

        Task<List<DistributorModel>> GetAssignedDistributorsByExecutiveId(string ExecutiveId);

    }
}