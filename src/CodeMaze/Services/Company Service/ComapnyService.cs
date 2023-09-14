using AutoMapper;
using Contracts;
using DataTransferObjects.ComapnyDTO;
using DataTransferObjects.ComapnyDTOs;
using DataTransferObjects.RequestFeatures;
using Entities.ErrorModel;
using Entities.Exceptions;
using Entities.Model;
using Entities.RequestFeatures;
using Services.Contracts;

namespace Services
{
    public class ComapnyService : ICompanyService
    {
        private readonly IApplicationUnitofWork unitofWork;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        public ComapnyService(IApplicationUnitofWork unitofWork,ILoggerManager loggerManager,IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        public CreateCompnyDTO CreateComany(CreateCompnyDTO creatCompanyDTO)
        {
            var comapny = mapper.Map<Company>(creatCompanyDTO);

            unitofWork.companyRepository.CreateCompany(comapny);
            unitofWork.SaveChage();

            return mapper.Map<CreateCompnyDTO>(comapny);
        }

        public  (IEnumerable<CompanyDTO>, MetaData metaData) GetAllCompanies(ComapnyParameters comapnyParameters, bool trackChange)
        {
            var companies = unitofWork.companyRepository.GetAllComapniesAsync(comapnyParameters, trackChange);

            // var companiesDto = companies.Select(e =>
            // new CompanyDTO(e.Id,e.Name?? "" ,string.Join(" ",e.Address,e.Country)));

            var companiesDto = mapper.Map<IEnumerable<CompanyDTO>>(companies);

            return (companiesDto, companies.metaData);        
        }

        public CompanyDTO GetCompany(Guid Id, bool trackChange)
        {
            var company = unitofWork.companyRepository.GetCompany(Id, trackChange);

            if(company == null)//company could br null
            {
                throw new CompanyNotFoundException(Id);
            }
           
            var companyDto = mapper.Map<CompanyDTO>(company);

            return companyDto;            
        }


        public IEnumerable<CompanyDTO> GetAllCompanyCollection(IEnumerable<Guid> ids, bool trackChage)
        {
            if(ids == null )
            {
                throw new IdParameterBadRequstException();
            }

            var companyCollection = GetAllCompanyCollection(ids, trackChage);

            if(ids.Count() != companyCollection.Count())
            {
                throw new CollectionByIDBAdRequestException();
            }

            var response = mapper.Map<IEnumerable<CompanyDTO>>(companyCollection);

            return response;
        }

        public (IEnumerable<CompanyDTO> comapnies, string ids) CreateCompnyCollection(IEnumerable<CreateCompnyDTO> companyCollection)
        {
            if(companyCollection is null)
            {
                throw new CompanyCollectionBadRequst();
            }

            var mappningCompanyCollection = mapper.Map<IEnumerable<Company>>(companyCollection);

            foreach(var company in mappningCompanyCollection)
            {
                unitofWork.companyRepository.CreateCompany(company);
            }

            unitofWork.SaveChage();
            unitofWork.Dispose();

            var response = mapper.Map <IEnumerable<CompanyDTO>>(mappningCompanyCollection);
            var ids = string.Join(",", mappningCompanyCollection.Select(e => e.Id));

            return (response, ids);

        }

        public void DeleteComany(Guid companyId, bool trackChange)
        {
            var comapany = unitofWork.companyRepository.GetCompany(companyId, trackChange);

            if(comapany == null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            unitofWork.companyRepository.DeleteComapny(comapany, trackChange);
            unitofWork.SaveChage();
            unitofWork.Dispose();
        }

        public void UpdateCompany(Guid ComaPanyId,UpdateCompanyDTO updateCompanyDTO, bool trackChange)
        {
            var company = unitofWork.companyRepository.UpdateCompany(ComaPanyId, trackChange);

            if(company == null)
            {
                throw new CompanyNotFoundException(ComaPanyId);
            }

            mapper.Map(updateCompanyDTO, company);

            unitofWork.SaveChage();
            unitofWork.Dispose();
        }
    }
}
