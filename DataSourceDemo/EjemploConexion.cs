using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class EjemploConexion : Form
    {
        // Constructor del formulario
        public EjemploConexion()
        {
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón de guardar en el BindingNavigator
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();  // Valida los controles para asegurarse de que sus datos sean correctos
            this.customersBindingSource.EndEdit();  // Finaliza las ediciones en el BindingSource, aplicando los cambios
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza todos los datos en el DataSet utilizando el TableAdapterManager
        }

        // Evento que se ejecuta cuando se carga el formulario
        private void EjemploConexion_Load(object sender, EventArgs e)
        {
            // esta línea de código carga datos en la tabla 'Customers'.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);  // Carga los datos de la tabla 'Customers' en el DataSet
        }

        // Evento que se ejecuta al hacer clic en el botón (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            customersBindingSource.AddNew();  // Agrega un nuevo registro vacío al BindingSource (preparado para su edición)
        }

        // Evento que maneja la entrada de texto en la caja de texto para buscar por ID de cliente
        private void CajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // Verifica si la tecla presionada es "Enter" (código ASCII 13)
            {
                var index = customersBindingSource.Find("CustomerID", CajaTextoID);  // Busca la posición del registro con el CustomerID especificado
                if (index > -1)  // Si encuentra un resultado
                {
                    customersBindingSource.Position = index;  // Establece la posición actual del BindingSource al índice encontrado
                    return;
                }
                else
                {
                    MessageBox.Show("Elemento no encontrado");  // Muestra un mensaje si el CustomerID no se encuentra
                }
            };
        }
    }
}
