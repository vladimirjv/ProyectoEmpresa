using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            char opcion;
            Empresa tamsa = new Empresa("TAMSA S.A. de C.V.");
            
                do
                {
                
                    Console.Clear();
                    Console.WriteLine("Emplesa {0}          Número de empleados : {1}", tamsa.Nombre, tamsa.Lista.Count());
                    Console.WriteLine("[A] gregar:");
                    Console.WriteLine("[E] liminar:");
                    Console.WriteLine("[U] pdate:");
                    Console.WriteLine("[N] omina:");
                    Console.Write("[S] alir\n\nSeleccione Opción: ");
                    opcion = Convert.ToChar(Console.ReadLine().ToUpper().ElementAt(0));
                try { 
                    switch (opcion)
                    {
                        case 'A':
                            tamsa.Agregar();
                            break;
                        case 'E':
                            tamsa.Eliminar();
                            break;
                        case 'U':
                            tamsa.Actualizar();
                            break;
                        case 'N':
                            tamsa.Nomina();
                            break;
                        case 'S':
                            break;
                        default:
                            Console.WriteLine("Opción No Válida.");
                            break;
                    }
                }
                catch(System.ArgumentOutOfRangeException) {}
                } while (opcion != 'S');
            }

        }
    }
}
