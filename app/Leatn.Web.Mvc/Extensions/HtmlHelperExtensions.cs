#region Using Directives

#endregion

namespace Leatn.Web.Mvc.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Caching;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using Domain.Tags;

    using Framework.Captcha;
    using Framework.Extensions;

    using Gentax.Visitors.UI;

    using UI.Components.Matrix;
    using UI.Components.Matrix.Mappers;
    using UI.Components.Matrix.Renderers;
    using UI.Components.Navigation;

    using xVal.Html;

    #endregion

    #region Using Directives

    #endregion

    /// <summary>
    /// The html helper extensions.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates an anchor tag based on the passed in controller type and method
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification =
                "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")
        ]
        public static MvcHtmlString ActionLink<TController>(
            this HtmlHelper helper, Expression<Action<TController>> action, string linkText)
            where TController : Controller
        {
            return ActionLink(helper, action, linkText, null);
        }

        /// <summary>
        /// Creates an anchor tag based on the passed in controller type and method
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification =
                "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")
        ]
        public static MvcHtmlString ActionLink<TController>(
            this HtmlHelper helper, Expression<Action<TController>> action, string linkText, object htmlAttributes)
            where TController : Controller
        {
            var routingValues = ExpressionHelper.GetRouteValuesFromExpression(action);

            return helper.RouteLink(linkText, routingValues, new RouteValueDictionary(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings",
            Justification = "This is a UI method and is required to use strings as Uri")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification =
                "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")
        ]
        public static string BuildUrlFromExpression<TController>(
            this HtmlHelper helper, Expression<Action<TController>> action) where TController : Controller
        {
            return LinkBuilder.BuildUrlFromExpression(helper.ViewContext.RequestContext, helper.RouteCollection, action);
        }

        /// <summary>
        /// The captcha image.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <returns>
        /// The captcha image markup.
        /// </returns>
        public static string CaptchaImage(this HtmlHelper htmlHelper, int height, int width)
        {
            var image = new CaptchaImage { Height = height, Width = width, };

            htmlHelper.ViewContext.HttpContext.Cache.Add(
                image.UniqueId,
                image,
                null,
                DateTime.Now.AddSeconds(120),
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable,
                null);

            var stringBuilder = new StringBuilder(256);
            stringBuilder.Append("<input type=\"hidden\" name=\"CommentForm.Guid\" value=\"");
            stringBuilder.Append(image.UniqueId);
            stringBuilder.Append("\" />");
            stringBuilder.AppendLine();
            stringBuilder.Append("<img src=\"");
            stringBuilder.Append("/captcha.ashx?guid=" + image.UniqueId);
            stringBuilder.Append("\" alt=\"CAPTCHA\" width=\"");
            stringBuilder.Append(width);
            stringBuilder.Append("\" height=\"");
            stringBuilder.Append(height);
            stringBuilder.Append("\" />");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// The client side validation for.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <typeparam name="T">
        /// The model type to be validated.
        /// </typeparam>
        /// <returns>
        /// Validation Information.
        /// </returns>
        public static ValidationInfo ClientSideValidationFor<T>(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ClientSideValidation(typeof(T).Name, typeof(T));
        }

        /// <summary>
        /// The css html helper.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="relativePath">
        /// The relative path.
        /// </param>
        /// <returns>
        /// The css file include html.
        /// </returns>
        public static string CssClass(this HtmlHelper htmlHelper, string relativePath)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Content("~/content/css/{0}".FormatWith(relativePath));

            var tagBuilder = new TagBuilder("link");
            tagBuilder.Attributes.Add("rel", "stylesheet");
            tagBuilder.Attributes.Add("type", "text/css");
            tagBuilder.Attributes.Add("href", url);

            return tagBuilder.ToString();
        }

        /// <summary>
        /// The preview grid.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html Helper.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="rows">
        /// The row count.
        /// </param>
        /// <param name="columns">
        /// The column count.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// The model type.
        /// </typeparam>
        /// <returns>
        /// The Matrix builder.
        /// </returns>
        public static MatrixBuilder<T> Matrix<T>(
            this HtmlHelper htmlHelper, IEnumerable<T> model, int rows, int columns, Action<T> action) where T : class
        {
            var textWriter = htmlHelper.ViewContext.HttpContext.Response.Output;

            var viewContext = htmlHelper.ViewContext;

            var matrixRenderer = MatrixRendererFactory.GetMatrixRenderer(viewContext, textWriter, action);

            var matrixModelMapper = MatrixMapperFactory.GetMatrixModelMapper<T>();

            var matrixSource = new MatrixSource<T>(model, rows, columns);

            return new MatrixBuilder<T>(matrixRenderer, matrixModelMapper, matrixSource);
        }

        public static string Tags(this HtmlHelper htmlHelper, Tag tag, string id)
        {
            var displayVisitor = new ElementDisplayVisitor<Tag>(htmlHelper.ViewContext.HttpContext.Response.Output, DisplayType.Tree, id);
            displayVisitor.Visit(tag);
            return string.Empty;
        }
    }
}