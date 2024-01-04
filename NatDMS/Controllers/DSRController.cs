using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using NatDMS.Models;
using Natural.Core.IServices;
using Natural.Core.Models;
using Naturals.Service.Service;
using System.Security.Cryptography;

namespace NatDMS.Controllers
{
    public class DSRController : Controller
    {
        
        private readonly IDsrService _dsrservice;
        private readonly IDsrDetailsService _dsrdetailsservice;
        private readonly IUnifiedService _unifiedservice;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public DSRController(IDsrService dsrservice,IDsrDetailsService dsrDetailsService, IMapper mapper, IUnifiedService unifiedservice, IConfiguration configuration)

        {
            _dsrservice = dsrservice;
            _dsrdetailsservice = dsrDetailsService;
            _unifiedservice = unifiedservice;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        public async Task<ActionResult<List<DsrModel>>> DisplayDsrs()
        
        {
            var dsrResult = await _dsrservice.GetDsrAll();
            var mapped = _mapper.Map<List<DsrModel>,List<DsrViewModel>>(dsrResult);

            return View(mapped);
        }
     public async Task<ActionResult<List<DSRDetailsModel>>>DisplayDsrdetails()
        {
            var dsrResult = await _dsrdetailsservice.GetDsrDetailsAll();
            var mapped = _mapper.Map<List<DSRDetailsModel>, List<DsrDetailViewModel>>(dsrResult);

            return View(mapped);
        }

        /// <summary>
        /// GETTING Distributor LIST FOR DROPDOWN BASED ON Executive_ID
        /// </summary> 
        public async Task<ActionResult> GetDistributorbyExecutiveid(string executiveId)
        {
            var result = await _unifiedservice.GetDistributorsByExecutiveId(executiveId);
            return Json(result);
        }

        /// <summary>
        /// GETTING RETAILOR'S LIST FOR DROPDOWN BASED ON DISTRIBUTOR_ID
        /// </summary>
        public async Task<ActionResult> GetRetailorsbyDitributorId(string DistributorId)
        {
            var result = await _unifiedservice.GetRetailorbydistributorId(DistributorId);

            return Json(result);
        }


        public async Task<ActionResult> CreateDsr()
        {
          
            var viewModel = new SaveDsrViewModel();
            viewModel.Executives = await _unifiedservice.GetExecutives();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDsr(SaveDsrViewModel dsrViewModel)
        {
            if (dsrViewModel != null && ModelState.IsValid)
            {
                var dsr = _mapper.Map<SaveDsrViewModel, DsrModel>(dsrViewModel);
                var CreateDsr = await _dsrservice.CreateDsr(dsr);
                var dsrdetails = _mapper.Map<SaveDsrViewModel, DSRDetailsModel>(dsrViewModel);
                var CreateDsrDetails=await  _dsrdetailsservice.CreateDSRDetails(dsrdetails);
                return RedirectToAction("DisplayDsrs", "DSR");
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Form submission failed. Please check the provided data");
                return View(dsrViewModel);
            }
        }
    }
}