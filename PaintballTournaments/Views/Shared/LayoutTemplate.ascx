<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<LayoutTemplate>" %>
<%@ Import Namespace="PaintballTournaments.Web.Controllers.MVCInteraction"%>
<%@ Import Namespace="PaintballTournaments.Core.Tournaments"%>
<div id="<%= "Bunker_" + Model.Id %>" class="LayoutTemplate">
    <img src="<%= Resources.GetLayoutTemplatePath(Model) %>" alt="<%= "Made by: " + Model.Creator %>" /><span>Made by: <%= Model.Creator %></span>
</div>



