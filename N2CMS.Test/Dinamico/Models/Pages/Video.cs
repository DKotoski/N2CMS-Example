using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dinamico.Models.Pages
{
    [PageDefinition("Video", Description = "A video page.", SortOrder = 155,
       IconClass = "fa fa-file blue")]
    [RestrictParents(typeof(VideoContainerPage))]
    public class Video : ContentPageBase, ISyndicatable
    {

        public Video()
        {
            Visible = false;
            Syndicate = true;
        }

        [EditableUrl("Video Url",150)]
        public virtual string VideoUrl { get; set; }

        [Persistable(PersistAs = PropertyPersistenceLocation.Detail)]
        public virtual bool Syndicate { get; set; }

        [EditableTags(SortOrder = 200)]
        public virtual IEnumerable<string> Tags { get; set; }
    }
}
