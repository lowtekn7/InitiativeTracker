﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.WebUI.Models;
using InitiativeTracker.WebUI.Infrastructure;
using InitiativeTracker.WebUI.Infrastructure.Binders;

namespace InitiativeTracker.WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(SelectedCharacters), new SelectedCharacterBinder());
            ModelBinders.Binders.Add(typeof(EncounterCharacters), new EncounterCharacterBinder());
        }
    }
}