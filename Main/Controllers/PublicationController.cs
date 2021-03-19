using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UserManagementSystem.Business.Components;
using UserManagementSystem.Shared.Entities;

namespace Main.Controllers
{
    public class PublicationController : BaseController
    {
        public PublicationController()
        {
        }

        public JsonResult GetPublications(int brand)
        {
            List<Publication> publications = PublicationBc.Instance.GetPublications(brand);
            return new JsonResult()
            {
                Data = publications,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}