using Microsoft.EntityFrameworkCore;
using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Controllers;

public static class RecordatoriosEndpoints
{
    public static void MapRecordatoriosEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Recordatorios",  (IMasterRepository db) =>
        {
            return  db.RecordatorioRepository.GetallRecordatorio();
        })
        .WithName("GetAllRecordatorioss").RequireAuthorization();

        routes.MapGet("/api/Recordatorios/{id}", (int RecordatorioID, IMasterRepository db) =>
        {
            return db.RecordatorioRepository.GetById(RecordatorioID)
                is Recordatorios model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetRecordatoriosById").RequireAuthorization();

        routes.MapPut("/api/Recordatorios",  ( Recordatorios recordatorios, IMasterRepository db) =>
        {
            recordatorios.Cliente = null;
            db.RecordatorioRepository.Update(recordatorios);
            return Results.NoContent();
        })
        .WithName("UpdateRecordatorios").RequireAuthorization();

        routes.MapPost("/api/Recordatorios/", (Recordatorios recordatorios, IMasterRepository db) =>
        {
            recordatorios.ClienteID = recordatorios.Cliente.ClienteID;
            recordatorios.Cliente = null;
            db.RecordatorioRepository.Save(recordatorios);
            return Results.Created($"/Recordatorioss/{recordatorios.RecordatorioID}", recordatorios);
        })
           .WithName("CreateRecordatorios").RequireAuthorization();

    }
}
