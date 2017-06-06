using Autofac;

using System.Reflection;
using System.Collections.Generic;
using AutoMapper;

namespace RestServiceCore.Domain
{
    public class DomainMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(DomainMapperProfile).GetTypeInfo().Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
        }
    }
}
