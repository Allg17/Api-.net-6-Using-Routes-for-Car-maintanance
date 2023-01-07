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

            routes.MapGet("/api/Clientes/GetClientes/{id}/{limit}", (string id, int limit, IMasterRepository db) =>
            {
                return db.clientesRepository.GetClientes(id,limit);
            })
         .WithName(endpointName: "GetClientes").RequireAuthorization();

            routes.MapPut("/api/Clientes/{id}", (int ClienteID, Clientes clientes, IMasterRepository db) =>
            {
                var foundModel = db.clientesRepository.Update(clientes);
                return Results.NoContent();
            })
            .WithName("UpdateClientes").RequireAuthorization();

            routes.MapPost("/api/Clientes/", (Clientes clientes, IMasterRepository db) =>
            {
                db.clientesRepository.Save(clientes);
                return Results.Created($"/Clientess/{clientes.ClienteID}", clientes);
            })
            .WithName("CreateClientes").RequireAuthorization();
        }
    }
}
