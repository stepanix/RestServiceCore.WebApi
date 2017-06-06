using Autofac;


using System.Reflection;
using System.Collections.Generic;
using AutoMapper;

namespace RestServiceCore.WebApi
{
    public class DtoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(DtoMapperProfile).GetTypeInfo().Assembly).As<Profile>();

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
