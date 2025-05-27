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
    public partial class Favoritos : Form
    {
        bool carga = false;
        bool fullscreen = false;
        int letra = 0;
        List<string> libros;
        List<string> versiones;
        int posY = 0;
        int posX = 0;
        string nombreFavorito = "";

        Perfil_Usuario perfil_Usuario;
        public Favoritos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Favoritos_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdiomaActual == 2)
            {
                label2.Text = "Favorites";
                label6.Text = "Font Size";
                button3.Text = "Delete Favorite";
                button1.Text = "Return";
            }
            label3.Text = VariablesGlobales.nombreActual;
            label1.Text = VariablesGlobales.correoActual;
            var sql = new EnlaceDB();
            var tabla = sql.Favorito(8);
            libros = sql.Libros(3);
            versiones = sql.Versiones(4);
            dataGridView3.DataSource = tabla;
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                //separacion de informacion
                string informacion = row.Cells["Informacion"].Value.ToString();
                string[] partes = informacion.Split(' ');
                string version = partes[0];
                string libro = partes[1];
                string capituloVersiculo = partes[2]; // "13:"
                string mes = partes[3];
                string dia = partes[4];
                string year = partes[5];
                string hora = partes[6];

                version = versiones[Int32.Parse(version) - 1];
                libro = libros[Int32.Parse(libro) - 1];
                string informacionFinal = version + " " + libro + " " + capituloVersiculo + " " + mes + " " + dia + " " + year + " " + hora;
                row.Cells["Informacion"].Value = informacionFinal;
            }
            dataGridView3.ClearSelection();
            textBox2.Text = VariablesGlobales.letra.ToString();
            carga = true;
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

        private void Favoritos_MouseMove(object sender, MouseEventArgs e)
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
        private void dataGridView3_SelectionChanged_1(object sender, EventArgs e)
        {
            string capitulo = "", versiculo = "", libro = "";
            if(carga)
            {
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView3.SelectedRows[0];
                    nombreFavorito = row.Cells["Nombre"].Value.ToString();
                    string informacion = row.Cells["Informacion"].Value.ToString();
                    /*
                    string libro = row.Cells["Libros"].Value.ToString();
                    string capitulo = row.Cells["Capitulo"].Value.ToString();
                    string Versiculo = row.Cells["Versiculo"].Value.ToString();
                    */

                    string[] partes = informacion.Split(' ');
                    string version = partes[0];
                    if (version == "KING")
                    {
                        version += " " + partes[1];
                        libro = partes[2];
                        string capituloVersiculo = partes[3]; // "13:"
                        string[] capituloVersiculoPartes = capituloVersiculo.Split(':');
                        capitulo = capituloVersiculoPartes[0]; // "13"
                        versiculo = capituloVersiculoPartes.Length > 1 ? capituloVersiculoPartes[1] : ""; // "" (vacío en este caso)
                    }
                    else
                    {
                        version += " " + partes[1];
                        version += " " + partes[2];
                        libro = partes[3];
                        string capituloVersiculo = partes[4]; // "13:"
                        string[] capituloVersiculoPartes = capituloVersiculo.Split(':');
                        capitulo = capituloVersiculoPartes[0]; // "13"
                        versiculo = capituloVersiculoPartes.Length > 1 ? capituloVersiculoPartes[1] : ""; // "" (vacío en este caso)
                    }
                    

                    int capituloNumero, versiculoNumero = 0;

                    if (versiculo == "")
                        versiculoNumero = 0;
                    else
                        versiculoNumero = Int32.Parse(versiculo);

                    if (!Int32.TryParse(capitulo, out capituloNumero))
                    {
                        // Uno de los valores no se pudo convertir a un número entero.
                        // Puedes manejar este caso como prefieras.
                        return;
                    }

                    var sql = new EnlaceDB();
                    var tabla = sql.Consultar(1, libro, capituloNumero, versiculoNumero, version);
                    dataGridView1.DataSource = tabla;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            
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
            if (nombreFavorito == "")
                VariablesGlobales.mensaje("ERROR", "No has seleccionado ningun favorito");
            else
            {
                VariablesGlobales.mensajePregunta("Estas seguro de querer eliminar el favorito?");
                if (VariablesGlobales.RespuestaMensaje)
                {
                    bool error = false;
                    var sql = new EnlaceDB();
                    error = sql.eliminarFavorito(9, nombreFavorito);
                    if (!error)
                    {
                        VariablesGlobales.mensaje("Exito", "Favorito eliminado");
                        var tabla = sql.Favorito(8);
                        dataGridView3.DataSource = tabla;
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        foreach (DataGridViewRow row in dataGridView3.Rows)
                        {
                            //separacion de informacion
                            string informacion = row.Cells["Informacion"].Value.ToString();
                            string[] partes = informacion.Split(' ');
                            string version = partes[0];
                            string libro = partes[1];
                            string capituloVersiculo = partes[2]; // "13:"
                            string mes = partes[3];
                            string dia = partes[4];
                            string year = partes[5];
                            string hora = partes[6];

                            version = versiones[Int32.Parse(version) - 1];
                            libro = libros[Int32.Parse(libro) - 1];
                            string informacionFinal = version + " " + libro + " " + capituloVersiculo + " " + mes + " " + dia + " " + year + " " + hora;
                            row.Cells["Informacion"].Value = informacionFinal;
                            dataGridView3.ClearSelection();
                        }
                    }
                    else
                    {
                        VariablesGlobales.mensaje("ERROR", "Error al eliminar favorito");
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            letra = Int32.Parse(textBox2.Text);
            if (letra < 30)
            {
                letra++;
                textBox2.Text = letra.ToString();
            }
            dataGridView3.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            letra = Int32.Parse(textBox2.Text);
            if (letra > 5)
            {
                letra--;
                textBox2.Text = letra.ToString();
            }
            dataGridView3.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Yu Gothic UI", letra, FontStyle.Bold);
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
