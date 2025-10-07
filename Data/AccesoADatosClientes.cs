namespace espacioAccesoADatosClientes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using espacioClientes;

public class AccesoADatosClientes
{
    private string rutaClientes;
    public AccesoADatosClientes()
    {
        // Ruta del archivo JSON
        rutaClientes = Path.Combine(AppContext.BaseDirectory, "Data", "Clientes.json");
    }
    public List<Cliente> Obtener()
    {
        if (!File.Exists(rutaClientes))
        {
            return new List<Cliente>();
        }

        string json = File.ReadAllText(rutaClientes);
        return JsonSerializer.Deserialize<List<Cliente>>(json);
    }

}