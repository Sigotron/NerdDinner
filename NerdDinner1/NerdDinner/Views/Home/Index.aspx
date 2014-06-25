<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NerdDinner.Dinner>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div>
        
    </div>
</body>
</html>
<h1>Upcoming Dinners</h1>    
<ul>
<% foreach(var d in Model) { %>
    <li>
        <%= d.Title %> (%=d.EventDate %>)
    </li>
<% } %>

</ul>

<p>
    <%=Html.ActionLink("Create New Dinner", "Create") %>
</p>