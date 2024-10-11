using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.CodeDom;


namespace Agenda
{
    public partial class Form1 : Form
    {
        private List<Contacto> Contactos = new List<Contacto>();
        private int indice = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter escribir = new StreamWriter("Agenda.txt");
            foreach (Contacto persona in Contactos)
            {
                escribir.WriteLine(persona.Nombre + "|" + persona.Apellido + "|" + persona.Telefono + "|" + persona.Correo);
            }
            escribir.Close();
            MessageBox.Show("Contactos Guardados");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contacto persona = new Contacto
            {
                Nombre = btnNombre.Text,
                Apellido = btnApellido.Text,
                Telefono = btnTelefono.Text,
                Correo = btnEmail.Text

            };
            if (indice > -1)
            {
                Contactos[indice] = persona;
            }
            else
            {
                Contactos.Add(persona);
            }
            
            actualizaVista();
            limpiaCampos(); 
        }
        private void actualizaVista()
        {
            dvgContactos.DataSource = null;
            dvgContactos.DataSource = Contactos;
            dvgContactos.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
               
        }

        private void btnNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void dvgContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgContactos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow renglon = dvgContactos.SelectedRows[0];
            indice = dvgContactos.Rows.IndexOf(renglon);
            Contacto persona = Contactos[indice];
            btnNombre.Text = persona.Nombre;
            btnApellido.Text = persona.Apellido;
            btnTelefono.Text = persona.Telefono;
            btnEmail.Text = persona.Correo;
            
        }
        private void limpiaCampos()
        {
            btnNombre.Text = null;
            btnApellido.Text=null;
            btnTelefono.Text = null;
            btnEmail.Text = null;

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (indice > -1)
            {
                Contactos.RemoveAt(indice);
                actualizaVista();
                limpiaCampos(); 
                indice = -1;
            }
            else
            {
                MessageBox.Show("Seleccione el registro a borrar");
            }
        }

    }
}
