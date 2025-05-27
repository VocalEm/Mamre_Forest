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
    public partial class MensajePregunta : Form
    {

        public MensajePregunta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VariablesGlobales.RespuestaMensaje = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.RespuestaMensaje = false;
            this.Close();
        }

        private void MensajePregunta_Load(object sender, EventArgs e)
        {

        }
    }
}
