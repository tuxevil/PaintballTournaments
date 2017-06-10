<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PaintballTournaments.Core.Tournaments.Prize>" %>

<fieldset>
    <legend>Crea tus premios</legend>
    <p>
        <label>Posición:</label>
        <%= Html.DropDownList("RankList") %>
    </p>
    <p>
        <label>Patrocinador:</label>
        <%= Html.TextBox("SponsorSearch") %>
    </p>
    <p>
        <label>Descripción:</label>
        <%= Html.TextBox("Description") %>
        <%= Html.ValidationMessage("Descripción", "*") %>
    </p>
    <input type="submit" value="Grabar" />
</fieldset>