namespace Leatn.Web.Controllers.Shared.ActionResults
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class NotFoundResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var routeData = new RouteData();
            routeData.Values.Add(
                "controller",
                "Error");
            routeData.Values.Add(
                "action",
                "NotFound");

            var controller = ControllerBuilder.Current.GetControllerFactory().CreateController(
                context.RequestContext,
                "Error");

            controller.Execute(
                new RequestContext(new HttpContextWrapper(HttpContext.Current),
                    routeData));
        }
    }
}