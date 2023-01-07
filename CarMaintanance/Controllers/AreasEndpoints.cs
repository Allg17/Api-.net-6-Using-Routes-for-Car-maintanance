using Microsoft.EntityFrameworkCore;
using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Controllers;

public static class AreasEndpoints
{
    public static void MapAreasEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Areas",  (IMasterRepository db) =>
        {
            return  db.AreaRepository.GetAll();
        })
        .WithName("GetAllAreass").RequireAuthorization();

        routes.MapGet("/api/Areas/GetAreas/{id}/{limit}", (string id, int limit, IMasterRepository db) =>
        {
            return db.AreaRepository.GetAreas(id, limit);
        })
         .WithName(endpointName: "GetAreas").RequireAuthorization();

    }
}
