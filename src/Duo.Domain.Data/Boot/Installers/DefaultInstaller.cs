﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.ComponentModel.Composition;

namespace Duo.Domain.Data.Boot.Installers
{
    [Export( typeof( IWindsorInstaller ) )]
	public class DefaultInstaller : IWindsorInstaller
	{
		public void Install( IWindsorContainer container, IConfigurationStore store )
		{
			container.Register
			(
				Types.FromAssemblyNamed("Duo.Domain")
					.IncludeNonPublicTypes()
					.Where( t => !t.IsInterface && !t.IsAbstract && !t.IsGenericType && t.Namespace != null && t.IsNested && t.Name.EndsWith( "Factory" ) )
					.WithService.Select( ( type, baseTypes ) => new[] { type } )
					.LifestyleSingleton()
			);
		}
	}
}
