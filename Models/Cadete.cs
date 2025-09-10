namespace espacioCadetes;

using espacioCadeteria;
using espacioPedidos;
using System.Collections.Generic;
using System.IO;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int jornal;
    private int pedidosRealizados;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.jornal = 0;
        this.pedidosRealizados = 0;
    }
    public int Id
    {
        get => id;
        set => id = value;
    }
    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }
    public string Direccion
    {
        get => direccion;
        set => direccion = value;
    }
    public string Telefono
    {
        get => telefono;
        set => telefono = value;
    }
    public int Jornal
    {
        get => jornal;
        set => jornal = value;
    }
    public int PedidosRealizados
    {
        get => pedidosRealizados;
        set => pedidosRealizados = value;
    }
}
