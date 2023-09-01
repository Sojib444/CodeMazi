using AutoMapper;
using DataTransferObjects.ComapnyDTO;
using Entities.Model;

namespace ComapnyEmployee.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Company, CompanyDTO>().ForMember(c=> c.fullAddress,
            //    opt => opt.MapFrom(x => string.Join(" ",x.Address,x.Country)));

            CreateMap<Company, CompanyDTO>().ForCtorParam("fullAddress", 
                opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country))); // we used it if we have any constructor.

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CreateCompnyDTO, Company>()
                .ReverseMap();
        }
    }
}
