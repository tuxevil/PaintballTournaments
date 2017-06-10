<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Bunker>" %>
<%@ Import Namespace="PaintballTournaments.Web.Controllers.MVCInteraction"%>
<%@ Import Namespace="PaintballTournaments.Core.Tournaments"%>
<div id="<%= "Bunker_" + Model.Id %>" class="Moving_Bunker">
    <img src="<%= Resources.GetBunkerPath(Model) %>" alt="<%= Model.Name %>" thumb="<%= Resources.GetBunkerThumbnailPath(Model) %>" /><br /><span><%= Model.Name %></span>
</div>

