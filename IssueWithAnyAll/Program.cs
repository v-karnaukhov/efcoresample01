using IssueWithAnyAll;
using Microsoft.EntityFrameworkCore;

try
{
    var statusIds = new[] {1, 2, 3, 4};
    var types = new[] {7, 8, 9};
    var context =
        new DataContext(
            "Server=localhost;Database=exampledb;User Id=tendercommittee;Password=tendercommittee;TrustServerCertificate=True;Application Name=Debuger");

    var byTypes = await context.Requests.Where(o => types.Any(oo => o.TypeId == oo)).ToArrayAsync();
    var byStatuses = await context.Requests.Where(o => statusIds.Any(oo => o.StatusId == oo)).ToArrayAsync();
}
catch (Exception e)
{

}
