using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InitiativeTracker.WebUI.Infrastructure.Binders
{
    public class EncounterCharacterBinder : IModelBinder
    {
        private const string sessionKey = "encounterCharacters";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            EncounterCharacters encounterCharacters = null;
            if (controllerContext.HttpContext.Session != null)
                encounterCharacters = (EncounterCharacters)controllerContext.HttpContext.Session[sessionKey];

            if (encounterCharacters == null)
            {
                encounterCharacters = new EncounterCharacters();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionKey] = encounterCharacters;
            }

            return encounterCharacters;
        }
    }
}