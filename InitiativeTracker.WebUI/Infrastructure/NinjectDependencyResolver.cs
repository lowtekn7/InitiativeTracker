﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using System.Web.Mvc;
using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Concrete;

namespace InitiativeTracker.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICharacterRepository>().To<EFCharacterRepository>();
        }
    }
}