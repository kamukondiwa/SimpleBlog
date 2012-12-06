namespace Leatn.Web.Mvc.Extensions
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Resources;

    #endregion

    public static class ExpressionHelper
    {
        public static string GetInputName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.Call)
            {
                var methodCallExpression = (MethodCallExpression)expression.Body;
                var name = GetInputName(methodCallExpression);
                return name.Substring(expression.Parameters[0].Name.Length + 1);
            }
            return expression.Body.ToString().Substring(expression.Parameters[0].Name.Length + 1);
        }

        public static RouteValueDictionary GetRouteValuesFromExpression<TController>(
            Expression<Action<TController>> action) where TController : Controller
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            var call = action.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException(MvcResources.ExpressionHelper_MustBeMethodCall, "action");
            }

            var controllerName = typeof(TController).Name;
            if (!controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(MvcResources.ExpressionHelper_TargetMustEndInController, "action");
            }
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
            if (controllerName.Length == 0)
            {
                throw new ArgumentException(MvcResources.ExpressionHelper_CannotRouteToController, "action");
            }

            // TODO: How do we know that this method is even web callable?
            //      For now, we just let the call itself throw an exception.

            var rvd = new RouteValueDictionary();
            rvd.Add("Controller", controllerName);
            rvd.Add("Action", call.Method.Name);
            AddParameterValuesFromExpressionToDictionary(rvd, call);
            return rvd;
        }

        private static void AddParameterValuesFromExpressionToDictionary(
            RouteValueDictionary rvd, MethodCallExpression call)
        {
            var parameters = call.Method.GetParameters();

            if (parameters.Length > 0)
            {
                for (var i = 0;
                     i < parameters.Length;
                     i++)
                {
                    var arg = call.Arguments[i];
                    object value = null;
                    var ce = arg as ConstantExpression;
                    if (ce != null)
                    {
                        // If argument is a constant expression, just get the value
                        value = ce.Value;
                    }
                    else
                    {
                        // Otherwise, convert the argument subexpression to type object,
                        // make a lambda out of it, compile it, and invoke it to get the value
                        var lambdaExpression = Expression.Lambda<Func<object>>(Expression.Convert(arg, typeof(object)));
                        var func = lambdaExpression.Compile();
                        value = func();
                    }
                    rvd.Add(parameters[i].Name, value);
                }
            }
        }

        private static string GetInputName(MethodCallExpression expression)
        {
            // p => p.Foo.Bar().Baz.ToString() => p.Foo OR throw...

            var methodCallExpression = expression.Object as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return GetInputName(methodCallExpression);
            }
            return expression.Object.ToString();
        }
    }
}   