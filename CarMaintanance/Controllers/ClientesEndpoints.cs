using CarMaintanance.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Controllers
{
    public static class ClientesEndpoints
    {
        public static void MapClientesEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Clientes", async (CarDbContext db) =>
            {
                return await db.Clientes.ToListAsync();
            })
            .WithName("GetAllClientess").RequireAuthorization();

            routes.MapGet("/api/Clientes/{id}", async (int ClienteID, CarDbContext db) =>
            {
                return await db.Clientes.FindAsync(ClienteID)
                    is Clientes model
                        ? Results.Ok(model)
                        : Results.NotFound();
            })
            .WithName(endpointName: "GetClientesById").RequireAuthorization();

            routes.MapPut("/api/Clientes/{id}", async (int ClienteID, Clientes clientes, CarDbContext db) =>
            {
                var foundModel = await db.Clientes.FindAsync(ClienteID);

                if (foundModel is null)
                {
                    return Results.NotFound();
                }

                db.Update(clientes);

                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("UpdateClientes");

            routes.MapPost("/api/Clientes/", async (Clientes clientes, CarDbContext db) =>
            {
                db.Clientes.Add(clientes);
                await db.SaveChangesAsync();
                return Results.Created($"/Clientess/{clientes.ClienteID}", clientes);
            })
            .WithName("CreateClientes").RequireAuthorization();


            routes.MapDelete("/api/Clientes/{id}", async (int ClienteID, CarDbContext db) =>
            {
                if (await db.Clientes.FindAsync(ClienteID) is Clientes clientes)
                {
                    db.Clientes.Remove(clientes);
                    await db.SaveChangesAsync();
                    return Results.Ok(clientes);
                }

                return Results.NotFound();
            })
            .WithName("DeleteClientes").RequireAuthorization();
        }
    }
}
