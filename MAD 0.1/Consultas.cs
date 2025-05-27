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
    public partial class Consultas : Form
    {
        int letraV = 15;
        bool fullscreen = false;
        List<string> libros;
        List<string> versiones;
        List<int> Capitulos;
        List<string> Testamentos;

        int libroElegido = 0;
        bool consultado = false;
        int posY = 0;
        int posX = 0;
        int contador = 0;
        Perfil_Usuario perfil_Usuario;
        public Consultas()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultado = false;
            Menu menu = new Menu();
            menu.Show();
            perfil_Usuario?.Close();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Perfil_Usuario"] == null)
            {
                perfil_Usuario = new Perfil_Usuario();
                perfil_Usuario.Show();
            }

            // this.Close();
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

        private void label2_MouseMove(object sender, MouseEventArgs e)
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

        private void Consultas_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdiomaActual == 2)
            {
                label7.Text = "Book";
                label2.Text = "Conults";
                label8.Text = "Chapter";
                label4.Text = "Name";
                label6.Text = "Font Size";
                button1.Text = "Return";
                button3.Text = "Consult Verses";
                button2.Text = "Add chapter to favorites";
                button4.Text = "Add Verse to favorites";
            }
            var sql = new EnlaceDB();
            label3.Text = VariablesGlobales.nombreActual;
            label1.Text = VariablesGlobales.correoActual;


            if (VariablesGlobales.IdiomaActual == 1)
            {
                versiones = sql.Versiones(4);
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

                Testamentos = sql.Testamentos(6);
                foreach (var nombre in Testamentos)
                {
                    if (contador < 2)
                    {
                        comboBox1.Items.Add(nombre);
                        contador++;
                    }
                }
                comboBox1.SelectedIndex = 0;
                contador = 0;

                libros = sql.Libros(3);
                foreach (string nombre in libros)
                {
                    if (contador < 66)
                    {
                        comboBox4.Items.Add(nombre);
                        contador++;
                    }
                }
                contador = 0;
                comboBox4.SelectedIndex = 0;
            }
            else if (VariablesGlobales.IdiomaActual == 2)
            {
                versiones = sql.Versiones(4);
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

                Testamentos = sql.Testamentos(6);
                foreach (var nombre in Testamentos)
                {
                    if (contador >= 2)
                    {
                        comboBox1.Items.Add(nombre); 
                    }
                    contador++;
                }
                comboBox1.SelectedIndex = 0;
                contador = 0;


                libros = sql.Libros(3);
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
            }

            if (VariablesGlobales.IdiomaActual == 1)
            {
                if (comboBox1.Text == "ANTIGUO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
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
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox1.Text == "NUEVO TESTAMENTO")
                {
                    comboBox4.Items.Clear();
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
                    comboBox4.SelectedIndex = 0;
                }
            }
            else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox1.Text == "OLD TESTAMENT")
                {
                    comboBox4.Items.Clear();
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
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox1.Text == "NEW TESTAMENT")
                {
                    comboBox4.Items.Clear();
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
                    comboBox4.SelectedIndex = 0;
                }
            }


            int numCapitulos = 50;
            for (int i = 1; i <= numCapitulos; i++)
                comboBox5.Items.Add(i.ToString());
            comboBox5.SelectedIndex = 0;
            dataGridView1.DefaultCellStyle.Font = new Font("Yu Gothic UI", VariablesGlobales.letra, FontStyle.Bold);
            textBox2.Text = VariablesGlobales.letra.ToString();
            dataGridView1.ClearSelection();

        }

        private void Consultas_MouseMove(object sender, MouseEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            consultado = true;
            string libro = "", capitulo = "", version = "";

            libro = comboBox4.SelectedItem.ToString();
            capitulo = comboBox5.SelectedItem.ToString();
            version = comboBox2.SelectedItem.ToString();

            var sql = new EnlaceDB();
            var table = sql.Consultar(1, libro, Int32.Parse(capitulo), 0, version);
            dataGridView1.DataSource = table;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql = new EnlaceDB();

            Capitulos = sql.Capitulos(5);
            libroElegido = comboBox4.SelectedIndex;

            comboBox5.Items.Clear();
            int numCapitulos = Capitulos[libroElegido];
            for (int i = 1; i <= numCapitulos; i++)
                comboBox5.Items.Add(i.ToString());
            comboBox5.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e) //capitulo
        {

            string nombre = "", capitulo = "";
            bool error;
            int version = 0, libro = 0;

            if (VariablesGlobales.IdiomaActual == 1)
            {
                if(comboBox1.Text == "ANTIGUO TESTAMENTO")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex + 1;
                }

                if (comboBox1.Text == "NUEVO TESTAMENTO")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex + 40;
                }

            }

            else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox1.Text == "OLD TESTAMENT")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex + 67;
                }

                if (comboBox1.Text == "NEW TESTAMENT")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex +107;
                }

                version = comboBox2.SelectedIndex + 4;            }
            if (!consultado)
                VariablesGlobales.mensaje("ERROR", "Necesita consultar un capitulo");
            else if (textBox1.Text.Length == 0)
                VariablesGlobales.mensaje("ERROR", "Necesita ponerle un nombre");
            else
            {
                capitulo = comboBox5.SelectedItem.ToString();
                nombre = textBox1.Text;

                var sql = new EnlaceDB();
                error = sql.AgregarFavorito(7, version, libro, Int32.Parse(capitulo), -1, nombre);
                if (!error)
                {
                    VariablesGlobales.mensaje("EXITO", "Favorito agregado");
                    textBox1.Text = "";
                }
                else
                    VariablesGlobales.mensaje("ERROR", "Nombre o consulta repetida");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nombre = "", capitulo = "", versiculo = "";
            bool error;
            int version = 0, libro = 0, indice = 0;

            if (VariablesGlobales.IdiomaActual == 1)
            {
                if (comboBox1.Text == "ANTIGUO TESTAMENTO")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex + 1;
                }

                if (comboBox1.Text == "NUEVO TESTAMENTO")
                {
                    version = comboBox2.SelectedIndex + 1;
                    libro = comboBox4.SelectedIndex + 40;
                }

            }
            else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox1.Text == "OLD TESTAMENT")
                {
                    libro = comboBox4.SelectedIndex + 67;
                }

                if (comboBox1.Text == "NEW TESTAMENT")
                {
                    libro = comboBox4.SelectedIndex + 107;
                }

                version = comboBox2.SelectedIndex + 4;
            }

                if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtiene la primera fila seleccionada
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Obtiene el índice de la fila
                indice = row.Index + 1;
                versiculo = indice.ToString();
                if (textBox1.Text.Length == 0)
                    VariablesGlobales.mensaje("ERROR", "Necesita ponerle un nombre");
                else
                {
                    capitulo = comboBox5.SelectedItem.ToString();
                    nombre = textBox1.Text;

                    var sql = new EnlaceDB();
                    error = sql.AgregarFavorito(7, version, libro, Int32.Parse(capitulo), Int32.Parse(versiculo), nombre);
                    if (!error)
                    {
                        textBox1.Text = "";
                        VariablesGlobales.mensaje("Exito", "Favorito agregado");

                    }
                    else
                        VariablesGlobales.mensaje("Error", "Posible repeticion u error");

                }
            }
            else
                VariablesGlobales.mensaje("ERROR", "Necesita elegir un versiculo");


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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            letraV = Int32.Parse(textBox2.Text);
            if (letraV < 30)
            {
                letraV++;
                textBox2.Text = letraV.ToString();
            }
            dataGridView1.DefaultCellStyle.Font = new Font("Yu Gothic UI", letraV, FontStyle.Bold);

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            letraV = Int32.Parse(textBox2.Text);
            if (letraV > 5)
            {
                letraV--;
                textBox2.Text = letraV.ToString();
            }
            dataGridView1.DefaultCellStyle.Font = new Font("Yu Gothic UI", letraV, FontStyle.Bold);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(VariablesGlobales.IdiomaActual == 1)
            {
                if (comboBox1.Text == "ANTIGUO TESTAMENTO")
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
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox1.Text == "NUEVO TESTAMENTO")
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
                    comboBox4.SelectedIndex = 0;
                }
            }
           else if (VariablesGlobales.IdiomaActual == 2)
            {
                if (comboBox1.Text == "OLD TESTAMENT")
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
                    comboBox4.SelectedIndex = 0;
                }
                else if (comboBox1.Text == "NEW TESTAMENT")
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
                    comboBox4.SelectedIndex = 0;
                }
            }
        }
    }
}
