namespace Leatn.Framework.Captcha
{
    using System;
    using System.Drawing.Imaging;
    using System.Web;

    /// <summary>
    /// Captcha image stream HttpModule. Retrieves CAPTCHA objects from cache, renders them to memory, 
    /// and streams them to the browser.
    /// </summary>
    /// <remarks>
    /// You must add the to your web.config:
    /// <httpHandlers>
    /// <add verb="GET" path="captcha.ashx" type="Leatn.Web.Mvc.Captcha.CaptchaImageHandler, Leatn.Web.Mvc"/>
    /// </httpHandlers>
    /// </remarks>
    /// <seealso href="http://www.codinghorror.com">Original By Jeff Atwood</seealso>
    public class CaptchaImageHandler : IHttpHandler
    {
        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.
        /// </param>
        public void ProcessRequest(HttpContext context)
        {
            // get the unique GUID of the captcha; this must be passed in via the querystring
            var guid = context.Request.QueryString["guid"];
            var ci = CaptchaImage.GetCachedCaptcha(guid);

            if (String.IsNullOrEmpty(guid) || ci == null)
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "Not Found";
                context.ApplicationInstance.CompleteRequest();
                return;
            }

            // write the image to the HTTP output stream as an array of bytes
            using (var b = ci.RenderImage())
            {
                b.Save(context.Response.OutputStream, ImageFormat.Gif);
            }

            context.Response.ContentType = "image/png";
            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";
            context.ApplicationInstance.CompleteRequest();
        }
    }
}