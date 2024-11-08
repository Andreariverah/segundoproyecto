using System;

namespace Genericos
{
    using System;

    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Gestión de Inventario ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Mostrar Todos los Productos");
                Console.WriteLine("3. Filtrar Productos por Precio");
                Console.WriteLine("4. Actualizar Precio de un Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("6. Contar Productos por Rango de Precio");
                Console.WriteLine("7. Generar Reporte Resumido del Inventario");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        string nombre;
                        do
                        {
                            Console.Write("Ingrese el nombre del producto: ");
                            nombre = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nombre))
                            {
                                Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");
                            }
                        } while (string.IsNullOrWhiteSpace(nombre));

                        decimal precio;
                        do
                        {
                            Console.Write("Ingrese el precio del producto: ");
                            if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                            {
                                Console.WriteLine("El precio debe ser un número positivo. Intente nuevamente.");
                            }
                        } while (precio <= 0);

                        inventario.AgregarProducto(new Producto(nombre, precio));
                        Console.WriteLine("Producto agregado exitosamente.");
                        break;

                    case "2":
                        Console.WriteLine("\nLista de productos:");
                        inventario.MostrarProductos();
                        break;

                    case "3":
                        Console.Write("Ingrese el precio mínimo para filtrar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal precioMin))
                        {
                            var productosFiltrados = inventario.FiltrarPorPrecio(precioMin);
                            Console.WriteLine($"\nProductos con precio mayor a {precioMin:C}:");
                            foreach (var producto in productosFiltrados)
                            {
                                producto.MostrarInformacion();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Intente nuevamente.");
                        }
                        break;

                    case "4":
                        Console.Write("Ingrese el nombre del producto a actualizar: ");
                        string nombreActualizar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombreActualizar))
                        {
                            Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");
                            break;
                        }

                        Console.Write("Ingrese el nuevo precio: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) && nuevoPrecio > 0)
                        {
                            inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                        }
                        else
                        {
                            Console.WriteLine("El precio debe ser un número positivo. Intente nuevamente.");
                        }
                        break;

                    case "5":
                        Console.Write("Ingrese el nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombreEliminar))
                        {
                            Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");
                            break;
                        }
                        inventario.EliminarProducto(nombreEliminar);
                        break;

                    case "6":
                        inventario.ContarProductosPorRangoDePrecio();
                        break;

                    case "7":
                        inventario.GenerarReporteResumido();
                        break;

                    case "8":
                        continuar = false;
                        Console.WriteLine("Gracias por usar el sistema de gestión de inventario. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}