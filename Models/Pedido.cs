namespace espacioPedidos;

using espacioClientes;
using espacioCadetes;

public class Pedido
{
    private static int ultimoId = 0;

    private int nroPedido;
    private string estado;
    private string observacion;
    private Cliente cliente;
    private Cadete cadeteAsignado;

    public Pedido(string estado, string observacion, Cliente cliente)
    {
        nroPedido = ++ultimoId;
        this.estado = estado;
        this.observacion = observacion;
        this.cliente = cliente;
        cadeteAsignado = null;
    }

    public int NroPedido => nroPedido;
    public string Estado
    {
        get => estado;
        set => estado = value;
    }
    public string Observacion
    {
        get => observacion;
        set => observacion = value;
    }
    public Cliente Cliente => cliente;
    public Cadete CadeteAsignado
    {
        get => cadeteAsignado;
        set => cadeteAsignado = value;
    }

    public string VerDireccionCliente()
    {
        return this.cliente.Direccion;
    }
}
