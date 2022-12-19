namespace SchneiderElectric.NbApi.Models
{
    public class Equipment
    {
    }


public static class EquipmentEndpoints
{
	public static void MapEquipmentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Equipment", () =>
        {
            return new [] { new Equipment() };
        })
        .WithName("GetAllEquipments")
        .Produces<Equipment[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Equipment/{id}", (int id) =>
        {
            //return new Equipment { ID = id };
        })
        .WithName("GetEquipmentById")
        .Produces<Equipment>(StatusCodes.Status200OK);

        routes.MapPut("/api/Equipment/{id}", (int id, Equipment input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateEquipment")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Equipment/", (Equipment model) =>
        {
            //return Results.Created($"/Equipments/{model.ID}", model);
        })
        .WithName("CreateEquipment")
        .Produces<Equipment>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Equipment/{id}", (int id) =>
        {
            //return Results.Ok(new Equipment { ID = id });
        })
        .WithName("DeleteEquipment")
        .Produces<Equipment>(StatusCodes.Status200OK);
    }
}}
