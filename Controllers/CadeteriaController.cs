using Microsoft.AspNetCore.Mvc;       // Necesario para [ApiController], ControllerBase, IActionResult
using espacioCadeteria;               // Para acceder a tu clase Cadeteria
using espacioPedidos;                 // Para acceder a la clase Pedido
using espacioCadetes;                 // Para acceder a la clase Cadete
using espacioClientes;                // Para acceder a la clase Cliente
using System.Collections.Generic;     // Para usar List<>

[ApiController]
[Route("api/[controller]")]
public class CadeteriaController : ControllerBase
{
    private static Cadeteria _cadeteria = new Cadeteria("Mi Cadeteria", 12345678);

    // GET: api/cadeteria/pedidos
    [HttpGet("pedidos")]
    public IActionResult GetPedidos()
    {
        var pedidos = _cadeteria.ListadoPedidos;
        return Ok(pedidos);
    }

    // GET: api/cadeteria/cadetes
    [HttpGet("cadetes")]
    public IActionResult GetCadetes()
    {
        var cadetes = _cadeteria.ListadoCadetes;
        return Ok(cadetes);
    }

    // GET: api/cadeteria/informe
    [HttpGet("informe")]
    public IActionResult GetInforme()
    {
        var informe = _cadeteria.InformeFinal();
        return Ok(informe);
    }

    // POST: api/cadeteria/pedido
    [HttpPost("pedido")]
    public IActionResult AgregarPedido(string observacion, int idCliente)
    {
        var pedidoCreado = _cadeteria.AgregarPedido(observacion, idCliente);
        if (pedidoCreado == null)
            return NotFound("Cliente no encontrado");

        return Ok(pedidoCreado);
    }

    // PUT: api/cadeteria/asignar-pedido
    [HttpPut("asignar-pedido")]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        bool exito = _cadeteria.AsignarCadeteAPedido(idPedido, idCadete);
        if (!exito)
            return NotFound("Pedido o cadete no encontrado");

        return Ok("Pedido asignado correctamente");
    }

    // PUT: api/cadeteria/cambiar-estado
    [HttpPut("cambiar-estado")]
    public IActionResult CambiarEstadoPedido(int idPedido)
    {
        bool exito = _cadeteria.CambiarEstado(idPedido);
        if (!exito)
            return NotFound("Pedido no encontrado.");

        return Ok("Estado del pedido actualizado con éxito");
    }

    // PUT: api/cadeteria/cambiar-cadete
    [HttpPut("cambiar-cadete")]
    public IActionResult CambiarCadetePedido(int idPedido, int idCadete)
    {
        bool exito = _cadeteria.ReasignarPedido(idPedido, idCadete);
        if (!exito)
            return NotFound("El pedido no se pudo reasignar correctamente.");

        return Ok("Pedido reasignado correctamente");
    }
}
