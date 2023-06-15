using IssueWithAnyAll;
using Microsoft.EntityFrameworkCore;

try
{
    var statusIds = new[] {1, 2, 3, 4};
    var context =
        new DataContext(
            "Server=localhost;Database=exampledb;Integrated Security=SSPI;TrustServerCertificate=True;Application Name=Debuger");

    var result = await context.Requests.Where(o => statusIds.Any(oo => o.StatusId == oo)).ToArrayAsync();
}
catch (Exception e)
{

}
