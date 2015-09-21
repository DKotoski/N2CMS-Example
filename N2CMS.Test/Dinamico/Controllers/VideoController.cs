using N2.Web;
using N2.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dinamico.Controllers
{

     [Controls(typeof(Models.Pages.Video))]
    public class VideoController : ContentController<Models.Pages.Video>
    {
        //
        // GET: /Video/
        public override ActionResult Index()
        {
            return View(CurrentItem);
        }
	}
}