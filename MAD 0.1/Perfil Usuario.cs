using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD_0._1
{
    public partial class Perfil_Usuario : Form
    {
        int posY = 0;
        int posX = 0;

        Editar_Perfil editar;
        public Perfil_Usuario()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(VariablesGlobales.IdiomaActual == 2)
                VariablesGlobales.mensajePregunta("Are you sure you want to deactivate this account?");
            else
                VariablesGlobales.mensajePregunta("Estas seguro que quieres desactivar la cuenta?");
            if (VariablesGlobales.RespuestaMensaje)
            {
                bool error = false;
                var sql = new EnlaceDB();
                error = sql.BajaLogica(2, VariablesGlobales.correoActual);
                if (!error)
                {
                    Properties.Settings.Default.Recordar = false;
                    Properties.Settings.Default.Correo = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                    Nuevo_Login login = new Nuevo_Login();
                    login.Show();
                    this.Close();

                }
                else
                {
                    VariablesGlobales.mensaje("Error", "Error al desactivar cuenta");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editar = new Editar_Perfil();
            editar.Show();
            this.Close();

        }

        private void Perfil_Usuario_Load(object sender, EventArgs e)
        {

            if(VariablesGlobales.IdiomaActual == 2)
            {
      
                button3.Text = "Edit Account";
                button2.Text = "Disable Account";
                button1.Text = "Return";
            }
            comboBox1.Items.Add("Español");
            comboBox1.Items.Add("Ingles");


            var sql = new EnlaceDB();
            usuario user = sql.MostrarInfoUsuario(6, VariablesGlobales.correoActual, VariablesGlobales.passwordActual);
            textBox5.Text = user.Nombre + " " + user.ApPat + " " + user.ApMat;
            textBox1.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
            if (user.genero == true)
                textBox2.Text = "Femenino";
            else
                textBox2.Text = "Masculino";
            textBox3.Text = VariablesGlobales.correoActual;
            textBox4.Text = user.FechaRegistro.ToString();

            if (user.IdiomaPref == 1)
                comboBox1.SelectedIndex = 0;
            else if(user.IdiomaPref == 2)
                comboBox1.SelectedIndex = 1;

            comboBox2.Items.Add(user.TamañoLetra.ToString());
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
