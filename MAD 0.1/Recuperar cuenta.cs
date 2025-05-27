using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MAD_0._1
{
    public partial class Recuperar_cuenta : Form
    {
        int posX;
        int posY;
        public Recuperar_cuenta()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo_Login nuevoLogin = new Nuevo_Login();
            nuevoLogin.Show();
            this.Close();
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

        private void label4_MouseMove(object sender, MouseEventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            string correo, passwordNueva;
            int codigoNum = 0;
            bool error = false;

            if (textBox1.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
                VariablesGlobales.mensaje("Error", "Se necesitan llenar todos los campos");
            else
            {
                correo = textBox1.Text;
                passwordNueva = textBox4.Text;
                if (int.TryParse(textBox3.Text, out int codigo1))
                    codigoNum = Int32.Parse(textBox3.Text);

                if (passwordNueva.Length < 8 || !passwordNueva.Any(char.IsUpper) || !passwordNueva.Any(char.IsLower) || !passwordNueva.Any(c => !char.IsLetterOrDigit(c)))
                    VariablesGlobales.mensaje("Error", "Contraseña invalida");
                else if (codigoNum < 100 || codigoNum > 999)
                    VariablesGlobales.mensaje("Error", "El codigo debe ser un numero entre el 100 y 999");
                else
                {
                    var sql = new EnlaceDB();
                    error = sql.RecuperacionCuenta(5, correo, passwordNueva, codigoNum);
                    if (!error)
                    {
                        VariablesGlobales.mensaje("Reactivacion", "Cuenta reactivada");
                        Nuevo_Login login = new Nuevo_Login();
                        login.Show();
                        this.Close();
                    }

                    else
                        VariablesGlobales.mensaje("Error", "Error al reactivar cuenta");
                }
            }
            
        }
    }
}
