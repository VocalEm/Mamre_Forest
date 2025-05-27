using Microsoft.VisualBasic.Logging;

namespace MAD_0._1
{
    public partial class Nuevo_Login : Form
    {
        string correoBaja;
        int errores = 0;
        public string emailActual;
        public string passwordActual;

        public Nuevo_Login()
        {
            InitializeComponent();
        }
        int posY = 0;
        int posX = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Properties.Settings.Default.Correo = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Recordar = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string correo = "", password = "";

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                VariablesGlobales.mensaje("Error", "Se necesita llenar todos los campos");
            else
            {
                correo = textBox1.Text;
                password = textBox2.Text;
                bool error2;
                var sql = new EnlaceDB();
                bool error;
                error = sql.IniciarSesion(3, correo, password);
                if (!error)
                {
                    if (checkBox1.Checked)
                    {
                        Properties.Settings.Default.Correo = correo;
                        Properties.Settings.Default.Password = password;
                        Properties.Settings.Default.Recordar = checkBox1.Checked;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();
                    }
                    else
                        Properties.Settings.Default.Recordar = checkBox1.Checked;
                    VariablesGlobales.correoActual = correo;
                    VariablesGlobales.passwordActual = password;
                    VariablesGlobales.mensaje("Exito", "Inicio de sesion exitoso");
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else if (errores == 3 && correoBaja == correo)
                {

                    error2 = sql.BajaLogica(2, correoBaja);
                    if (!error2)
                    {
                        VariablesGlobales.mensaje("ERROR", "Excedio los intentos, cuenta desactivada");
                        Properties.Settings.Default.Correo = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Recordar = false;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        VariablesGlobales.mensaje("ERROR", "Correo o contraseña equivocada");
                    }

                }
                else
                {
                    VariablesGlobales.mensaje("ERROR", "Correo o contraseña equivocada");
                    errores++;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperar_cuenta recuperar_Cuenta = new Recuperar_cuenta();
            recuperar_Cuenta.Show();
            this.Hide();
        }

        private void panel2_MouseMove_1(object sender, MouseEventArgs e)
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

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
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

        private void Nuevo_Login_MouseMove(object sender, MouseEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Nuevo_Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Recordar == true)
            {
                textBox1.Text = Properties.Settings.Default.Correo;
                textBox2.Text = Properties.Settings.Default.Password;
                checkBox1.Checked = Properties.Settings.Default.Recordar;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            correoBaja = textBox1.Text.ToString();
            errores = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Properties.Settings.Default.Correo = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Recordar = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            Application.Exit();
        }
    }
}
