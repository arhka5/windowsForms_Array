using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace G16_interfazArray
{
    public partial class G16_interfazArray : Form
    {
        public G16_interfazArray()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Inicia el Form 
        {
            G16_button.Enabled = false; // El boton estara desactivado hasta que se cumplan las condiciones
        }

        private void G16_button_Click(object sender, EventArgs e) // Método que actua al hacer click
        {

            // Obtener el texto del G16_textBox y dividirlo en números
            string numerosStr = G16_textBox.Text;
            // Convertir los números de string a int
            int[] numeros = numerosStr.Select(c => int.Parse(c.ToString())).ToArray();
            // Desordenar el array
            DesordenarArray(numeros);
            // Mostrar el array desordenado en G16_label5
            G16_label5.Text = string.Join(" ", numeros);

            // Ordenar el array
            // Array.Sort(numeros);
            // Llamar al método de ordenación Quicksort
            G16_Ordenar(numeros, 0, numeros.Length - 1);
            // Mostrar el array ordenado en G16_label5
            G16_label6.Text = string.Join(" ", numeros);
        }

        private void G16_Ordenar(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Encuentra la posición del pivote, el elemento en su posición final en la ordenación
                int pi = G16_Particion(array, low, high);

                // Ordena recursivamente los elementos antes y después del pivote
                G16_Ordenar(array, low, pi - 1);
                G16_Ordenar(array, pi + 1, high);
            }
        }

        private int G16_Particion(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;

                    // Intercambia array[i] y array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            // Intercambia array[i+1] y array[high] (o el pivote)
            int tempPivot = array[i + 1];
            array[i + 1] = array[high];
            array[high] = tempPivot;
            return i + 1;
        }

        private void DesordenarArray<T>(T[] array)
        {
            Random rand = new Random();
            int n = array.Length;

            // Desordenar el array usando el algoritmo de Fisher-Yates
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private void G16_textBox_TextChanged(object sender, EventArgs e)
        {
            controlBoton(); // Al cambio en el texto se ejecuta el control

        }

        private void controlBoton()
        {
            // Se verifica el texto en el G16_textBox
            if (G16_textBox.Text.Trim() != string.Empty && G16_textBox.Text.All(char.IsNumber ) && G16_textBox.Text.Trim().Length < 10)
            {
                G16_button.Enabled = true; // Si el G16_textBox cumple el boton se activa
                errorProvider1.SetError(G16_textBox, ""); 

            }
            else 
            { 
            if ((G16_textBox.Text.All(char.IsLetter)))
                {
                errorProvider1.SetError(G16_textBox, "El array sólo debe contener numeros");
                }
            else {
                errorProvider1.SetError(G16_textBox, "Debe introducir un array de máximo 9 cifras");
                }
            G16_button.Enabled = false; // Si el G16_textBox no cumple el boton se desactiva
                G16_button.Focus();
        }   }
    }
}
