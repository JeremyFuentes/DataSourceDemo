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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón de guardar en el BindingNavigator
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();// Valida los controles para asegurarse de que sus datos sean correctos
            this.customersBindingSource.EndEdit();// Finaliza las ediciones en el BindingSource, aplicando los cambios
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los datos en el DataSet utilizando el TableAdapterManager

    }

        // Esto permite que los datos de los clientes se muestren en el formulario automáticamente al iniciar.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}
