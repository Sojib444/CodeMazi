﻿using Contracts;

namespace Repository.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RepositoryContext repositoryContext;

        public UnitofWork(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public void Dispose()
        {
            repositoryContext.Dispose();
        }

        public void SaveChage()
        {
            repositoryContext.SaveChanges();
        }
    }
}
