﻿using Microsoft.EntityFrameworkCore;
using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Controllers;

public static class SolicitudesEndpoints
{
    public static void MapSolicitudesEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Solicitudes",  (IMasterRepository db) =>
        {
            return db.SolicitudesRepository.GetallSolicitudes()
                is List<Solicitudes> model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetAllSolicitudess").RequireAuthorization();

        routes.MapGet("/api/Solicitudes/{id}",  (int id, IMasterRepository db) =>
        {
            return db.SolicitudesRepository.GetSolicitud(id)
                is Solicitudes model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetSolicitudesById").RequireAuthorization();

        routes.MapPut("/api/Solicitudes",  (Solicitudes solicitudes, IMasterRepository db) =>
        {
            try
            {
                solicitudes.Detalle.ForEach(x => x.Area = null);
                var paso = db.SolicitudesRepository.AddUpdateOrDelete(solicitudes);
                return Results.Ok(paso > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        })
        .WithName("UpdateSolicitudes").RequireAuthorization();

        routes.MapPut("/api/Solicitudes/UpdateSolicitudesDespacho", (int id, IMasterRepository db) =>
        {
            try
            {
                var paso = db.SolicitudesRepository.Despachar(id);
                return Results.Ok(paso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        })
        .WithName("UpdateSolicitudesDespacho").RequireAuthorization();

        routes.MapPost("/api/Solicitudes/{id}", async (Solicitudes solicitudes, IMasterRepository db) =>
        {
            try
            {
                solicitudes.Detalle.ForEach(x => x.Area = null);

                db.SolicitudesRepository.Save(solicitudes);
                return Results.Created($"/Solicitudess/{solicitudes.SolicitudID}", solicitudes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        })
        .WithName("CreateSolicitudes").RequireAuthorization();

    }
}
