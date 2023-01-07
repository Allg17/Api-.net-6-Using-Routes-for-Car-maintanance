using Microsoft.EntityFrameworkCore;
using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Controllers;

public static class FacturasEndpoints
{
    public static void MapFacturasEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Facturas", (IMasterRepository db) =>
        {
            return db.FacturasRepository.GetAllFacturas();
        })
        .WithName("GetAllFacturass").RequireAuthorization(); ;

        routes.MapGet("/api/Facturas/{id}",  (int id, IMasterRepository db) =>
        {
            return db.FacturasRepository.GetFactura(id)
                is Facturas model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetFacturasById").RequireAuthorization(); ;

        routes.MapPut("/api/Facturas", (Facturas facturas, IMasterRepository db) =>
        {
            db.FacturasRepository.Updatefactura(facturas);
            return Results.Created($"/Facturass/{facturas.FacturasID}", facturas);
        })
        .WithName("UpdateFacturas").RequireAuthorization(); ;

        routes.MapPost("/api/Facturas/", (Facturas facturas, IMasterRepository db) =>
        {
            db.FacturasRepository.CrearFactura(facturas);
            return Results.Created($"/Facturass/{facturas.FacturasID}", facturas);
        })
        .WithName("CreateFacturas").RequireAuthorization();
    }
}
