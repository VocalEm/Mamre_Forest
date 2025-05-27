using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAD_0._1
{
    internal class VariablesGlobales
    {
        public static void mensaje (string titulo, string Texto)
        {
            Mensaje msg = new Mensaje();
            msg.label2.Text = titulo;
            msg.label1.Text = Texto;

            msg.ShowDialog();
        }

        public static void mensajePregunta(string Mensaje)
        {
            MensajePregunta msg = new MensajePregunta();
            msg.label1.Text = Mensaje;
            msg.ShowDialog();
        }

        public static bool RespuestaMensaje { get; set; }
        public static string correoActual { get; set; }
        public static string passwordActual { get; set; }
        public static string nombreActual { get; set; }
        public static int  IdiomaActual { get; set; }
        public static int letra { get; set; }
    }
}
