namespace Leatn.Web.Controllers.Post.Mappers
{
    using Machine.Specifications.AutoMocking.Rhino;

    public abstract class context_for_blog_post_save_details_mapper:Specification<BlogPostSaveDetailsMapper>
    {
        
    }

    public class when_the_mapper_is_asked_to_map_from_a_blog_post_for_view_model : context_for_blog_list_page_view_model_mapper
    {
    }
}