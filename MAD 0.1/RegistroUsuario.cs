using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MAD_0._1
{

    public partial class RegistroUsuario : Form
    {
        int posX;
        int posY;
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo_Login nuevo_Login = new Nuevo_Login();
            nuevo_Login.Show();
            this.Close();

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

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = "", apPat = "", apMat = "", correo = "", password = "", fechaNacimiento = "", dominio = "";
            int codigo = 0, edadYear = 0;
            bool genero = true;

            if (TB_Nombre.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0 || textBox4.TextLength == 0 || textBox6.Text.Length == 0)
                VariablesGlobales.mensaje("Error", "Se necesitan llenar todos los campos");
            else
            {

                correo = textBox5.Text;
                if (correo.Contains("@"))
                    dominio = correo.Split('@')[1].ToLower();

                if (int.TryParse(textBox6.Text, out int codigo1))
                    codigo = Int32.Parse(textBox6.Text);

                fechaNacimiento = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                if (DateTime.TryParse(fechaNacimiento, out DateTime fecha))
                {
                    if (fecha.Date >= DateTime.Today || fechaNacimiento.Length == 0)
                        VariablesGlobales.mensaje("Error", "Debe seleccionar la fecha correcta");
                    else
                    {
                        TimeSpan diferencia = DateTime.Today - fecha;
                        if (fecha.Month == DateTime.Today.Month && fecha.Day == DateTime.Today.Day)
                            edadYear = (int)(diferencia.TotalDays / 365.25) + 1;
                        else
                            edadYear = (int)(diferencia.TotalDays / 365.25);
                    }
                }//validamos que no pueda nacer hoy

                nombre = TB_Nombre.Text;
                apPat = textBox2.Text;
                apMat = textBox3.Text;

                password = textBox4.Text;

                if (radioButton1.Checked)
                    genero = false;
                else if (radioButton3.Checked)
                    genero = true;

                if (codigo < 100 || codigo > 999)
                    VariablesGlobales.mensaje("Error", "El codigo debe ser un numero entre el 100 y 999");
                else if (!correo.Contains("@"))
                    VariablesGlobales.mensaje("Error", "Correo invalido");
                else if (dominio != "outlook.com" && dominio != "gmail.com")
                    VariablesGlobales.mensaje("Error", "Correo invalido");
                else if (password.Length < 8 || !password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(c => !char.IsLetterOrDigit(c)))
                    VariablesGlobales.mensaje("Error", "Contraseña invalida");
                else if (!radioButton1.Checked && !radioButton3.Checked)
                    VariablesGlobales.mensaje("Error", "Debe seleccionar genero");
                else if (edadYear < 12)
                    VariablesGlobales.mensaje("Error", "Edad invalida");

                else
                {
                    var sql = new EnlaceDB();
                    bool error;
                    error = sql.AddUsuarios(1, nombre, apPat, apMat, fechaNacimiento, genero, correo, password, codigo);
                    if (!error)
                    {
                        VariablesGlobales.mensaje("Mensaje", "Usuario agregado");
                        Nuevo_Login login = new Nuevo_Login();
                        Properties.Settings.Default.Correo = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Recordar = false;
                        login.Show();
                        this.Close();
                    }

                    else
                        VariablesGlobales.mensaje("Error", "Error al agregar usuario");
                }

            }
        }

    }
}
