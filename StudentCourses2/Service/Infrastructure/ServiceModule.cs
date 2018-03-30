using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Repositories;
using Ninject.Modules;

namespace Service.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
