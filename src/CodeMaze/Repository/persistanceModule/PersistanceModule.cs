using Autofac;
using Contract.UnitOfWork;
using Contract.UserRepository;
using Persistance.Repository;
using Persistance.UnitOfWorks;

namespace Persistance.persistanceModule
{
    public class PersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUnitofWork>().
                As<IApplicationUnitofWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ComapnyRepository>().
                As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ComapnyRepository>().
              As<ICompanyRepository>()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
