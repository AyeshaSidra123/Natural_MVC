﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NatDMS.Models;
using Natural.Core.IServices;
using Natural.Core.Models;
using Naturals.Service.Service;
using System.Net;
using System.Reflection;

# nullable disable

namespace NatDMS.Controllers
{
    public class ExecutiveController : Controller
    {

        private readonly IExecutiveService _ExecutiveService;

        private readonly IMapper _mapper;
        private readonly IUnifiedService _unifiedservice;
        private readonly IConfiguration _configuration;
        public ExecutiveController(IExecutiveService ExecutiveService, IMapper mapper, IUnifiedService unifiedService,
        IConfiguration configuration)
        {
            _ExecutiveService = ExecutiveService;
            _mapper = mapper;
            _unifiedservice = unifiedService;
            _configuration = configuration;
        }

        /// <summary>
        /// DISPLAYING LIST OF ALL EXECUTIVES 
        /// </summary>

        
        public async Task<ActionResult<List<ExecutiveModel>>> DisplayExecutives(int page = 1)
        {
            var executiveResult = await _ExecutiveService.GetAllExecutivesAsync();
            var viewmodel = _mapper.Map<List<GetExecutive>, List<ExecutiveModel>>(executiveResult);

            var executivePgn = new PageNation<ExecutiveModel>(viewmodel, _configuration, page);
            var paginatedData = executivePgn.GetPaginatedData(viewmodel);

            ViewBag.Pages = executivePgn;
            var statesResult = await _unifiedservice.GetStates();
            var viewModel = new EDR_DisplayViewModel
            {
                ExecutiveList = paginatedData,
                StateList = statesResult,
            };

            return View(viewModel);
        }


        /// <summary>
        /// GETTING EXECUTIVE DETAILS BY ID
        /// </summary>


        public async Task<ActionResult<ExecutiveDetailsViewModel>> ExecutiveDetailsById(string id)
        {
            var ExecutiveDetails = await _ExecutiveService.GetExecutiveDetailsByIdAsync(id);
            var AssignedDetails = await _ExecutiveService.GetAssignedDistributorsByExecutiveId(id);

            if (ExecutiveDetails == null || AssignedDetails == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<GetExecutive, ExecutiveViewModel>(ExecutiveDetails);

            var executiveviewmodel = new ExecutiveDetailsViewModel
            {
                ExecutiveDetails = mapped,
                AssignedDistributors = AssignedDetails,
            };


            return View(executiveviewmodel);

        }

        /// <summary>
        /// GETTING CITIES LIST FOR DROPDOWN BASED ON STATE_ID
        /// </summary> 

        public async Task<IActionResult> GetCitiesbyStateId(string stateId)
        {
            var result = await _unifiedservice.GetCitiesbyStateId(stateId);
            return Json(result);
        }

        /// <summary>
        /// GETTING AREA'S LIST FOR DROPDOWN BASED ON CITY_ID
        /// </summary>
        public async Task<JsonResult> GetAreasByCityId(string cityId)
        {
            var result = await _unifiedservice.GetAreasByCityId(cityId);

            return Json(result);
        }

        /// <summary>
        /// CREATING NEW EXECUTIVE
        /// </summary>

        public async Task<ActionResult> CreateExecutive()
        {
            var viewmodel = new ED_CreateViewModel();
            viewmodel.States = await _unifiedservice.GetStates();
            return View(viewmodel);
        }


        /// <summary>
        /// INSERTING CREATED EXECUTIVE DATA
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> CreateExecutive(ED_CreateViewModel saveexecmdl)
        {
            if (ModelState.IsValid)
            {
                var createexecutive = _mapper.Map<ED_CreateViewModel, ExecutiveModel>(saveexecmdl);

                var displayxexecutive = await _ExecutiveService.CreateExecutive(createexecutive);

                return RedirectToAction(nameof(DisplayExecutives));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Form submission failed . please check the procided data");
                return View(saveexecmdl);
            }
        }


        /// <summary>
        /// GETTING EXISTING DATA FOR UPDATE
        /// </summary>

        public async Task<ActionResult<ED_EditViewModel>> EditExecutive(string id)
        {
            var executive = await _ExecutiveService.GetExecutiveById(id);

            var viewModel = _mapper.Map<ED_EditViewModel>(executive);
            viewModel.StateList = await _unifiedservice.GetStates();
            viewModel.CityList = await _unifiedservice.GetCitiesbyStateId(executive.State);
            viewModel.AreaList = await _unifiedservice.GetAreasByCityId(executive.City);
            return View(viewModel);
        }

        /// <summary>
        /// POSTING UPDATED EXECUTIVE DATA
        /// </summary>
        /// 

        [HttpPost]
        public async Task<ActionResult> EditExecutive(string id, ED_EditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var update = _mapper.Map<ED_EditViewModel, ExecutiveModel>(viewModel);

                await _ExecutiveService.UpdateExecutive(id, update);

                return RedirectToAction(nameof(DisplayExecutives));
            }
            else
            {
                viewModel.StateList = await _unifiedservice.GetStates();
                viewModel.CityList = await _unifiedservice.GetCitiesbyStateId(viewModel.State);
                viewModel.AreaList = await _unifiedservice.GetAreasByCityId(viewModel.City);
                return View(viewModel);
            }
        }

        /// <summary>
        /// DELETING EXECUTIVE BY ID
        /// </summary>

        public async Task<ActionResult> DeleteExecutive(string ExecutiveId)
        {
            await _ExecutiveService.DeleteExecutive(ExecutiveId);
            return RedirectToAction(nameof(DisplayExecutives));
        }

        /// <summary>
        /// SEARCH EXECUTIVE PARTIAL VIEW
        /// </summary>


        [HttpPost]
        public async Task<ActionResult<EDR_DisplayViewModel>> SearchExecutive(EDR_DisplayViewModel SearchResultmodel)
        {
            var search = _mapper.Map<EDR_DisplayViewModel, SearchModel>(SearchResultmodel);
            var SearchResult = await _ExecutiveService.SearchExecutive(search);
            var statesResult = await _unifiedservice.GetStates();

            var viewModel = new EDR_DisplayViewModel
            {
                ExecutiveList = SearchResult,
                StateList = statesResult,
            };

            return PartialView("_SearchExecutivePartial", viewModel);
        }

        /// <summary>
        /// DISPLAYING LIST OF ALL DISTRIBUTORS 
        /// </summary>

        private async Task<(List<DistributorModel> PaginatedData, PageNation<DistributorModel> DistributorPgn)> GetPaginatedDistributorData (List<DistributorModel> distributorResult, int page)
        {
            var distributorPgn = new PageNation<DistributorModel>(distributorResult, _configuration, page);
            var paginatedData = distributorPgn.GetPaginatedData(distributorResult);
            return (paginatedData, distributorPgn);
        }

        [HttpGet]
        public async Task<ActionResult<List<DistributorModel>>> ListOfDistributors (int page = 1)
        {
            var distributorResult = await _ExecutiveService.GetNonAssignedDistributors();
            var (paginatedData, distributorPgn) = await GetPaginatedDistributorData(distributorResult, page);
            ViewBag.Pages = distributorPgn;
            var statesResult = await _unifiedservice.GetStates();
            var viewModel = new EDR_DisplayViewModel
            {
                DistributorList = paginatedData,
                StateList = statesResult
            };
            return View("_ListOfDistributors", viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> SearchNonAssignedDistributors(EDR_DisplayViewModel SearchResultmodel, int page = 1)
        {
            var search = _mapper.Map<EDR_DisplayViewModel, SearchModel>(SearchResultmodel);
            var searchResult = await _ExecutiveService.SearchNonAssignedDistributors(search);

            // Paginate search results
            var (paginatedData, distributorPgn) = await GetPaginatedDistributorData(searchResult, page);
            ViewBag.Pages = distributorPgn;

            var statesResult = await _unifiedservice.GetStates();

            var viewModel = new EDR_DisplayViewModel
            {
                DistributorList = paginatedData,
                StateList = statesResult,
            };

            return Json(viewModel);
        }



        /// <summary>
        /// DELETE ASSIGNED DISTRIBUTOR
        /// </summary>

        public async Task<IActionResult> DeleteAssignedDistributor(string distributorId,string executiveId)
        {
           
            var result  = await _ExecutiveService.DeleteAssignedDistributor(distributorId, executiveId);
          
            return Json(result);
        }

    }
}