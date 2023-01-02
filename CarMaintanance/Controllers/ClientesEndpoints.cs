using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarMaintanance.Controllers
{
    public static class ClientesEndpoints
    {
        public static void MapClientesEndpoints(this IEndpointRouteBuilder routes)
        {
            var options = new JsonSerializerOptions
            {
               ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            routes.MapGet("/api/Clientes", (IMasterRepository db) =>
            {
                return db.clientesRepository.GetAll();
            })
            .WithName("GetAllClientess").RequireAuthorization();

            routes.MapGet("/api/Clientes/{id}", (int ClienteID, IMasterRepository db) =>
            {
                return db.clientesRepository.GetById(ClienteID);
            })
            .WithName(endpointName: "GetClientesById").RequireAuthorization();

            routes.MapGet("/api/Clientes/GetClienteByCedula/{id}", (string ClienteID, IMasterRepository db) =>
            {
                return db.clientesRepository.GetClienteByCedula(ClienteID);
            })
           .WithName(endpointName: "GetClienteByCedula").RequireAuthorization();

            routes.MapPut("/api/Clientes/{id}", (int ClienteID, Clientes clientes, IMasterRepository db) =>
            {
                var foundModel = db.clientesRepository.Update(clientes);
                return Results.NoContent();
            })
            .WithName("UpdateClientes");

            routes.MapPost("/api/Clientes/", (Clientes clientes, IMasterRepository db) =>
            {
                db.clientesRepository.Save(clientes);
                return Results.Created($"/Clientess/{clientes.ClienteID}", clientes);
            })
            .WithName("CreateClientes").RequireAuthorization();


            routes.MapDelete("/api/Clientes/{id}", (int ClienteID, IMasterRepository db) =>
            {
                if (db.clientesRepository.GetById(ClienteID) is Clientes clientes)
                {
                    db.clientesRepository.Delete(ClienteID);
                    return Results.Ok(clientes);
                }

                return Results.NotFound();
            })
            .WithName("DeleteClientes").RequireAuthorization();
        }
    }
}
