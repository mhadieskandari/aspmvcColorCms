using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS_Golbarg.Helpers
{
    public static class FileUploadHtmlHelper
    {
        public static IHtmlString UploadFileFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, Object htmlAttributes = null)
        {
            var builder = new TagBuilder("input");
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            builder.GenerateId(name);
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("type", "file");
            IDictionary<string, object> validationAttributes = helper.
                GetUnobtrusiveValidationAttributes
                (name, metadata);
            foreach (string key in validationAttributes.Keys)
            {
                builder.Attributes.Add(key, validationAttributes[key].ToString());
            }
            if (htmlAttributes != null)
            {
                IDictionary<string, string> newAttributes = (IDictionary<string, string>)(htmlAttributes);

                foreach (var attr in newAttributes)
                {
                    builder.Attributes.Add(attr.Key,attr.Value);
                }
            }
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}