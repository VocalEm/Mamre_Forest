using Microsoft.VisualBasic;
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
    public partial class Buscar : Form
    {
        bool fullscreen = false;
        int letra = 0;
        List<string> libros;
        List<string> versiones;
        List<string> Testamentos;

        int posY = 0;
        int posX = 0;
        Perfil_Usuario perfil_Usuario;
        public Buscar()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Perfil_Usuario"] == null)
            {
                perfil_Usuario = new Perfil_Usuario();
                perfil_Usuario.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void Buscar_MouseMove(object sender, MouseEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdiomaActual == 2)
            {
                label4.Text = "Words to Search";
                label7.Text = "Testament";
                label8.Text = "Book";
                label6.Text = "Font size";
                label2.Text = "Search";
                button3.Text = "Search";
                button1.Text = "Return";
            }
            label3.Text = VariablesGlobales.nombreActual;
            label1.Text = VariablesGlobales.correoActual;
            var sql = new EnlaceDB();
            versiones = sql.Versiones(4);
            libros = sql.Libros(3);
            Testamentos = sql.Testamentos(6);
            int contador = 0;
            if (VariablesGlobales.IdiomaActual == 1)
            {
                foreach (var version in versiones)
                {
                    if (contador < 3)
                    {
                        comboBox2.Items.Add(version);
                        contador++;
                    }
                }
                comboBox2.SelectedIndex = 0;
                contador = 0;

                foreach (var nombre in Testamentos)
                {
                    if (contador < 2)
                    {
                        comboBox3.Items.Add(nombre);
                        contador++;
                    }
                }
                comboBox3.SelectedIndex = 0;
                contador = 0;

                libros = sql.Libros(3);
                comboBox4.Items.Clear();
                foreach (string nombre in libros)
                {
                    if (contador < 40)
                    {
                        comboBox4.Items.Add(nombre);
                        contador++;
                    }
                }
                contador = 0;
                comboBox4.SelectedIndex = 0;

                comboBox3.Items.Add("TODA LA BIBLIA");
                comboBox4.Items.Add("SOLO TESTAMENTO");
            } // español
            if (VariablesGlobales.IdiomaActual == 2)
            {
                foreach (var version in versiones)
                {
                    if (contador >= 3)
                    {
                        comboBox2.Items.Add(version);
                    }
                    contador++;
                }
                comboBox2.SelectedIndex = 0;
                contador = 0;

                foreach (var nombre in Testamentos)
                {
                    if (contador >= 2)
                    {
                        comboBox3.Items.Add(nombre);
                    }
                    contador++;
                }
                comboBox3.SelectedIndex = 0;
                contador = 0;

                libros = sql.Libros(3);
                comboBox4.Items.Clear();
                foreach (string nombre in libros)
                {
                    if (contador >= 66 && contador < 105)
                    {
                        comboBox4.Items.Add(nombre);
                    }
                    contador++;

                }
                contador = 0;
                comboBox4.SelectedIndex = 0;

                comboBox3.Items.Add("ALL BIBLE");
                comboBox4.Items.Add("ONLY TESTAMENT");
            } // español

            if (VariablesGlobales.IdiomaActual == 1)
            {
                if (comboBox3.Text == "TODA LA BIBLIA")
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("TODA LA BIBLIA");
                    comboBox4.SelectedIndex = 0;
                }

                else if (comboBox3.Text == "ANTIGUO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
                    libros = sql.Libros(3);
                    foreach (string nombre in libros)
                    {
                        if (contador < 39)
                        {
                            comboBox4.Items.Add(nombre);
                        }
                        contador++;
                    }
                    comboBox4.Items.Add("SOLO TESTAMENTO");
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox3.Text == "NUEVO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
                    libros = sql.Libros(3);
                    foreach (string nombre in libros)
                    {
                        if (contador < 66 && contador >= 39)
                        {
                            comboBox4.Items.Add(nombre);
                        }
                        contador++;
                    }
                    comboBox4.Items.Add("SOLO TESTAMENTO");
                    comboBox4.SelectedIndex = 0;
                }
            }
            else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox3.Text == "ALL BIBLE")
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("ALL BIBLE");
                    comboBox4.SelectedIndex = 0;
                }

                else
                {
                    if (comboBox3.Text == "OLD TESTAMENT")
                    {
                        comboBox4.Items.Clear();
                        libros = sql.Libros(3);
                        foreach (string nombre in libros)
                        {
                            if (contador >= 66 && contador < 105)
                            {
                                comboBox4.Items.Add(nombre);
                            }
                            contador++;
                        }
                        comboBox4.Items.Add("ONLY TESTAMENT");
                        comboBox4.SelectedIndex = 0;
                    }
                    else if (comboBox3.Text == "NEW TESTAMENT")
                    {
                        comboBox4.Items.Clear();
                        libros = sql.Libros(3);
                        foreach (string nombre in libros)
                        {
                            if (contador >= 105)
                            {
                                comboBox4.Items.Add(nombre);
                            }
                            contador++;
                        }
                        comboBox4.Items.Add("ONLY TESTAMENT");
                        comboBox4.SelectedIndex = 0;
                    }

                }
            }

            textBox2.Text = VariablesGlobales.letra.ToString();
            dataGridView2.DefaultCellStyle.Font = new Font("Yu Gothic UI", VariablesGlobales.letra, FontStyle.Bold);

        }

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool error;
            string version = "", testamento = "", libro = "", palabras = "";
            int versionNum = 0, testamentoNum = 0, libroNum = 0;
            version = comboBox2.Text;
            testamento = comboBox3.Text;
            libro = comboBox4.Text;
            if (textBox1.Text.Length == 0)
                VariablesGlobales.mensaje("ERROR", "Necesita ingresar palabras para buscar");
            else
            {
                palabras = textBox1.Text;
                var sql = new EnlaceDB();
                dataGridView2.DataSource = sql.buscar(2, version, testamento, libro, palabras);

                if (VariablesGlobales.IdiomaActual == 1)
                {
                    versionNum = versiones.IndexOf(version) + 1;
                    if (testamento == "TODA LA BIBLIA")
                        testamentoNum = 0;
                    else
                        testamentoNum = Testamentos.IndexOf(testamento) + 1;

                    if (libro == "TODA LA BIBLIA" || libro == "SOLO TESTAMENTO")
                        libroNum = 0;
                    else
                    {
                        if (testamento == "ANTIGUO TESTAMENTO")
                            libroNum = libros.IndexOf(libro) + 1;
                        else if (testamento == "NUEVO TESTAMENTO")
                            libroNum = libros.IndexOf(libro) + 1;

                    }
                }
                if (VariablesGlobales.IdiomaActual == 2)
                {
                    versionNum = versiones.IndexOf(version) + 1;
                    if (testamento == "ALL BIBLE")
                        testamentoNum = 0;
                    else
                        testamentoNum = Testamentos.IndexOf(testamento) + 1;

                    if (libro == "ALL BIBLE" || libro == "ONLY TESTAMENT")
                        libroNum = 0;
                    else
                        libroNum = libros.IndexOf(libro) + 1;
                }


                error = sql.agregarHistorial(10, palabras, versionNum, testamentoNum, libroNum);
                if (error)
                    VariablesGlobales.mensaje("ERROR", "ERROR");
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdiomaActual == 1)
            {
                if (comboBox3.Text == "TODA LA BIBLIA")
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("TODA LA BIBLIA");
                    comboBox4.SelectedIndex = 0;
                }

                else if (comboBox3.Text == "ANTIGUO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
                    var sql = new EnlaceDB();
                    int contador = 0;
                    libros = sql.Libros(3);
                    foreach (string nombre in libros)
                    {
                        if (contador < 39)
                        {
                            comboBox4.Items.Add(nombre);
                        }
                        contador++;
                    }
                    comboBox4.Items.Add("SOLO TESTAMENTO");
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox3.Text == "NUEVO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
                    var sql = new EnlaceDB();
                    int contador = 0;
                    libros = sql.Libros(3);
                    foreach (string nombre in libros)
                    {
                        if (contador < 66 && contador >= 39)
                        {
                            comboBox4.Items.Add(nombre);
                        }
                        contador++;
                    }
                    comboBox4.Items.Add("SOLO TESTAMENTO");
                    comboBox4.SelectedIndex = 0;
                }
            }
            else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox3.Text == "ALL BIBLE")
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("ALL BIBLE");
                    comboBox4.SelectedIndex = 0;
                }

                else
                {
                    if(comboBox3.Text == "OLD TESTAMENT")
                    {
                        comboBox4.Items.Clear();
                        var sql = new EnlaceDB();
                        int contador = 0;
                        libros = sql.Libros(3);
                        foreach (string nombre in libros)
                        {
                            if (contador >= 66 && contador < 105)
                            {
                                comboBox4.Items.Add(nombre);
                            }
                            contador++;
                        }
                        comboBox4.Items.Add("ONLY TESTAMENT");
                        comboBox4.SelectedIndex = 0;
                    }
                    else if (comboBox3.Text == "NEW TESTAMENT")
                    {
                        comboBox4.Items.Clear();
                        var sql = new EnlaceDB();
                        int contador = 0;
                        libros = sql.Libros(3);
                        foreach (string nombre in libros)
                        {
                            if (contador >= 105)
                            {
                                comboBox4.Items.Add(nombre);
                            }
                            contador++;
                        }
                        comboBox4.Items.Add("ONLY TESTAMENT");
                        comboBox4.SelectedIndex = 0;
                    }

                }
            }

        }
        private void button7_Click_1(object sender, EventArgs e)
        {

            letra = Int32.Parse(textBox2.Text);
            if (letra > 5)
            {
                letra--;
                textBox2.Text = letra.ToString();
            }
            dataGridView2.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            letra = Int32.Parse(textBox2.Text);
            if (letra < 30)
            {
                letra++;
                textBox2.Text = letra.ToString();
            }
            dataGridView2.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                fullscreen = true;
            }

            else
            {
                this.WindowState = FormWindowState.Normal;
                fullscreen = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
