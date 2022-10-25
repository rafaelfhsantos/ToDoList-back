using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.ApiEndpoints
{
    public static class ToDosEndpoints
    {
        public static void MapToDosEndpoints(this WebApplication app)
        {
            app.MapPost("/toDos", async (ToDo toDo, AppDbContext db) =>
            {
                if (toDo is null)  { return Results.BadRequest(); } 
                
                db.ToDos.Add(toDo);
                await db.SaveChangesAsync();

                return Results.Created($"/toDos/{toDo.Id}", toDo);
            });

            app.MapGet("/toDos", async (AppDbContext db) => await db.ToDos.ToListAsync());

            app.MapGet("/toDos/{id:int}", async (int id, AppDbContext db) =>
            {
                var toDo = await db.ToDos.FindAsync(id);
                if (toDo is null) { return Results.NotFound(); }

                return Results.Ok(toDo);
            });

            app.MapPost("/toDos/{id:int}/setDone", async (int id, AppDbContext db) =>
            {
                var toDo = await db.ToDos.FindAsync(id);
                if (toDo is null) { return Results.NotFound(); }
                toDo.IsDone = toDo.IsDone ? false : true ;                
                await db.SaveChangesAsync();

                return Results.Ok(toDo);
            });

            app.MapDelete("/toDos/{id:int}", async (int id, AppDbContext db) =>
            {
                var toDo = await db.ToDos.FindAsync(id);
                if (toDo is null) { return Results.NotFound(); }
                db.ToDos.Remove(toDo);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapPut("/toDos/{id:int}", async (int id, ToDo toDo, AppDbContext db) =>
            {                
                var dbToDo = await db.ToDos.FindAsync(id);                
                if (dbToDo is null) { return Results.NotFound(); }
                dbToDo.Name = toDo.Name;
                dbToDo.Description = toDo.Description;
                dbToDo.IsDone = toDo.IsDone;

                await db.SaveChangesAsync();

                return Results.Ok(dbToDo);
            });


        }
    }
}
