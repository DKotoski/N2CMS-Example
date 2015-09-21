using N2;
using N2.Collections;
using N2.Details;
using N2.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinamico.Models.Pages
{

    [WithEditableTitle("Title", 4, Focus = true, ContainerName = Tabs.Content)]
    [TabContainer(Tabs.Content, "Content", 0)]
    [TabContainer(Tabs.Advanced, "Advanced", 100)]
    [SidebarContainer(Tabs.Details, 6, HeadingText = "Details")]
    public class PageBase: ContentItem
    {

        [EditableCheckBox("Show Title", 10, ContainerName = Tabs.Details, DefaultValue = true)]
        public virtual bool ShowTitle { get; set; }

        // helpers

        public virtual IList<T> GetChildren<T>() where T : ContentItem
        {
            return new ItemList<T>(Children,
                                   new AccessFilter(),
                                   new TypeFilter(typeof(T)));
        }

        public virtual IList<T> GetChildren<T>(string zoneName) where T : ContentItem
        {
            return new ItemList<T>(Children,
                                   new AccessFilter(),
                                   new TypeFilter(typeof(T)),
                                   new ZoneFilter(zoneName));
        }
    }

    public class Tabs
    {
        /// <summary>The default content tab when editing.</summary>
        public const string Content = "content";

        /// <summary>The expandable details container.</summary>
        public const string Details = "details";

        /// <summary>Advanced tab while editing.</summary>
        public const string Advanced = "advanced";

        public const int ContentIndex = 0;
        public const int AdvancedIndex = 100;
    }
}