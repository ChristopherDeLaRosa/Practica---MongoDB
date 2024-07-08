using ProvinciasMongoDB;


var mongoService = new MongoDBService();

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Ingresar nueva provincia");
    Console.WriteLine("2. Mostrar todas las provincias");
    Console.WriteLine("3. Salir\n\n");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("\nIngrese el nombre de la provincia:");
            var nombre = Console.ReadLine();
            var provincia = new Provincia { Nombre = nombre };
            await mongoService.InsertProvinciaAsync(provincia);
            Console.WriteLine("\n\n\tProvincia ingresada con éxito.\n\n");
            break;
        case "2":
            var provincias = await mongoService.GetAllProvinciasAsync();
            Console.WriteLine("\nProvincias en la base de datos:\n\n");
            foreach (var p in provincias)
            {
                Console.WriteLine($"Id: {p.Id}, Nombre: {p.Nombre}");
            }
            break;
        case "3":
            return;
        default:
            Console.WriteLine("Opción no válida, intente de nuevo.");
            break;
    }
}

