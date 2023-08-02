using EjemploConexioBDMySQL.Entities;
using EjemploConexioBDMySQL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EjemploConexioBDMySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        EmpleadoService services = new EmpleadoService();
        VerificacionEmpleadoService verify = new VerificacionEmpleadoService();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(TxtNombre.Text == "" || TxtApellido.Text == "" || TxtCorreo.Text == "")
            {

                MessageBox.Show("Llena todos los campos");
            }
            else
            {
                Empleado emp = new Empleado()
                {
                    Nombre = TxtNombre.Text,
                    Apellido = TxtApellido.Text,
                    Correo = TxtCorreo.Text,
                };
                var xc = verify.VerifyEmpleado(emp);
                if(xc != "1")
                {
                    
                    services.Add(emp);
                    TxtNombre.Clear();
                    TxtApellido.Clear();
                    TxtCorreo.Clear();
                    TxtFecha.Clear();
                    TxtID.Clear();
                    MessageBox.Show("Datos Agregados");
                }
                else
                {
                    MessageBox.Show("Cuenta No Disponible");
                }
                
            }

        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Llena el campo ID");
            }
            else
            {
                var empleado = services.View(Convert.ToInt32(TxtID.Text));
                if (empleado != null)
                {
                    TxtNombre.Text = empleado.Nombre;
                    TxtApellido.Text = empleado.Apellido;
                    TxtCorreo.Text = empleado.Correo;
                    TxtFecha.Text = Convert.ToString(empleado.FechaRegistro);
                }
                else
                {
                    MessageBox.Show("El campo no existe");
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombre.Text == "" || TxtApellido.Text == "" || TxtCorreo.Text == "")
            {
                MessageBox.Show("Llena todos los campos");
            }
            else
            {
                Empleado emp = new Empleado()
                {
                    PKEmpleado = int.Parse(TxtID.Text),
                    Nombre = TxtNombre.Text,
                    Apellido = TxtApellido.Text,
                    Correo = TxtCorreo.Text,
                };
                var very = verify.VerifyID(emp);
                if(very == "0")
                {
                    MessageBox.Show("El campo no existe");
                }
                else
                {
                    services.Modific(emp);
                    TxtNombre.Clear();
                    TxtApellido.Clear();
                    TxtCorreo.Clear();
                    TxtFecha.Clear();
                    TxtID.Clear();
                    MessageBox.Show("Datos Modificados");
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(TxtID.Text == "")
            {
                MessageBox.Show("Llena el campo ID");
            }
            else
            {
                Empleado obj = new Empleado()
                {
                    PKEmpleado = int.Parse(TxtID.Text)
                };
                var very = verify.VerifyID(obj);
                if (very == "0")
                {
                    MessageBox.Show("El Campo No Existe");
                }
                else
                {
                    if (TxtNombre.Text == "" || TxtApellido.Text == "" || TxtCorreo.Text == "" || TxtFecha.Text == "")
                    {
                        MessageBox.Show("Llena todos los cmapos");
                    }
                    else
                    {
                        Empleado emp = new Empleado()
                        {
                            PKEmpleado = int.Parse(TxtID.Text),
                            Nombre = TxtNombre.Text,
                            Apellido = TxtApellido.Text,
                            Correo = TxtCorreo.Text,
                            FechaRegistro = Convert.ToDateTime(TxtFecha.Text),
                        };
                        //services.Delete(emp);
                        TxtNombre.Clear();
                        TxtApellido.Clear();
                        TxtCorreo.Clear();
                        TxtFecha.Clear();
                        TxtID.Clear();
                        MessageBox.Show("Datos Eliminados");
                    }
                }
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCorreo.Clear();
            TxtFecha.Clear();
            TxtID.Clear();
        }
    }
}
