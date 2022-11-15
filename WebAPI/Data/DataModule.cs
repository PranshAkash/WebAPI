using Data.Sources;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Data
{
    //public class DataModule : Module
    //{
    //    protected override void Load(ContainerBuilder builder)
    //    {
    //        builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
    //        builder.Register(x => x.Resolve<IUnitOfWorkFactory>().Create()).As<IUnitOfWork>().InstancePerLifetimeScope();

    //        builder.RegisterType<UserDataSource>().As<IUserDataSource>().InstancePerLifetimeScope();
    //    }
    //}
}
