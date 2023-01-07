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
        .WithName("GetAllUsuarioss").RequireAuthorization();

        routes.MapGet("/api/Usuarios/{user}/{clave}",  (string user, string clave, IMasterRepository db) =>
        {
            return  db.UsuarioRepository.Get(username: user, clave: clave)
                is Usuarios model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetUsuariosById").RequireAuthorization();

       
    }
}
