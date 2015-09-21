using Dinamico.Models;
using Dinamico.Models.Pages;
using N2.Definitions;
using N2.Persistence;
using N2.Web;
using N2.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.Pages.VideoContainerPage))]
    [GroupChildren(GroupChildrenMode.PublishedYearMonth)]
    public class VideoContainerController : ContentController<Models.Pages.VideoContainerPage>
    {
       IContentItemRepository finder;
       public VideoContainerController(IContentItemRepository finder)
        {
            this.finder = finder;
        }

        [NonAction]
        public override ActionResult Index()
        {
            return base.Index();
        }

        public virtual ActionResult Index(string tag)
        {
            var model = string.IsNullOrEmpty(tag) ? GetVideos(0, 20) : GetVideos(tag, 0, 20);
            return View(model);
        }

        public ActionResult Range(int skip, int take, bool? fragment, string tag)
        {
            var model = string.IsNullOrEmpty(tag)
                ? GetVideos(skip, take)
                : GetVideos(tag, skip, take);

            if(fragment.HasValue && fragment.Value)
                return PartialView(model);

            return View("Index", model);
        }

        private  VideoContainerModel GetVideos(string tag, int skip, int take)
        {
     
            var query = (Parameter.Below(CurrentPage) & Parameter.Like("Tags", tag).Detail()).Skip(skip).Take(take + 1).OrderBy("Published DESC");
            var news = finder.Find(query).OfType<Video>().ToList();
            var model = CreateModel(skip, take, news);
            model.Tag = tag;
            return model;
        }

        private VideoContainerModel GetVideos(int skip, int take)
        {
            var query = Parameter.Below(CurrentPage).Skip(skip).Take(take + 1).OrderBy("Published DESC");
            var news = finder.Find(query).OfType<Video>().ToList();

            return CreateModel(skip, take, news);
        }

        private VideoContainerModel CreateModel(int skip, int take, IList<Video> news)
        {
            var model = new VideoContainerModel
            {
                Container = CurrentItem,
                Videos = news,
                Skip = skip,
                Take = take,
                IsLast = news.Count <= take
            };
            if (!model.IsLast)
                model.Videos.RemoveAt(model.Videos.Count - 1);

            return model;
        }
	}
}