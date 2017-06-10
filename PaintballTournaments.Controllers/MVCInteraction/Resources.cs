using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PaintballTournaments.Core.Tournaments;

namespace PaintballTournaments.Web.Controllers.MVCInteraction
{
    public static class Resources
    {
        public static string GetRootPath()
        {
            return "/res";
        }

        public static string GetPath(string type, string imageUri)
        {
            return GetRootPath() + "/" + type + "/" + imageUri;
        }

        public static string GetBunkerThumbnailPath(Bunker bunker)
        {
            string fileName = Path.GetFileNameWithoutExtension(bunker.ImageUri);
            return "/img/Layout/" + fileName + ".png";
        }

        public static string GetBunkerPath(Bunker bunker)
        {
            return GetRootPath() + "/Bunker/" + bunker.ImageUri;
        }

        public static string GetLayoutTemplatePath(LayoutTemplate layoutTemplate)
        {
            return GetRootPath() + "/LayoutTemplate/" + layoutTemplate.ImageUri;
        }
    }
}
