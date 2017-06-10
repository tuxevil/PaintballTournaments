<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Layout>" %>
<%@ Import Namespace="PaintballTournaments.Core.Tournaments"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Layout Creation
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="Body_Content">
        <div class="Layout_Templates">
            <%
                foreach (LayoutTemplate template in (List<LayoutTemplate>)ViewData["LayoutTemplates"])
                {
                    Html.RenderPartial("LayoutTemplate", template);
                }%>
        </div>
    
        <div class="Layout_Bunkers">
            <%
                foreach (Bunker bunker in (List<Bunker>)ViewData["Bunkers"])
                {
                    Html.RenderPartial("Bunker", bunker);
                }%>
        </div>
        
        <div id="Layout_Field" class="Layout_Field">
            <div id="Layout_Field_North" class="Layout_Field_Zone"></div>
            <div id="Layout_Field_South" class="Layout_Field_Zone"></div>
            <div id="bunkerContainment" class="dragBunkerMessage" >
                <span id="bunkersMessage">Drag the bunkers here</span>                
            </div>  
        </div>
        <div style="clear: both;"></div>
        
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script type="text/javascript">
    var zIndex = 1;
    $(document).ready(function() {
        ApplyFunctionsToBunkers();

        $("#Layout_Field_North").droppable({
            accept: '.Moving_Bunker',
            drop: function(event, ui) {
                AddToZone(this, ui, "#Layout_Field_North", 1);
                AddToZone($("#Layout_Field_South"), ui, "#Layout_Field_South", 2);

                $("#bunkersMessage").fadeOut("normal");

                $(".ui-icon").hide();
            }
        });
    });

    function AddToZone(div, bunker, zone, type) {

        //var temp = $(bunker.helper).css("cursor", "move").addClass("drag_" + $(bunker.helper)[0].id).clone();
        //if (type == 2)
        //    temp[0].outerHTML = temp[0].outerHTML.replace("TOP", "BOTTOM");
        var $temp = $(bunker.helper).css("cursor", "move").addClass("drag_" + $(bunker.helper)[0].id).clone();
        $temp.empty();
        var $newimg = "<img id='" + $temp[0].id + "' src='" + $(bunker.helper).children("img").attr("thumb") + "' />";
        $temp.append($newimg);
        
        $(div).append($temp);

        $(zone + " .Moving_Bunker").addClass("item");
        $(".item").removeClass("ui-draggable Moving_Bunker");
        $(".item").draggable({
            containment: zone,
            start: function(event, ui) {
                //clearDraggableItems();
                selectDraggableItem(ui.helper);
            }
        });
        $(".item").addClass("Moving_Bunker_Thumb");
    }
    
    function ApplyFunctionsToBunkers() {
        $(".Moving_Bunker").draggable({ helper: 'clone', zIndex: 1, stack: { group: '#set div', min: 1} });
    }

    function selectDraggableItem(elm) {
        $(elm).addClass("draggableBunker");
        $(elm).find(".ui-icon").show();
        $(elm).css("zIndex", zIndex++);

        if ($(elm).find(".closeBunker").length == 0) {
            $(elm).css("overflow", "visible");
            $(elm).prepend("<img src='/img/close.png' class='closeBunker' />");
            $(".closeBunker").click(function(e) {
                $(this).parent().hide();
                if ($(".item:visible").length == 0)
                    $("#bunkersMessage").fadeIn("normal");
            });

        }
    }

    function clearDraggableItems() {
        $(".draggableBunker").removeClass("draggableBunker");
        $(".closeBunker").remove();
        $(".ui-icon").hide();
    }
</script>
</asp:Content>