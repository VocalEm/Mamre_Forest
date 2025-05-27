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

    public partial class Historial : Form
    {
        bool carga = false;
        int letra = 0;
        bool fullscreen = false;
        List<string> Versiones;
        List<string> Testamentos;
        List<string> Libros;
        string idBusqueda = "";
        int posY = 0;
        int posX = 0;
        Perfil_Usuario perfil_Usuario;
        public Historial()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void Historial_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.IdiomaActual == 2)
            {
                button3.Text = "Delete Search";
                button2.Text = "Delete All";
                button1.Text = "Return";
                label6.Text = "Font Size";
                label2.Text = "History";
            }
            label3.Text = VariablesGlobales.nombreActual;
            label1.Text = VariablesGlobales.correoActual;

     

            var sql = new EnlaceDB();
            Versiones = sql.Versiones(4);
            Testamentos = sql.Testamentos(6);
            Libros = sql.Libros(3);
            dataGridView3.DataSource = sql.Historial(11);

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                string informacion = row.Cells["Informacion"].Value.ToString();
                string[] partes = informacion.Split(' ');
                string libro = "";
                string testamento = "";
                string version = "";
                string informacionFinal = "";
                int caso = 0;
                switch (partes.Length)
                {
                    case 3:
                        {
                            version = partes[0];
                            testamento = partes[1];
                            libro = partes[2];
                            caso = 3;
                        }
                        break; //cifrado completo
                    case 4: // version solo testamento y toda la bilbia
                        {
                            version = partes[0];
                            testamento = partes[1];
                            if (testamento == "")
                            {
                                testamento += " " + partes[2];
                                testamento += " " + partes[3];
                                testamento += " " + partes[4];
                            }
                            else
                            {
                                libro = partes[2];
                                libro += " " + partes[3];
                            }
                            caso = 4;
                        }
                        break;
                    case 5:
                        {
                            version = partes[0];
                            testamento = partes[1];
                            testamento = partes[2];
                            testamento += " " + partes[3];
                            testamento += " " + partes[4];
                            caso = 5;
                        }
                        break; // version testamento y solo testamento
                }
                //separacion de informacion
                switch (caso)
                {
                    case 3:
                        {
                            version = Versiones[Int32.Parse(version) - 1];
                            libro = Libros[Int32.Parse(libro) - 1];
                            testamento = Testamentos[Int32.Parse(testamento) - 1];
                            informacionFinal = version + " " + testamento + " " + libro;
                        }
                        break;
                    case 4:
                        {
                            if (VariablesGlobales.IdiomaActual == 1)
                            {
                                version = Versiones[Int32.Parse(version) - 1];
                                if (testamento == "TODA LA BIBLIA")
                                {
                                    informacionFinal = version + " " + testamento;
                                }
                                else
                                {
                                    testamento = Testamentos[Int32.Parse(testamento) - 1];
                                    informacionFinal = version + " " + testamento + " " + libro;
                                }
                            }
                            else if (VariablesGlobales.IdiomaActual == 2)
                            {
                                version = Versiones[Int32.Parse(version) - 1];
                                if (testamento == "TODA LA BIBLIA")
                                {
                                    testamento = "ALL BIBLE";
                                    informacionFinal = version + " " + testamento;
                                }
                                else
                                {
                                    testamento = Testamentos[Int32.Parse(testamento) - 1];
                                    if (libro == "SOLO TESTAMENTO")
                                    {
                                        libro = "ONLY TESTAMENT";
                                    }
                                    informacionFinal = version + " " + testamento + " " + libro;
                                }
                            }

                        }
                        break;
                    case 5:
                        {
                            if (VariablesGlobales.IdiomaActual == 1)
                            {
                                version = Versiones[Int32.Parse(version) - 1];
                                informacionFinal = version + " " + testamento;
                            }
                            else if (VariablesGlobales.IdiomaActual == 2)
                            {
                                version = Versiones[Int32.Parse(version) - 1];
                                if (testamento == "TODA LA BIBLIA")
                                {
                                    testamento = "ALL BIBLE";
                                }
                                informacionFinal = version + " " + testamento;
                            }

                        }
                        break;
                }

                row.Cells["Informacion"].Value = informacionFinal;
            }


            dataGridView3.ClearSelection();
            carga = true;
            textBox2.Text = VariablesGlobales.letra.ToString();
        }

        private void Historial_MouseMove(object sender, MouseEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var sql = new EnlaceDB();
            bool error = false;
            VariablesGlobales.mensajePregunta("Seguro que quieres eliminar todo el historial?");
            if (VariablesGlobales.RespuestaMensaje)
            {
                error = sql.eliminarHistorial(12);
                if (!error)
                    VariablesGlobales.mensaje("EXITO", "Historial eliminado");

                else
                    VariablesGlobales.mensaje("ERROR", "ERROR");
                dataGridView3.DataSource = sql.Historial(11);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool error = false;
            int ID = 0;
            if (idBusqueda == "")
                VariablesGlobales.mensaje("ERROR", "Necesita elegir una busqueda");
            else
            {
                ID = Int32.Parse(idBusqueda);
                var sql = new EnlaceDB();
                VariablesGlobales.mensajePregunta("Seguro que quieres eliminar la busqueda?");
                if (VariablesGlobales.RespuestaMensaje)
                {
                    error = sql.eliminarBusqueda(13, ID);
                    if (!error)
                        VariablesGlobales.mensaje("EXITO", "Se elimino la busqueda");
                    else
                        VariablesGlobales.mensaje("ERROR", "ERROR");
                    carga = false;
                    dataGridView3.DataSource = sql.Historial(11);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    carga = true;
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        string informacion = row.Cells["Informacion"].Value.ToString();
                        string[] partes = informacion.Split(' ');
                        string libro = "";
                        string testamento = "";
                        string version = "";
                        string informacionFinal = "";
                        int caso = 0;
                        switch (partes.Length)
                        {
                            case 3:
                                {
                                    version = partes[0];
                                    testamento = partes[1];
                                    libro = partes[2];
                                    caso = 3;
                                }
                                break; //cifrado completo
                            case 4: // version solo testamento y toda la bilbia
                                {
                                    version = partes[0];
                                    testamento = partes[1];
                                    if (testamento == "")
                                    {
                                        testamento += " " + partes[2];
                                        testamento += " " + partes[3];
                                        testamento += " " + partes[4];
                                    }
                                    else
                                    {
                                        libro = partes[2];
                                        libro += " " + partes[3];
                                    }
                                    caso = 4;
                                }
                                break;
                            case 5:
                                {
                                    version = partes[0];
                                    testamento = partes[1];
                                    testamento = partes[2];
                                    testamento += " " + partes[3];
                                    testamento += " " + partes[4];
                                    caso = 5;
                                }
                                break; // version testamento y solo testamento
                        }
                        //separacion de informacion
                        switch (caso)
                        {
                            case 3:
                                {
                                    version = Versiones[Int32.Parse(version) - 1];
                                    libro = Libros[Int32.Parse(libro) - 1];
                                    testamento = Testamentos[Int32.Parse(testamento) - 1];
                                    informacionFinal = version + " " + testamento + " " + libro;
                                }
                                break;
                            case 4:
                                {
                                    if (VariablesGlobales.IdiomaActual == 1)
                                    {
                                        version = Versiones[Int32.Parse(version) - 1];
                                        if (testamento == "TODA LA BIBLIA")
                                        {
                                            informacionFinal = version + " " + testamento;
                                        }
                                        else
                                        {
                                            testamento = Testamentos[Int32.Parse(testamento) - 1];
                                            informacionFinal = version + " " + testamento + " " + libro;
                                        }
                                    }
                                    else if (VariablesGlobales.IdiomaActual == 2)
                                    {
                                        version = Versiones[Int32.Parse(version) - 1];
                                        if (testamento == "TODA LA BIBLIA")
                                        {
                                            testamento = "ALL BIBLE";
                                            informacionFinal = version + " " + testamento;
                                        }
                                        else
                                        {
                                            testamento = Testamentos[Int32.Parse(testamento) - 1];
                                            if (libro == "SOLO TESTAMENTO")
                                            {
                                                libro = "ONLY TESTAMENT";
                                            }
                                            informacionFinal = version + " " + testamento + " " + libro;
                                        }
                                    }

                                }
                                break;
                            case 5:
                                {
                                    if (VariablesGlobales.IdiomaActual == 1)
                                    {
                                        version = Versiones[Int32.Parse(version) - 1];
                                        informacionFinal = version + " " + testamento;
                                    }
                                    else if (VariablesGlobales.IdiomaActual == 2)
                                    {
                                        version = Versiones[Int32.Parse(version) - 1];
                                        if (testamento == "TODA LA BIBLIA")
                                        {
                                            testamento = "ALL BIBLE";
                                        }
                                        informacionFinal = version + " " + testamento;
                                    }

                                }
                                break;
                        }

                        row.Cells["Informacion"].Value = informacionFinal;
                    }


                    dataGridView3.ClearSelection();
                }
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (carga)
            {
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    string informacion = "", version = "", testamento = "", libro = "";

                    string palabras = "";
                    string[] partes;

                    DataGridViewRow row = dataGridView3.SelectedRows[0];
                    idBusqueda = row.Cells["ID"].Value.ToString();
                    informacion = row.Cells["Informacion"].Value.ToString();
                    palabras = row.Cells["Palabras"].Value.ToString();


                    partes = informacion.Split(' ');
                    if (partes.Length > 3)
                    {

                        version = partes[0];
                        if (version == "KING")
                        {
                            version += " " + partes[1];
                            if (VariablesGlobales.IdiomaActual == 1)
                            {
                                testamento = partes[2];
                                if (testamento == "TODA")
                                {
                                    testamento += " " + partes[3];
                                    testamento += " " + partes[4];
                                }
                                else
                                {
                                    testamento += " " + partes[3];
                                    libro += partes[4];
                                    if (libro == "SOLO")
                                    {
                                        libro += " " + partes[5];
                                    }
                                    else if (partes.Length > 6)
                                    {
                                        libro += " " + partes[7];
                                    }
                                }
                            }

                            if (VariablesGlobales.IdiomaActual == 2)
                            {
                                testamento = partes[2];
                                if (testamento == "ALL")
                                {
                                    testamento += " " + partes[3];
                                }
                                else
                                {
                                    testamento += " " + partes[3];
                                    libro += partes[4];
                                    if (libro == "ONLY")
                                    {
                                        libro += " " + partes[5];
                                    }
                                    else if (partes.Length > 6)
                                    {
                                        libro += " " + partes[6];
                                    }
                                }
                            }
                        }

                        else
                        {
                            version += " " + partes[1];
                            version += " " + partes[2];
                            if (VariablesGlobales.IdiomaActual == 1)
                            {
                                testamento = partes[3];
                                if (testamento == "TODA")
                                {
                                    testamento += " " + partes[4];
                                    testamento += " " + partes[5];
                                }
                                else
                                {
                                    testamento += " " + partes[4];
                                    libro += partes[5];
                                    if (libro == "SOLO")
                                    {
                                        libro += " " + partes[6];
                                    }
                                    else if (partes.Length > 7)
                                    {
                                        libro += " " + partes[6];
                                    }
                                }
                            }

                            if (VariablesGlobales.IdiomaActual == 2)
                            {
                                testamento = partes[3];
                                if (testamento == "ALL")
                                {
                                    testamento += " " + partes[4];
                                }
                                else
                                {
                                    testamento += " " + partes[4];
                                    libro += partes[5];
                                    if (libro == "ONLY")
                                    {
                                        libro += " " + partes[6];
                                    }
                                    else if (partes.Length > 7)
                                    {
                                        libro += " " + partes[6];
                                    }
                                }
                            }
                        }


                        var sql = new EnlaceDB();
                        dataGridView1.DataSource = sql.buscar(2, version, testamento, libro, palabras);
                    }
                }

            }

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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
