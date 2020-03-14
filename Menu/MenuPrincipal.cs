using System;
using gasolineraKalum.Controllers;
using gasolineraKalum.Entities;
using static System.Console;
using static gasolineraKalum.Util.Printer;
namespace gasolineraKalum.Menu
{
    public class MenuPrincipal
    {
        private GasolineraController controller = new GasolineraController();
        public  void MostrarMenu()
        {
            try
            {
                int opcion = 0;
                do
                {
                    Clear();
                    WriteTitle("Administracion de Bombas");
                    WriteLine("1. Agregar");
                    WriteLine("2. Eliminar");
                    WriteLine("3. Buscar");
                    WriteLine("4. Listar");
                    WriteLine("5. Modificar");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese una opción");
                    string respuesta = ReadLine();
                    opcion = Convert.ToByte(respuesta);
                    switch (opcion)
                    {
                        case 0:
                            break;
                        case 1:
                            agregarTipoBomba();
                            break;
                        case 2:
                            eliminarBomba();                        
                            break;
                        case 3:      
                            buscarBomba();                      
                            break;
                        case 4:                    
                            listarBombas();
                            break;
                        case 5:
                            modificarBomba();
                            break;
                        default:
                            WriteLine("No existe la Opción");
                            break;
                    }
                } while (opcion != 0);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        private void agregarTipoBomba()
        {
            Clear();
            WriteTitle("Administracion de Bombas");
            WriteTitle("Tipo de Bomba");
            WriteLine("1. Super");
            WriteLine("2. Regular");
            WriteLine("3. Diesel");
            WriteLine("0. Salir");
            WriteLine("Seleccione una Opcion==>");
            string respuesta = ReadLine();
            if (respuesta.Equals("1"))
            {
                Bomba super = new Super();
                agregarElemento(super);
            }else if (respuesta.Equals("2"))
            {
                Bomba regular = new Regular();
                agregarElemento(regular);
            }else if (respuesta.Equals("3"))
            {
                Bomba diesel = new Diesel();
                agregarElemento(diesel);
            }
        }
        private void agregarElemento(Bomba elemento)
        {
            Clear();
            WriteTitle("Administracion de Bombas");
            WriteLine("Ingrese el precio");
            elemento.Precio = Convert.ToDouble(ReadLine());
            WriteLine("Ingrese la Medida");
            elemento.Medida = ReadLine();
            WriteLine("Ingrese la Capacidad");
            elemento.Capacidad = Convert.ToInt16(ReadLine());
            if (elemento.GetType() == typeof(Super))
            {
                WriteLine("Ingrese numero de Aditivo");
                ((Super)elemento).Aditivo = Convert.ToInt16(ReadLine());
            }else if (elemento.GetType() == typeof(Diesel))
            {
                WriteLine("Ingrese Formula");
                ((Diesel)elemento).Formula = ReadLine();
            }
            controller.Agregar(elemento);
        }
        private void listarBombas()
        {            
            Clear();
            controller.listar();
            PrecionarEnter();
        }
        private void eliminarBomba()
        {
            Clear();
            controller.listar();
            WriteLine("Ingrese el ID a eliminar");
            string id = ReadLine();         
            object elemento = buscarBomba(id);
            if (elemento != null)
            {
                WriteLine("Esta seguro de eliminar (S/N)");
                string respuesta = ReadLine();
                if (respuesta.Equals("S"))
                {
                    controller.Eliminar(elemento);
                }
            }
            else
            {
                WriteLine("No existe ningun elemento");
            }   
            PrecionarEnter();
        }
        private object buscarBomba(string id)
        {   
            return controller.Buscar(id);
        }
        private void buscarBomba()
        {
            WriteLine("Ingrese el Id a Buscar");
            string id = ReadLine();
            object elemento = buscarBomba(id);
            if (elemento != null)
            {
                WriteLine(elemento.ToString());
            }
            else
            {
                WriteLine("No existe ningun elemento");
            }
            PrecionarEnter();
        }
        private void modificarBomba()
        {
            Clear();
            WriteTitle("Administracion de Bombas");            
            WriteLine("Ingrese el Id");
            string id = ReadLine();
            object elemento = buscarBomba(id);
            if (elemento != null)
            {
                ((Bomba)elemento).Capacidad = 2020;                
            }
            else
            {
                WriteLine("No existe ningun elemento");
            }
            PrecionarEnter();
        }
    }
}