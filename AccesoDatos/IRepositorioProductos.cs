using System.Collections.Generic;
using FinalProgram.Modelos;

namespace FinalProgram.AccesoDatos
{
  public interface IRepositorioProductos
  {
    List<Producto> ObtenerTodos();
    Producto ObtenerPorId(int id);
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
    void Eliminar(int id);
    void ActualizarStock(int id, int nuevoStock);
  }
}
