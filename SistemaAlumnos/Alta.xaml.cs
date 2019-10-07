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
using System.Windows.Shapes;

namespace SistemaAlumnos
{
    /// <summary>
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexión c = new Conexión();
            c.llenarComboAlta(cbProgramas);
        }

        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {
            int res;
            Alumno a = new Alumno(Int16.Parse(txClaveUnica.Text), txNombre.Text, txSexo.Text, txCorreo.Text, Int16.Parse(txSemestre.Text), cbProgramas.SelectedIndex);
            res = a.agregar(a);
            if (res > 0)
                MessageBox.Show("alumno dado de alta");
            else
                MessageBox.Show("alumno no pudo darse de alta");
        }

        private void BtEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Baja w = new Baja();
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Buscar w = new Buscar();
            w.Show();
        }

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Modificar w = new Modificar();
            w.Show();
        }

        private void BtSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
