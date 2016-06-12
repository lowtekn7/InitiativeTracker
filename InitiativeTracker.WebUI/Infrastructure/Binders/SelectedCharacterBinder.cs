using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Infrastructure.Binders
{
    public class SelectedCharacterBinder : IModelBinder
    {
        private const string sessionKey = "selectedCharacters";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            SelectedCharacters selectedCharacters = null;
            if (controllerContext.HttpContext.Session != null)
                selectedCharacters = (SelectedCharacters)controllerContext.HttpContext.Session[sessionKey];

            if (selectedCharacters == null)
            {
                selectedCharacters = new SelectedCharacters();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionKey] = selectedCharacters;
            }

            return selectedCharacters;
        }
    }
}