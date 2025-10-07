namespace espacioAccesoADatosCadetes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using espacioCadetes;

public class AccesoADatosCadetes
{
    private string rutaCadetes;
    public AccesoADatosCadetes()
    {
        // Ruta del archivo JSON
        rutaCadetes = Path.Combine(AppContext.BaseDirectory, "Data", "Cadetes.json");
    }
    public List<Cadete> Obtener()
    {
        if (!File.Exists(rutaCadetes))
        {
            return new List<Cadete>();
        }

        string json = File.ReadAllText(rutaCadetes);
        return JsonSerializer.Deserialize<List<Cadete>>(json);
    }

}