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

namespace MAD_0._1
{
    public partial class Editar_Perfil : Form
    {
        int posY = 0;
        int posX = 0;
        bool genero;
        Perfil_Usuario perfil;
        public Editar_Perfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            perfil = new Perfil_Usuario();
            perfil.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string nombre = "", apPat = "", apMat = "", correo = "", password = "", dominio = "";
            int codigo = 0;
            int idioma = 0, letra = 0;

            if (TB_Nombre.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0 || (textBox4.TextLength == 0 && radioButton1.Checked) || textBox6.Text.Length == 0)
                VariablesGlobales.mensaje("Error", "Se necesitan llenar todos los campos");
            else
            {
                nombre = TB_Nombre.Text;
                apPat = textBox2.Text;
                apMat = textBox3.Text;
                if (radioButton2.Checked)
                    password = "NO";
                else
                    password = textBox4.Text;

                correo = textBox5.Text;
                if (correo.Contains("@"))
                    dominio = correo.Split('@')[1].ToLower();

                if (int.TryParse(textBox6.Text, out int codigo1))
                    codigo = Int32.Parse(textBox6.Text);

                if (comboBox1.SelectedIndex == 0)
                    idioma = 1;
                else if (comboBox1.SelectedIndex == 1)
                    idioma = 2;

                letra = Int32.Parse(textBox1.Text);

                if (codigo < 100 || codigo > 999)
                    VariablesGlobales.mensaje("Error", "Deben ser numeros de 3 digitos");
                else if (!correo.Contains("@"))
                    VariablesGlobales.mensaje("Error", "Correo invalido");
                else if (dominio != "outlook.com" && dominio != "gmail.com")
                    VariablesGlobales.mensaje("Error", "Correo invalido");
                else if ((password.Length < 8 || !password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(c => !char.IsLetterOrDigit(c))) && radioButton1.Checked)
                    VariablesGlobales.mensaje("Error", "Contraseña invalida");
               

                else
                {
                    if (textBox7.Text == "Masculino")
                        genero = false;
                    else if (textBox7.Text == "Femenino")
                        genero = true;
                    var sql = new EnlaceDB();
                    bool error;
                    error = sql.ActualizarUsuario(4, nombre, apPat, apMat, correo, codigo, idioma, letra, password, genero);
                    if (!error)
                    {
                        VariablesGlobales.mensaje("Mensaje", "Informacion Actualizada");
                        if (radioButton1.Checked)
                        {
                            Properties.Settings.Default.Correo = "";
                            Properties.Settings.Default.Password = "";
                            Properties.Settings.Default.Recordar = false;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            Nuevo_Login login = new Nuevo_Login();
                            login.Show();
                            this.Close();
                        }
                        else
                        {
                            Properties.Settings.Default.Correo = correo;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            VariablesGlobales.correoActual = correo;
                            VariablesGlobales.IdiomaActual = idioma;
                            VariablesGlobales.nombreActual = nombre;
                            Perfil_Usuario perfil = new Perfil_Usuario();
                            perfil.Show();
                            this.Close();

                        }
                    }

                    else
                        VariablesGlobales.mensaje("Error", "Error al actualizar, verifique que la contraseña sea unica");
                }

            }
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

        private void Editar_Perfil_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Español");
            comboBox1.Items.Add("Ingles");

            var sql = new EnlaceDB();
            usuario user = sql.MostrarInfoUsuario(6, VariablesGlobales.correoActual, VariablesGlobales.passwordActual);

            TB_Nombre.Text = user.Nombre;
            textBox2.Text = user.ApPat;
            textBox3.Text = user.ApMat;
            textBox5.Text = VariablesGlobales.correoActual;

            if (user.IdiomaPref == 1)
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 1;

            textBox1.Text = user.TamañoLetra.ToString();
            if (user.genero == false)
                textBox7.Text = "Masculino";
            if (user.genero == true)
                textBox7.Text = "Femenino";
            radioButton2.Checked = true;
            textBox4.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int letra = 0;
            letra = Int32.Parse(textBox1.Text);
            if (letra < 30)
            {
                letra++;
                textBox1.Text = letra.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int letra = 0;
            letra = Int32.Parse(textBox1.Text);
            if (letra > 5)
            {
                letra--;
                textBox1.Text = letra.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "Masculino")
                textBox7.Text = "Femenino";
            else if (textBox7.Text == "Femenino")
                textBox7.Text = "Masculino";
        }
    }
}
