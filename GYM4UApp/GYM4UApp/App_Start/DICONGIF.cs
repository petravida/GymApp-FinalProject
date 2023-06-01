using Autofac;
using Autofac.Integration.Mvc;
using GYM4U.Repository;
using GYM4URepository.Common;
using GYM4UService;
using GYM4UService.Common;
using GYM4UDAL;
using GYM4URepositpry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GYM4UApp.App_Start
{
    public class DICONGIF
    {
        public static void Configuration()
        {

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MemberService>().As<IMemberService>();
            builder.RegisterType<MembershipCardService>().As<IMembershipCardService>();
            builder.RegisterType<MembershipTypeService>().As<IMembershipTypeService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<AppUserService>().As<IAppUserService>();
            builder.RegisterType<ActivityService>().As<IActivityService>();

            builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            builder.RegisterType<MembershipTypeRepository>().As<IMembershipTypeRepository>();
            builder.RegisterType<MembershipCardRepository>().As<IMembershipCardRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>();
            builder.RegisterType<ActivityRepository>().As<IActivityRepository>();

            builder.RegisterType<Gym4UEntities>().AsSelf().InstancePerLifetimeScope();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}