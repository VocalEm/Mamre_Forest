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
    public partial class Menu : Form
    {
        Random random = new Random();
        int numRandom = 0;
        List<string> libros;
        int posY = 0;
        int posX = 0;
        Perfil_Usuario perfil_Usuario;
        public Menu()
        {
            InitializeComponent();
           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            numRandom = random.Next(1, 66);
            var sql = new EnlaceDB();
            usuario user = sql.MostrarInfoUsuario(6, VariablesGlobales.correoActual, VariablesGlobales.passwordActual);
            libros = sql.Libros(3);
            VariablesGlobales.nombreActual = user.Nombre;
            VariablesGlobales.IdiomaActual = user.IdiomaPref;
            VariablesGlobales.letra = user.TamañoLetra;
            label1.Text = VariablesGlobales.nombreActual;
            label2.Text = VariablesGlobales.correoActual;
            if (VariablesGlobales.IdiomaActual == 2)
            {
                button2.Text = "Consult";
                button1.Text = "Search";
                button3.Text = "Favorites";
                button4.Text = "Record";
            }
            label4.Text = libros[numRandom];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar buscar = new Buscar();
            buscar.Show();
            perfil_Usuario?.Close();
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Nuevo_Login login = new Nuevo_Login();
            login.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            perfil_Usuario = new Perfil_Usuario();
            perfil_Usuario.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Favoritos favoritos = new Favoritos();
            favoritos.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Historial historial = new Historial();
            historial.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
