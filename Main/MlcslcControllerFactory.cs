using Main.Controllers;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Main
{
	public class MlcslcControllerFactory : IControllerFactory
	{
		private readonly IControllerFactory _factory;

		public MlcslcControllerFactory(IControllerFactory factory)
		{
			this._factory = factory;
		}

		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			IController baseController;
			try
			{
				baseController = this._factory.CreateController(requestContext, controllerName);
			}
			catch (HttpException httpException)
			{
				if (httpException.GetHttpCode() != 404)
				{
					throw;
				}
				else
				{
					baseController = new BaseController();
				}
			}
			return baseController;
		}

		public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
		{
			return this._factory.GetControllerSessionBehavior(requestContext, controllerName);
		}

		public void ReleaseController(IController controller)
		{
			this._factory.ReleaseController(controller);
		}
	}
}