﻿using Contracts;
using Entities.Model;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public IEnumerable<Company> GetAllComapniesAsync(bool trackChange)
        {
            return  FinaAll(trackChange).OrderBy(e => e.Name).ToList();
        }

        public Company GetCompany(Guid id, bool trackChange)
        {
           return FindByCondition(company => company.Id.Equals(id), false).SingleOrDefault();
        }
    }
}