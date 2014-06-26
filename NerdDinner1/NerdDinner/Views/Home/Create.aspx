<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<NerdDinner.Dinner>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
    
        <fieldset>
            <legend>Dinner</legend>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EventDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.EventDate) %>
                <%: Html.ValidationMessageFor(model => model.EventDate) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address) %>
                <%: Html.ValidationMessageFor(model => model.Address) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.HostedBy) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.HostedBy) %>
                <%: Html.ValidationMessageFor(model => model.HostedBy) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Country) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Country) %>
                <%: Html.ValidationMessageFor(model => model.Country) %>
            </div>
    
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</body>
</html>
