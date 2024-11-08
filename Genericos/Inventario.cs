using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarPorPrecio(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"Precio del producto '{nombre}' actualizado a {nuevoPrecio:C}");
            }
            else
            {
                Console.WriteLine($"Producto con nombre '{nombre}' no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto '{nombre}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"Producto con nombre '{nombre}' no encontrado.");
            }
        }

        public void MostrarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
            }
        }

        public void ContarProductosPorRangoDePrecio()
        {
            int menoresA100 = productos.Count(p => p.Precio < 100);
            int entre100y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500);
            int mayoresA500 = productos.Count(p => p.Precio > 500);

            Console.WriteLine("\n--- Conteo de Productos por Rango de Precio ---");
            Console.WriteLine($"Menores a 100: {menoresA100}");
            Console.WriteLine($"Entre 100 y 500: {entre100y500}");
            Console.WriteLine($"Mayores a 500: {mayoresA500}");
        }

        public void GenerarReporteResumido()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("\nEl inventario está vacío. No hay productos para mostrar en el reporte.");
                return;
            }

            int totalProductos = productos.Count;
            decimal precioPromedio = productos.Average(p => p.Precio);
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine("\n--- Reporte Resumido del Inventario ---");
            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto con el precio más alto: {productoMasCaro.Nombre} ({productoMasCaro.Precio:C})");
            Console.WriteLine($"Producto con el precio más bajo: {productoMasBarato.Nombre} ({productoMasBarato.Precio:C})");
        }
    }
}