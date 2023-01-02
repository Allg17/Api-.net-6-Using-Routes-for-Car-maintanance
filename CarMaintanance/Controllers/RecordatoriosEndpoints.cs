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
            return  db.RecordatorioRepository.GetAll();
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

        routes.MapPut("/api/Recordatorios/{id}",  (int RecordatorioID, Recordatorios recordatorios, IMasterRepository db) =>
        {
            var foundModel =  db.RecordatorioRepository.GetById(RecordatorioID);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.RecordatorioRepository.Update(recordatorios);
            return Results.NoContent();
        })
        .WithName("UpdateRecordatorios").RequireAuthorization();

        routes.MapPost("/api/Recordatorios/",  (Recordatorios recordatorios, IMasterRepository db) =>
        {
            db.RecordatorioRepository.Save(recordatorios);
            return Results.Created($"/Recordatorioss/{recordatorios.RecordatorioID}", recordatorios);
        })
        .WithName("CreateRecordatorios").RequireAuthorization();

        routes.MapDelete("/api/Recordatorios/{id}",  (int RecordatorioID, IMasterRepository db) =>
        {
            if ( db.RecordatorioRepository.GetById(RecordatorioID) is Recordatorios recordatorios)
            {
                db.RecordatorioRepository.Delete(RecordatorioID);
                return Results.Ok(recordatorios);
            }

            return Results.NotFound();
        })
        .WithName("DeleteRecordatorios").RequireAuthorization();
    }
}
