using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppWCF.ReferenciaNegocio;

namespace AppWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Service2Client servicio = new Service2Client();

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbopais.DataSource = servicio.Paises().Tables[0];
            cbopais.DisplayMember = "nombrepais";
            cbopais.ValueMember = "idpais";
            dgClientes.DataSource = servicio.Clientes().Tables[0];
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente reg = new Cliente();
            //tabla clientes2
            //Guid g = Guid.NewGuid();
            //reg.Idcliente = Guid.NewGuid().ToString();
            reg.Nombrecli = txtnombre.Text;
            reg.Direccion = txtdireccion.Text;
            reg.Idpais = cbopais.SelectedValue.ToString();
            //reg.Idpais = "peru";
            reg.Telefono = txtfono.Text;

            string msg = servicio.Agregar(reg);
            MessageBox.Show(msg);
            dgClientes.DataSource = servicio.Clientes().Tables[0];
        }

        private void dgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dgClientes.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dgClientes.CurrentRow.Cells[1].Value.ToString();
            txtdireccion.Text = dgClientes.CurrentRow.Cells[2].Value.ToString();
            txtfono.Text = dgClientes.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente reg = new Cliente();
            reg.Idcliente = txtcodigo.Text;
            reg.Nombrecli = txtnombre.Text;
            reg.Direccion = txtdireccion.Text;
            reg.Idpais = cbopais.SelectedValue.ToString();
            //reg.Idpais = "peru";
            reg.Telefono = txtfono.Text;

            string msg = servicio.Actualizar(reg);
            MessageBox.Show(msg);
            dgClientes.DataSource = servicio.Clientes().Tables[0];
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Cliente reg = new Cliente();
            reg.Idcliente = txtcodigo.Text;
            string msg = servicio.Eliminar(reg);
            MessageBox.Show(msg);
            dgClientes.DataSource = servicio.Clientes().Tables[0];
        }
    }
}
