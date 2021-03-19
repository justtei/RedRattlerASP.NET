using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UserManagementSystem.Business.Components;
using UserManagementSystem.Shared.Entities;

namespace Main.Controllers
{
    public class AdminLocationController : BaseController
    {
        public AdminLocationController()
        {
        }

        public JsonResult GetCities(int stateCode)
        {
            List<City> cities = LocationBc.Instance.GetCities(stateCode);
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = cities
            };
        }

        public JsonResult c(int countryCode)
        {
            List<State> states = LocationBc.Instance.GetStates(countryCode);
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = states
            };
        }
    }
}