using System.Linq;
using N2.Web;
using N2.Web.Mvc;
using N2.Collections;
using N2.Linq;
using N2.Persistence;
using N2.Security;
using Dinamico.Models.Parts;
using N2;
using Dinamico.Models.Pages;

namespace Dinamico.Controllers
{
    [Controls(typeof(VideoList))]
    public class VideoListController : ContentController<VideoList>
    {
        private IContentItemRepository repository;

        public VideoListController(IContentItemRepository repository)
        {
            this.repository = repository;
        }

        public override System.Web.Mvc.ActionResult Index()
        {
            string viewName = CurrentItem.Boxed ? "BoxedList" : "List";

            ContentItem root = CurrentItem.Container;
            if (root == null)
                return View(viewName, Enumerable.Empty<Video>());
            var parameters = Parameter.Below(root) & Parameter.State(ContentState.Published) & Parameter.TypeEqual(typeof(Video).Name);
            var videos = repository.Find(parameters.Take(CurrentItem.MaxNews).OrderBy("Published DESC"))
                .OfType<Video>().ToList();

            return View(viewName, videos.Where(Content.Is.Accessible()));
        }
    }
}
