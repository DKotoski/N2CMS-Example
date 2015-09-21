using System;
using System.Collections.Generic;
using System.Linq;
using N2.Collections;
using N2.Details;
using N2.Integrity;
using System.Web.UI.WebControls;
using N2;
using Dinamico.Models.Pages;

namespace Dinamico.Models.Parts
{
    [PartDefinition("Video List",
        Description = "A news list box that can be displayed in a column.",
        SortOrder = 160,
        IconUrl = "~/Content/Img/newspaper_go.png")]
    [WithEditableTitle("Title", 10, Required = false)]
    public class VideoList : SidebarItem
    {
        public enum HeadingLevel
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }

        [EditableEnum("Title heading level", 90, typeof (HeadingLevel))]
        public virtual int TitleLevel
        {
            get { return (int) (GetDetail("TitleLevel") ?? 3); }
            set { SetDetail("TitleLevel", value, 3); }
        }

        [EditableLink("News container", 100)]
        public virtual VideoContainerPage Container
        {
            get { return (VideoContainerPage)GetDetail("Container"); }
            set { SetDetail("Container", value); }
        }

        [EditableNumber("Max news", 120)]
        public virtual int MaxNews
        {
            get { return (int) (GetDetail("MaxNews") ?? 3); }
            set { SetDetail("MaxNews", value, 3); }
        }

        [EditableCheckBox("Boxed", 19)]
        public virtual bool Boxed
        {
            get { return GetDetail("Boxed", true); }
            set { SetDetail("Boxed", value, true); }
        }

        public bool IsCentered()
        {
            return ZoneName == Zones.Content || ZoneName == Zones.ColumnLeft || ZoneName == Zones.ColumnRight;
        }
    }
}
