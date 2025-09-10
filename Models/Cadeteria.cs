namespace espacioCadeteria;

using espacioCadetes;
using espacioClientes;
using espacioPedidos;
using System.Collections.Generic;
using System.Linq;
using System;

public class Cadeteria
{
    private string nombre;
    private int telefono;

    private List<Cadete> listadoCadetes = new List<Cadete>();
    private List<Cliente> listadoClientes = new List<Cliente>();
    private List<Pedido> listadoPedidos = new List<Pedido>(); // Todos los pedidos

    public Cadeteria(string nombre, int telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    public string Nombre => nombre;
    public int Telefono => telefono;
    public List<Cadete> ListadoCadetes => listadoCadetes;
    public List<Cliente> ListadoClientes => listadoClientes;
    public List<Pedido> ListadoPedidos => listadoPedidos;

    public Pedido AgregarPedido(string observacion, int idCliente)
    {
        Cliente clienteElegido = listadoClientes.Find(c => c.Id == idCliente);

        if (clienteElegido == null)
        {
            // Retorna null si no se encuentra el cliente
            return null;
        }

        // Crear nuevo pedido
        Pedido nuevoPedido = new Pedido("Pendiente", observacion, clienteElegido);

        // Agregar a la lista de pedidos de la cadetería
        listadoPedidos.Add(nuevoPedido);

        // Retorna el pedido creado
        return nuevoPedido;
    }


    public bool AsignarCadeteAPedido(int idPedido, int idCadete)
    {
        Pedido pedido = listadoPedidos.Find(p => p.NroPedido == idPedido);

        if (pedido == null) { return false; }

        Cadete cadete = listadoCadetes.Find(c => c.Id == idCadete);

        if (cadete == null) { return false; }

        pedido.CadeteAsignado = cadete;
        return true;
    }

    public bool CambiarEstado(int idPedido)
    {
        Pedido pedido = listadoPedidos.Find(p => p.NroPedido == idPedido);

        if (pedido == null)
        {
            return false;
        }

        if (pedido.CadeteAsignado != null)
        {
            pedido.CadeteAsignado.Jornal += 500;
            pedido.CadeteAsignado.PedidosRealizados++;
        }

        return true;
    }

    public bool ReasignarPedido(int idPedido, int idCadete)
    {
        Pedido pedido = listadoPedidos.Find(p => p.NroPedido == idPedido);

        if (pedido == null)
        {
            return false;
        }

        Cadete nuevoCadete = listadoCadetes.Find(c => c.Id == idCadete);

        if (nuevoCadete == null)
        {
            return false;
        }

        pedido.CadeteAsignado = nuevoCadete;
        return true;
    }

    public int JornalACobrar(int idCadete)
    {
        Cadete cadete = listadoCadetes.Find(c => c.Id == idCadete);
        if (cadete == null) return 0;

        int total = listadoPedidos
            .Where(p => p.CadeteAsignado == cadete)
            .Sum(p => 500);
        return total;
    }

    public List<Cadete> VerCadetes()
    {
        return listadoCadetes;
    }

    public List<string> InformeFinal()
    {
        var informe = new List<string>();

        foreach (var cadete in listadoCadetes)
        {
            decimal total = JornalACobrar(cadete.Id);
            informe.Add($"Nombre: {cadete.Nombre}");
            informe.Add($"Pedidos realizados: {cadete.PedidosRealizados}");
            informe.Add($"Jornal a cobrar: ${total}");
            informe.Add(""); // línea vacía entre cadetes
        }

        return informe;
    }

    public bool CargarCadetes(string ruta)
    {
        var lineas = File.ReadAllLines(ruta);

        // Saltamos la primera línea (cabecera)
        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');

            int id = int.Parse(datos[0]);
            string nombre = datos[1];
            string direccion = datos[2];
            string telefono = datos[3];

            listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
        }

        return true;
    }

    public bool CargarClientes(string ruta)
    {
        var lineas = File.ReadAllLines(ruta);

        // Saltamos la primera línea (cabecera)
        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');

            int id = int.Parse(datos[0]);
            string nombre = datos[1];
            string direccion = datos[2];
            string telefono = datos[3];

            listadoClientes.Add(new Cliente(id, nombre, direccion, telefono));
        }

        return true;
    }

}
