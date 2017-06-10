<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PaintballTournaments.Core.Tournaments.Prize>" %>

<fieldset>
    <legend>Crea tus premios</legend>
    <p>
        <label>Posici�n:</label>
        <%= Html.DropDownList("RankList") %>
    </p>
    <p>
        <label>Patrocinador:</label>
        <%= Html.TextBox("SponsorSearch") %>
    </p>
    <p>
        <label>Descripci�n:</label>
        <%= Html.TextBox("Description") %>
        <%= Html.ValidationMessage("Descripci�n", "*") %>
    </p>
    <input type="submit" value="Grabar" />
</fieldset>