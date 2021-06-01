using System;
using System.Collections.Generic;
using System.Text;

using IdentityServer4.Services;
using System.Reflection;
using Module = Autofac.Module;
using Autofac;
using Core.Domain.ViewModel;
using Core.Infrastructure.Services;

namespace Core.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public string ConnectionString { get; }
        public ApplicationModule(string connectionString)
        {
            ConnectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //#region Resources
            //builder.RegisterType<ResourceService<GhmCoreResource>>()
            //       .As<IResourceService<GhmCoreResource>>()
            //       .InstancePerLifetimeScope();
            //#endregion

            builder.RegisterType<ProfileService>()
          .As<IProfileService>()
          .InstancePerLifetimeScope();

            //builder.RegisterType<EmailSender>()
            //.As<IEmailSender>()
            //.InstancePerLifetimeScope();

            #region Repositories            
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .WithParameter(new TypedParameter(typeof(string), ConnectionString));
            #endregion

            #region Services            
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
            #endregion                    
        }
    }
}
