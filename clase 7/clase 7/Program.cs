using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_7
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Tienda tienda1 = new Tienda("Zapatos Felices");
            Tienda tienda2 = new Tienda("Zapatería Elegante");

            
            tienda1.AgregarZapato(new Zapato("Botas de cuero", "Santoni", "Hombre", 10, 100, 0.2));
            tienda1.AgregarZapato(new Zapato("Zapatos de vestir", "Corthay", "Hombre", 9, 120, 0.25));
            tienda1.AgregarZapato(new Zapato("Zapatillas deportivas", "Adoc", "Mujer", 8, 80, 0.2));
            tienda1.AgregarZapato(new Zapato("Tacones altos", "Prada", "Mujer", 7, 150, 0.1));
            tienda2.AgregarZapato(new Zapato("Botas de cuero", "Corthay", "Hombre", 10, 100, 0.23));
            tienda2.AgregarZapato(new Zapato("Zapatos de vestir", "Santoni", "Hombre", 9, 120, 0.28));
            tienda2.AgregarZapato(new Zapato("Zapatillas deportivas", "Adiddas", "Mujer", 8, 80, 0.2));
            tienda2.AgregarZapato(new Zapato("Tacones altos", "Mqueen", "Mujer", 7, 150, 0.1));

            
            Console.WriteLine("Tiendas disponibles:");
            Console.WriteLine("1. " + tienda1.Nombre);
            Console.WriteLine("2. " + tienda2.Nombre);

            Console.Write("\nSeleccione una tienda: ");
            int opcionTienda = Convert.ToInt32(Console.ReadLine());

            Tienda tiendaSeleccionada = null;

           
            switch (opcionTienda)
            {
                case 1:
                    tiendaSeleccionada = tienda1;
                    break;
                case 2:
                    tiendaSeleccionada = tienda2;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            if (tiendaSeleccionada != null)
            {
                
                Console.Write("\nSeleccione el género que busca (Hombre o Mujer): ");
                string generoSeleccionado = Console.ReadLine();

                
                List<Zapato> catalogoFiltrado = tiendaSeleccionada.FiltrarPorGenero(generoSeleccionado);

                if (catalogoFiltrado.Count > 0)
                {
                    Console.WriteLine("\nCatálogo de " + tiendaSeleccionada.Nombre + " para " + generoSeleccionado + ":");
                    tiendaSeleccionada.MostrarCatalogo(catalogoFiltrado);

                    
                    Console.Write("Seleccione un zapato por su número de orden: ");
                    int opcionZapato = Convert.ToInt32(Console.ReadLine());

                    Zapato zapatoSeleccionado = null;

                    if (opcionZapato > 0 && opcionZapato <= catalogoFiltrado.Count)
                    {
                        zapatoSeleccionado = catalogoFiltrado[opcionZapato - 1];
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida");
                    }

                    if (zapatoSeleccionado != null)
                    {
                        Console.WriteLine("\nDetalles del zapato seleccionado:");
                        Console.WriteLine("Estilo: " + zapatoSeleccionado.Estilo);
                        Console.WriteLine("Marca: " + zapatoSeleccionado.Marca);
                        Console.WriteLine("Talla: " + zapatoSeleccionado.Talla);
                        Console.WriteLine("Precio: $" + zapatoSeleccionado.Precio);
                        Console.WriteLine("Este zapato cuenta con un descueto");

                        if (zapatoSeleccionado.Descuento > 0)
                        {
                            Console.WriteLine("Descuento: " + (zapatoSeleccionado.Descuento * 100) + "%");
                            Console.WriteLine("Precio con descuento: $" + zapatoSeleccionado.PrecioConDescuento());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay zapatos disponibles para el género seleccionado");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    class Tienda
    {
        public string Nombre { get; set; }
        private List<Zapato> Catalogo { get; set; }

        public Tienda(string nombre)
        {
            Nombre = nombre;
            Catalogo = new List<Zapato>();
        }

        public void AgregarZapato(Zapato zapato)
        {
            Catalogo.Add(zapato);
        }

        public List<Zapato> FiltrarPorGenero(string genero)
        {
            List<Zapato> catalogoFiltrado = new List<Zapato>();

            foreach (Zapato zapato in Catalogo)
            {
                if (zapato.Genero.ToLower() == genero.ToLower())
                {
                    catalogoFiltrado.Add(zapato);
                }
            }

            return catalogoFiltrado;
        }

        public void MostrarCatalogo(List<Zapato> catalogo)
        {
            for (int i = 0; i < catalogo.Count; i++)
            {
                Zapato zapato = catalogo[i];
                Console.Write((i + 1) + ". " + zapato.Estilo + " - " + zapato.Marca + " - Talla " + zapato.Talla + " - $" + zapato.Precio);

                if (zapato.Descuento > 0)
                {
                    Console.Write(" (con " + (zapato.Descuento * 100) + "% de descuento)");
                }

                Console.WriteLine();
            }
        }
    }

    class Zapato
    {
        public string Estilo { get; set; }
        public string Marca { get; set; }
        public string Genero { get; set; }
        public int Talla { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }

        public Zapato(string estilo, string marca, string genero, int talla, double precio, double descuento = 0)
        {
            Estilo = estilo;
            Marca = marca;
            Genero = genero;
            Talla = talla;
            Precio = precio;
            Descuento = descuento;
        }

        public double PrecioConDescuento()
        {
            return Precio * (1 - Descuento);
        }
    }
}

