using AutoMapper;
using NatDMS.Models;
using Natural.Core.Models;

namespace NatDMS.Mapping
{
   public class MappingProfile : Profile
   {
        public MappingProfile()

        {
            // Domain to Resource

            CreateMap<LoginModel, LoginViewModel>();
            CreateMap<StateModel, StateViewModel>();
            CreateMap<CityModel, CityViewModel>();
            CreateMap<AreaModel, AreaViewModel>();
            CreateMap<LoginModel , LoginResultModel>();
            CreateMap<DistributorModel, DistributorViewModel>();
            CreateMap<CategoryModel, CategoryViewModel>();
            CreateMap<RetailorModel, RetailorViewModel>();
            CreateMap<StateModel, StateViewModel>();
            CreateMap<CityModel, CityViewModel>();
            CreateMap<AreaModel, AreaViewModel>();
            CreateMap<ExecutiveModel, ExecutiveViewModel>();
            CreateMap<RetailorModel, SaveRetailorViewModel>();
            CreateMap<ExecutiveModel, ExecutiveViewModel>();
            CreateMap<ExecutiveModel, ED_CreateViewModel>();
            CreateMap<DistributorModel , ED_CreateViewModel>();
            CreateMap<StateModel, ED_CreateViewModel>();
            CreateMap<DistributorModel, ED_EditViewModel>();
            CreateMap<ExecutiveModel, ED_EditViewModel>();
            CreateMap<RetailorModel , RetailorEditViewModel>();
            CreateMap<ExecutiveModel, EDR_DisplayViewModel>();
            CreateMap<DistributorModel,EDR_DisplayViewModel>();
            CreateMap<RetailorModel, EDR_DisplayViewModel>();
            CreateMap<SearchModel,EDR_DisplayViewModel>();
            CreateMap<DsrModel, EDR_DisplayViewModel>();
            CreateMap<DsrModel, DsrViewModel>();
            CreateMap<DsrModel,SaveDsrViewModel>();
            CreateMap<DSRDetailsModel, SaveDsrViewModel>();
            CreateMap<DistributorToExecutive, AssignDistributorToExecutiveViewModel>();
            CreateMap<SearchModel , SearchViewModel>();




            // Resource to Domain

            CreateMap<LoginResultModel, LoginModel>();
            CreateMap<LoginViewModel, LoginModel>();
            CreateMap<DistributorViewModel,DistributorModel>();
            CreateMap<CategoryViewModel, CategoryModel>();
            CreateMap<RetailorViewModel, RetailorModel>();
            CreateMap<ED_EditViewModel, DistributorModel>();
            CreateMap<ED_EditViewModel, ExecutiveModel>();
            CreateMap<SaveRetailorViewModel,RetailorModel>();
            CreateMap<ExecutiveViewModel, ExecutiveModel>();
            CreateMap<ED_CreateViewModel, ExecutiveModel>();
            CreateMap<ED_CreateViewModel,DistributorModel>();
            CreateMap<RetailorEditViewModel, RetailorModel>();
            CreateMap<EDR_DisplayViewModel, ExecutiveModel>();
            CreateMap<EDR_DisplayViewModel, DistributorModel>();
            CreateMap<EDR_DisplayViewModel, RetailorModel>();
            CreateMap<EDR_DisplayViewModel, SearchModel>();
            CreateMap<EDR_DisplayViewModel, DsrModel>();
            CreateMap<DsrViewModel,DsrModel>();
            CreateMap<SaveDsrViewModel, DsrModel>();
            CreateMap<SaveDsrViewModel, DSRDetailsModel>();
            CreateMap<AssignDistributorToExecutiveViewModel, DistributorToExecutive>();
            CreateMap<SearchViewModel,SearchModel>();





        }
    }
}
