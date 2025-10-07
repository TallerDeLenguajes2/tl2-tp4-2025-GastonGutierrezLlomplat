namespace  espacioAccesoADatosPedidos;

using espacioPedidos;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoADatosPedidos
{
    private string path = "pedidos.json";

    // public List<Pedido> Obtener()
    // {
    //     if (!File.Exists(path))
    //         return new List<Pedido>();

    //     string json = File.ReadAllText(path);
    //     return JsonSerializer.Deserialize<List<Pedido>>(json)!;
    // }

    public void Guardar(List<Pedido> pedidos)
    {
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}
