using POO_practica03.Clases;
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

namespace POO_practica03.Practicas
{
    /// <summary>
    /// Lógica de interacción para wpf_suma.xaml
    /// </summary>
    public partial class wpf_suma : Window
    {
        public wpf_suma()
        {
            InitializeComponent();
        }

        private void BTNSuma_Click(object sender, RoutedEventArgs e)
        {
            clOperaciones op = new clOperaciones(decimal.Parse(TXTValor1.Text), Convert.ToDecimal(TXTValor2.Text));
            TXTResultado.Text = op.suma().ToString();
        }

        private void BTNResta_Click(object sender, RoutedEventArgs e)
        {
            clOperaciones op = new clOperaciones(decimal.Parse(TXTValor1.Text), Convert.ToDecimal(TXTValor2.Text));
            TXTResultado.Text = op.resta().ToString();
        }

        private void BTNMultiplicacion_Click(object sender, RoutedEventArgs e)
        {
            clOperaciones op = new clOperaciones(decimal.Parse(TXTValor1.Text), Convert.ToDecimal(TXTValor2.Text));
            TXTResultado.Text = op.multiplicacion().ToString();
        }
        private void BTMDDivision_Click(object sender, RoutedEventArgs e)
        {
            clOperaciones op = new clOperaciones(decimal.Parse(TXTValor1.Text), Convert.ToDecimal(TXTValor2.Text));
            TXTResultado.Text = op.division().ToString();
        }

        private void TXTValor1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9) && // Teclas numéricas
                !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) && // Teclado numérico
                e.Key != Key.Decimal && // Punto del teclado numérico
                e.Key != Key.OemPeriod && // Punto del teclado principal
                e.Key != Key.Back && // Tecla de retroceso
                e.Key != Key.Tab) // Tecla de tabulación para moverse entre controles
            {
                // Si la tecla no es permitida, cancelar el evento para que no se registre
                MessageBox.Show("ta mal, pon solo numeros");
                e.Handled = true;
            }
        }

        private void TXTValor2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9) && // Teclas numéricas
                !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) && // Teclado numérico
                  e.Key != Key.Decimal && // Punto del teclado numérico
                  e.Key != Key.OemPeriod && // Punto del teclado principal
                  e.Key != Key.Back && // Tecla de retroceso
                  e.Key != Key.Tab) // Tecla de tabulación para moverse entre controles
            {
                // Si la tecla no es permitida, cancelar el evento para que no se registre
                MessageBox.Show("ta mal, pon solo numeros");
                e.Handled = true;
            }
        }
    }
}
