using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS_Golbarg.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString Image(this HtmlHelper helper, byte[] image, string imgclass,
                                     object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString ImageFile(this HtmlHelper helper, string path, string imgclass,
                                     object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

          
            builder.MergeAttribute("src", path);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static IHtmlString ImageFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {

            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            TagBuilder builder = new TagBuilder("img");

            var imageString = metadata.Model != null ? Convert.ToBase64String(metadata.Model as byte[]):"";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            //builder.Attributes.Add("src",img);
            builder.MergeAttribute("src", img);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));          


            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static IHtmlString HairColorImageFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {

            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            TagBuilder builder = new TagBuilder("img");
            
            builder.MergeAttribute("src", "/Images/HairColorImages/" + metadata.Model + ".jpeg");

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));


            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        //public static IHtmlString ImageFor<TModel,TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression,
        //                             object htmlAttributes = null)
        //{

        //    var name = ExpressionHelper.GetExpressionText(expression);
        //    var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);



        //    var builder = new TagBuilder("img");
        //    builder.MergeAttribute("name", name);
        //    builder.MergeAttribute("src", metadata.Model as string);
        //    builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));


        //    return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        //}

        public static IHtmlString Image(byte[] image, string imgclass,
                                    object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
        public static IHtmlString Image( byte[] image)
        {
            var builder = new TagBuilder("img");
            //builder.MergeAttribute("class", imgclass);
            //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}