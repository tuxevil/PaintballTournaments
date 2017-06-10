using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PaintballTournaments.Core.Accounts;
using PaintballTournaments.Core.Tournaments;

namespace PaintballTournaments.Web.Controllers
{
    [HandleError]
    public class BuildYourLeagueController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Index()
        {
            League league = new League();
            return View(league);
        }

        public RedirectToRouteResult CreateLeague(League league, IList<Prize> prizes, IList<Sponsor> sponsors)
        {
            foreach (Prize prize in prizes)
                league.AddPrize(prize);
            foreach (Sponsor sponsor in sponsors)
                league.AddSponsor(sponsor);

            Session["TempLeague"] = league;
            return RedirectToAction("Events");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult Events()
        {
            League league =(League) Session["TempLeague"];
            return View(league);
        }

        public RedirectToRouteResult CreateCategories(Event @event, IList<Category> categories)
        {
            foreach (Category category in categories)
                @event.AddCategory(category);

            //Session["TempLeague"] = league;
            return RedirectToAction("Events");
        }

        public RedirectToRouteResult CreateEvents(League league, IList<Event> events)
        {
            foreach (Event @event in events)
                league.AddEvent(@event);

            Session["TempLeague"] = league;
            return RedirectToAction("Events");
        }
    }
}
