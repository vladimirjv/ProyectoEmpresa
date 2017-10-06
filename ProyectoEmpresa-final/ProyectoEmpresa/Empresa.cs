using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoEmpresa
{
    class Empresa
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        List<Empleado> lista;
        internal List<Empleado> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        //Constructor.
        public Empresa(string nombre)
        {
            this.nombre = nombre;
            lista = new List<Empleado>();
        }

        //Métodos.
        public void Agregar()
        {
            Empleado empleado = null;
            Console.Clear();

            Console.Write("<---------------Datos Del Empleado--------------->\nNombre: ");
            string nombre = Convert.ToString(Console.ReadLine());
            Console.Write("Dirección: ");
            string direccion = Convert.ToString(Console.ReadLine());
            Console.Write("E-mail: ");
            string email = Convert.ToString(Console.ReadLine());
            Console.Write("Teléfono: ");
            string telefono = Convert.ToString(Console.ReadLine());
            DatosPersonales datos = new DatosPersonales(nombre, direccion, email, telefono);

            Console.WriteLine("\n<-----------------Tipo de Empleado---------------->\n[B] ase");
            Console.WriteLine("[J] ornada");
            Console.Write("[S] indicalizado\n\nSeleccione Tipo: ");
            char opcion = Console.ReadLine().ToUpper().ElementAt(0);
            Console.Write("\n<---------------------Salario--------------------->\n");
            switch(opcion)
            {
                case 'B': //Empleado base.
                    {
                        Console.Write("Salario Base: $ ");
                        double salario = Convert.ToDouble(Console.ReadLine());
                        empleado = new EmpleadoBase(datos, salario);
                        break;
                    }
                case 'J': //Empleado jornada.
                    {
                        Console.Write("Dias Laborados: # ");
                        int dias = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salario por Dia: $ ");
                        double salarioXDia = Convert.ToDouble(Console.ReadLine());
                        empleado = new EmpleadoJornada(datos, dias, salarioXDia);
                        break;
                    }
                case 'S': //Empleado sindicalizado.
                    {
                        Console.Write("Salario Base: $ ");
                        double salarioBase = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Horas Extras: # ");
                        int horasExtras = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salario Por Hora Extra: $ ");
                        double salarioXHoraExtra = Convert.ToDouble(Console.ReadLine());
                        empleado = new EmpleadoSindicalizado(datos, salarioBase, horasExtras, salarioXHoraExtra);
                        break;
                    }
                default:
                    Console.WriteLine("Opción No Válida :(\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

            if(empleado != null)
                lista.Add(empleado);
            Console.Clear();
            }

        public void Nomina()
        {
            Console.Clear();
            Console.WriteLine(Nombre + "\n\n");
            Console.WriteLine("{0,-20} {1,10}", "Nombre", "Salario");
            foreach (Empleado empleado in Lista)
            {
                Console.WriteLine("{0,-20} {1,10}", empleado.Datos.Nombre, "$" + empleado.Salario());
                //Console.WriteLine(empleado.GetType().Name);
            }

            Console.WriteLine("\n\nPulse una tecla para continuar...");
            Console.ReadKey();
        }

        public void Eliminar()
        {
            Console.Clear();
            Console.Write("<---------------Dar de Baja Empleado--------------->\nNombre: ");
            string eliminarEmpleado = Convert.ToString(Console.ReadLine());

            Empleado empleado = lista.Find(item => item.Datos.Nombre == eliminarEmpleado);
            if (empleado != null)
                lista.Remove(empleado);
            else
            {
                Console.WriteLine("\nEmpleado No Encontrado :(\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Actualizar()
        {
            Console.WriteLine("Empleado a Actualizar: ");
            string busqueda = Console.ReadLine();
            //busqueda=busqueda.ToUpper();

            try
            {
                Empleado empleado = lista.Find(x => x.Datos.Nombre == busqueda);
                Console.WriteLine("Inserte el nuevo nombre para " + empleado.Datos.Nombre);
                string nuevoNombre = Console.ReadLine();
                Console.WriteLine("Inserte la nueva direccion \n" );
                string nuevaDireccion = Console.ReadLine();
                Console.WriteLine("Inserte el nuevo correo \n");
                string nuevoCorreo = Console.ReadLine();
                Console.WriteLine("Inserte el nuevo telefono \n ");
                string nuevoTelefono = Console.ReadLine();
                
                //actualización de datos
                empleado.Datos.Nombre = nuevoNombre;
                empleado.Datos.Direccion = nuevaDireccion;
                empleado.Datos.Email = nuevoCorreo;
                empleado.Datos.Telefono = nuevoTelefono;

                if (empleado.GetType().Name == "EmpleadoBase")
                {
                    Console.Write("Salario Base: $ ");
                    double salario = Convert.ToDouble(Console.ReadLine());
                    ((EmpleadoBase)empleado).SalarioBase = salario;
                }
                if (empleado.GetType().Name == "EmpleadoJornada")
                {
                    Console.Write("Dias Laborados: # ");
                    int dias = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salario por Dia: $ ");
                    double salarioXDia = Convert.ToDouble(Console.ReadLine());
                    //asignar
                    ((EmpleadoJornada)empleado).NumeroDias = dias;
                    ((EmpleadoJornada)empleado).SalarioXDia = salarioXDia;
                }
                if (empleado.GetType().Name == "EmpleadoSindicalizado")
                {
                    Console.Write("Salario Base: $ ");
                    double salarioBase = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Horas Extras: # ");
                    int horasExtras = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salario Por Hora Extra: $ ");
                    double salarioXHoraExtra = Convert.ToDouble(Console.ReadLine());

                    ((EmpleadoSindicalizado)empleado).SalarioBase = salarioBase;
                    ((EmpleadoSindicalizado)empleado).HorasExtra = horasExtras;
                    ((EmpleadoSindicalizado)empleado).SalarioXHoraExtra = salarioXHoraExtra;
                }


            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

    }
}
