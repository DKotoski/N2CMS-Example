using Dinamico.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinamico.Models
{
    public class VideoContainerModel
    {
        public VideoContainerPage Container { get; set; }
        public IList<Video> Videos { get; set; }

        public bool IsLast { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public string Tag { get; set; }
    }
}