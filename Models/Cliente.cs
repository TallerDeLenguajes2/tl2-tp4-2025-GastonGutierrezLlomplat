namespace espacioClientes;

public class Cliente
{
    private int id;
    private string nombre;
    private string telefono;
    private string direccion;

    public Cliente(int id, string nombre, string telefono, string direccion)
    {
        this.id = id;
        this.nombre = nombre;
        this.telefono = telefono;
        this.direccion = direccion;
    }

    public int Id => id;
    public string Nombre => nombre;
    public string Telefono => telefono;
    public string Direccion => direccion;
}
