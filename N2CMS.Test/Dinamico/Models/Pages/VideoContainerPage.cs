using N2;
using N2.Definitions;
using N2.Integrity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinamico.Models.Pages
{
    [PageDefinition("Video Container",
    Description = "A list of Videos. Videos can be added to this page.",
    SortOrder = 150,
    IconClass = "fa fa-list blue")]
    [RestrictParents(typeof(IStructuralPage))]
    [SortChildren(SortBy.PublishedDescending)]
    [GroupChildren(GroupChildrenMode.PublishedYear)]
    public class VideoContainerPage:ContentPageBase
    {
        public IList<Video> Videos
        {
            get { return Children.OfType<Video>().ToList(); }
        }
    }
}