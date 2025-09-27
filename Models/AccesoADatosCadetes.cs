namespace espacioAccesoADatosCadetes;

using System.Text.Json;
using espacioCadetes;

class AccesoADatosCadetes
{
    public List<Cadete> Obtener(string archivo)
    {
        List<Cadete> listaCadetesJson = new();
        string textoJson = File.ReadAllText(archivo);
        listaCadetesJson = JsonSerializer.Deserialize<List<Cadete>>(textoJson);

        return listaCadetesJson;

    }
}