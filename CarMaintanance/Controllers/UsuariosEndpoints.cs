using Microsoft.EntityFrameworkCore;
using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Controllers;

public static class UsuariosEndpoints
{
    public static void MapUsuariosEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Usuarios", async (CarDbContext db) =>
        {
            return await db.Usuarios.ToListAsync();
        })
        .WithName("GetAllUsuarioss");

        routes.MapGet("/api/Usuarios/{user}/{clave}",  (string user, string clave, IMasterRepository db) =>
        {
            return  db.UsuarioRepository.Get(username: user, clave: clave)
                is Usuarios model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetUsuariosById");

        routes.MapPut("/api/Usuarios/{id}", async (int UsuarioID, Usuarios usuarios, CarDbContext db) =>
        {
            var foundModel = await db.Usuarios.FindAsync(UsuarioID);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(usuarios);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateUsuarios");

        routes.MapPost("/api/Usuarios/", async (Usuarios usuarios, CarDbContext db) =>
        {
            db.Usuarios.Add(usuarios);
            await db.SaveChangesAsync();
            return Results.Created($"/Usuarioss/{usuarios.UsuarioID}", usuarios);
        })
        .WithName("CreateUsuarios");

        routes.MapDelete("/api/Usuarios/{id}", async (int UsuarioID, CarDbContext db) =>
        {
            if (await db.Usuarios.FindAsync(UsuarioID) is Usuarios usuarios)
            {
                db.Usuarios.Remove(usuarios);
                await db.SaveChangesAsync();
                return Results.Ok(usuarios);
            }

            return Results.NotFound();
        })
        .WithName("DeleteUsuarios");
    }
}
