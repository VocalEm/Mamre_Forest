/*
Autor: Alejandro Villarreal

LMAD

PARA EL PROYECTO ES OBLIGATORIO EL USO DE ESTA CLASE, 
EN EL SENTIDO DE QUE LOS DATOS DE CONEXION AL SERVIDOR ESTAN DEFINIDOS EN EL App.Config
Y NO TENER ESOS DATOS EN CODIGO DURO DEL PROYECTO.

NO SE PERMITE HARDCODE.

LOS MÉTODOS QUE SE DEFINEN EN ESTA CLASE SON EJEMPLOS, PARA QUE SE BASEN Y USTEDES HAGAN LOS SUYOS PROPIOS
Y DEFINAN Y PROGRAMEN TODOS LOS MÉTODOS QUE SEAN NECESARIOS PARA SU PROYECTO.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MAD_0._1
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();
  
        private static void conectar(string conexion)
        {
            /*
			Para que funcione el ConfigurationManager
			en la sección de "Referencias" de su proyecto, en el "Solution Explorer"
			dar clic al botón derecho del mouse y dar clic a "Add Reference"
			Luego elegir la opción System.Configuration
			
			tal como lo vimos en clase.
			*/
            string cnn = ConfigurationManager.ConnectionStrings[conexion].ToString(); 
			// Cambiar Grupo01 por el que ustedes hayan definido en el App.Confif
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }
        private static void desconectar()
        {
            _conexion.Close();
        }

        public bool AddUsuarios(int opcion, string nombre, string ApPat, string ApMat, string fechaNacimiento, bool genero, string correo, string password, int codigoRecuperacion)
        {
            var msg = "";
            bool Error = true;
            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                var parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = nombre;
                var parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = ApPat;
                var parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = ApMat;
                var parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = fechaNacimiento;
                var parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = genero;
                var parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                var parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = password;
                var parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = codigoRecuperacion;
                var parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                var parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                var parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                var parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;



                _adaptador.InsertCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso

            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
           
        }

        public bool IniciarSesion(int opcion,string correo, string password)
        {
            var msg = "";
            bool Error = true;
            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = password;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;



                _adaptador.InsertCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso

            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public usuario MostrarInfoUsuario(int opcion, string correo, string contraseña)
        {
            usuario user = new usuario();
            var msg = "";
            bool error = true, genero;
            string nombre, aP, aM, email, FechaReg;
            DateTime fechaNac;
            int idioma, letra;
            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = contraseña;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                // _adaptador.InsertCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
                user.Nombre = (string)parametro15.Value;
                user.ApPat = (string)parametro16.Value;
                user.ApMat = (string)parametro23.Value;
                user.FechaNacimiento = (DateTime)parametro17.Value;
                user.genero = (bool)parametro18.Value;
                user.Correo = (string)parametro19.Value;
                user.TamañoLetra = (int)parametro20.Value;
                user.IdiomaPref = (int)parametro21.Value;
                user.FechaRegistro = (DateTime)parametro22.Value;
                
            }

            catch (SqlException e)
            {
                error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return user;
        }

        public bool BajaLogica(int opcion, string correo)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = DBNull.Value;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.UpdateCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso

            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public bool RecuperacionCuenta(int opcion, string correo,string passwordNueva, int codigo)
        {
            var msg = "";
            bool Error = false;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = DBNull.Value;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = codigo;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = passwordNueva;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;



                _adaptador.UpdateCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso

            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }

            return Error;
        }

        public bool ActualizarUsuario(int opcion, string nombre, string ApPat, string ApMat, string correo, int codigoRecuperacion, int IdiomaPreferido, int letra, string passwordNuevo, bool genero)
        {
            bool Error = true;
            var msg = "";

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                var parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = nombre;
                var parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = ApPat;
                var parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = ApMat;
                var parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                var parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = genero;
                var parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = correo;
                var parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                var parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = codigoRecuperacion;
                var parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                var parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = letra;
                var parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = IdiomaPreferido;
                var parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = passwordNuevo;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;



                _adaptador.UpdateCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso

            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }

            return Error;
        }

        public DataTable Consultar(int opc, string libro, int capitulo, int versiculo, string version)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = version;
                var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                parametro4.Value = libro;
                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = capitulo;
                if(versiculo <= 0)
                {
                    var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                    parametro6.Value = DBNull.Value;
                }
                else
                {
                    var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                    parametro6.Value = versiculo;
                }
                var parametro7 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro7.Value = DBNull.Value;
                var parametro8 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                parametro8.Value = DBNull.Value;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
                // la ejecución del SP espera que regrese datos en formato tabla

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool AgregarFavorito(int opcion, int version, int libro, int capitulo, int versiculo,string nombre)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opcion;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = nombre;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = version;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = libro;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = capitulo;
                if(versiculo<= 0)
                {
                    SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                    parametro28.Value = DBNull.Value;
                }
                else 
                {
                    SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                    parametro28.Value = versiculo;
                }

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;


                _adaptador.InsertCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public DataTable Favorito(int opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                var parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                var parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                var parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                var parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                var parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                var parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                var parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                var parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
                // la ejecución del SP espera que regrese datos en formato tabla

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool eliminarFavorito(int opc, string nombre)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = nombre;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.DeleteCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public DataTable buscar(int opc,string version,string testamento,string libro, string palabras)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = version;

                if((testamento == "TODA LA BIBLIA" && (libro == "TODA LA BIBLIA" || libro == "")) || (testamento == "ALL BIBLE" && (libro == "ALL BIBLE" || libro == "")))
                {
                    var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                    parametro7.Value = DBNull.Value;
                    var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                    parametro4.Value = DBNull.Value;
                }
                else
                {
                    if(libro == "SOLO TESTAMENTO" || libro == "ONLY TESTAMENT")
                    {
                        var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                        parametro7.Value = testamento;
                        var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                        parametro4.Value = DBNull.Value;
                    }

                    else
                    {
                        var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                        parametro7.Value = testamento;
                        var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                        parametro4.Value = libro;
                    }
                }

                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = DBNull.Value; ;
                var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                parametro6.Value = DBNull.Value;

                var parametro8 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro8.Value = palabras;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
                // la ejecución del SP espera que regrese datos en formato tabla

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool agregarHistorial(int opc,string palabras,int versionNum, int testamentoNum, int numeroLibro)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = versionNum;
                if(numeroLibro == 0)
                {
                    SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                    parametro26.Value = DBNull.Value;
                }
                else
                {
                    SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                    parametro26.Value = numeroLibro;
                }

                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;
              

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro29.Value = palabras;
                if(testamentoNum == 0)
                {
                    SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                    parametro30.Value = DBNull.Value;
                }
                else
                {
                    SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                    parametro30.Value = testamentoNum;
                }
                

                _adaptador.InsertCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public DataTable Historial(int opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                var parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                var parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                var parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                var parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                var parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                var parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                var parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                var parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
                // la ejecución del SP espera que regrese datos en formato tabla

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool eliminarHistorial(int opc)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = VariablesGlobales.correoActual;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = DBNull.Value;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.DeleteCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public bool eliminarBusqueda(int opc,int Id)
        {
            var msg = "";
            bool Error = true;

            try
            {
                conectar("mad");
                string qry = "spUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametro1 = _comandosql.Parameters.Add("@opcion", SqlDbType.TinyInt, 1);
                parametro1.Value = opc;
                SqlParameter parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro2.Value = DBNull.Value;
                SqlParameter parametro3 = _comandosql.Parameters.Add("@ApPat", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;
                SqlParameter parametro4 = _comandosql.Parameters.Add("@ApMat", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
                SqlParameter parametro5 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.Date, 50);
                parametro5.Value = DBNull.Value;
                SqlParameter parametro6 = _comandosql.Parameters.Add("@Genero", SqlDbType.Bit, 1);
                parametro6.Value = DBNull.Value;
                SqlParameter parametro7 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                SqlParameter parametro8 = _comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50);
                parametro8.Value = DBNull.Value;
                SqlParameter parametro9 = _comandosql.Parameters.Add("@CodigoRec", SqlDbType.SmallInt, 2);
                parametro9.Value = DBNull.Value;
                SqlParameter parametro10 = _comandosql.Parameters.Add("@Estatus", SqlDbType.Bit, 1);
                parametro10.Value = DBNull.Value;
                SqlParameter parametro11 = _comandosql.Parameters.Add("@TamañoLetra", SqlDbType.Int, 4);
                parametro11.Value = DBNull.Value;
                SqlParameter parametro12 = _comandosql.Parameters.Add("@IdiomaPref", SqlDbType.Int, 4);
                parametro12.Value = DBNull.Value;
                SqlParameter parametro13 = _comandosql.Parameters.Add("@ID", SqlDbType.Int, 4);
                parametro13.Value = Id;
                SqlParameter parametro24 = _comandosql.Parameters.Add("@ContraseñaNueva", SqlDbType.VarChar, 50);
                parametro24.Value = DBNull.Value;

                SqlParameter parametro14 = _comandosql.Parameters.Add("@UsuarioError", SqlDbType.Bit, 1);
                parametro14.Direction = ParameterDirection.Output;
                SqlParameter parametro15 = _comandosql.Parameters.Add("@nombreOutput", SqlDbType.VarChar, 50);
                parametro15.Direction = ParameterDirection.Output;
                SqlParameter parametro16 = _comandosql.Parameters.Add("@ApPatOutput", SqlDbType.VarChar, 50);
                parametro16.Direction = ParameterDirection.Output;
                SqlParameter parametro17 = _comandosql.Parameters.Add("@FechaNacimientoOutput", SqlDbType.Date, 50);
                parametro17.Direction = ParameterDirection.Output;
                SqlParameter parametro18 = _comandosql.Parameters.Add("@GeneroOutput", SqlDbType.Bit, 1);
                parametro18.Direction = ParameterDirection.Output;
                SqlParameter parametro19 = _comandosql.Parameters.Add("@CorreoOutput", SqlDbType.VarChar, 50);
                parametro19.Direction = ParameterDirection.Output;
                SqlParameter parametro20 = _comandosql.Parameters.Add("@TamañoLetraOutput", SqlDbType.Int, 4);
                parametro20.Direction = ParameterDirection.Output;
                SqlParameter parametro21 = _comandosql.Parameters.Add("@IdiomaPrefOutput", SqlDbType.Int, 4);
                parametro21.Direction = ParameterDirection.Output;
                SqlParameter parametro22 = _comandosql.Parameters.Add("@FechaRegistroOutput", SqlDbType.SmallDateTime, 50);
                parametro22.Direction = ParameterDirection.Output;
                SqlParameter parametro23 = _comandosql.Parameters.Add("@ApMatOutput", SqlDbType.VarChar, 50);
                parametro23.Direction = ParameterDirection.Output;

                SqlParameter parametro25 = _comandosql.Parameters.Add("@NumeroVersion", SqlDbType.SmallInt, 2);
                parametro25.Value = DBNull.Value;
                SqlParameter parametro26 = _comandosql.Parameters.Add("@NumeroLibro", SqlDbType.SmallInt, 2);
                parametro26.Value = DBNull.Value;
                SqlParameter parametro27 = _comandosql.Parameters.Add("@NumeroCapitulo", SqlDbType.TinyInt, 1);
                parametro27.Value = DBNull.Value;
                SqlParameter parametro28 = _comandosql.Parameters.Add("@NumeroVersiculo", SqlDbType.TinyInt, 1);
                parametro28.Value = DBNull.Value;

                SqlParameter parametro29 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 50);
                parametro29.Value = DBNull.Value;
                SqlParameter parametro30 = _comandosql.Parameters.Add("@Testamento", SqlDbType.SmallInt, 2);
                parametro30.Value = DBNull.Value;

                _adaptador.DeleteCommand = _comandosql;
                // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

                _comandosql.ExecuteNonQuery();

                Error = (bool)parametro14.Value;//se guarada el resultado que nos regreso
            }

            catch (SqlException e)
            {
                Error = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {
                desconectar();
            }
            return Error;
        }

        public List<string> Libros (int opc)
        {
            var msg = "";
            List<string> nombresDeLibros = new List<string>();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
               

                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;

                var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;
           
                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = DBNull.Value; ;
                var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                parametro6.Value = DBNull.Value;

                var parametro8 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro8.Value = DBNull.Value;

                _comandosql.CommandTimeout = 1200;
                SqlDataReader reader = _comandosql.ExecuteReader();

                while(reader.Read())
                    nombresDeLibros.Add(reader.GetString(0));

                reader.Close();


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return nombresDeLibros;
        }
        public List<string> Versiones(int opc)
        {
            var msg = "";
            List<string> nombresDeVersion = new List<string>();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;


                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;

                var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;

                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = DBNull.Value; ;
                var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                parametro6.Value = DBNull.Value;

                var parametro8 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro8.Value = DBNull.Value;

                _comandosql.CommandTimeout = 1200;
                SqlDataReader reader = _comandosql.ExecuteReader();

                while (reader.Read())
                    nombresDeVersion.Add(reader.GetString(0));

                reader.Close();


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return nombresDeVersion;
        }
        public List<string> Testamentos(int opc)
        {
            var msg = "";
            List<string> nombresDeTestamentos = new List<string>();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;


                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;

                var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;

                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = DBNull.Value; ;
                var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                parametro6.Value = DBNull.Value;

                var parametro8 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro8.Value = DBNull.Value;

                _comandosql.CommandTimeout = 1200;
                SqlDataReader reader = _comandosql.ExecuteReader();

                while (reader.Read())
                    nombresDeTestamentos.Add(reader.GetString(0));

                reader.Close();


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return nombresDeTestamentos;
        }
        public List<int> Capitulos(int opc)
        {
            var msg = "";
            List<int> capitulosTotales = new List<int>();
            try
            {
                conectar("biblia");
                string qry = "spbiblia";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;


                var parametro1 = _comandosql.Parameters.Add("@Opcion", SqlDbType.TinyInt, 2);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Idioma", SqlDbType.Int, 4);
                parametro2.Value = DBNull.Value;
                var parametro3 = _comandosql.Parameters.Add("@Version", SqlDbType.VarChar, 50);
                parametro3.Value = DBNull.Value;

                var parametro7 = _comandosql.Parameters.Add("@Testamento", SqlDbType.VarChar, 50);
                parametro7.Value = DBNull.Value;
                var parametro4 = _comandosql.Parameters.Add("@Libro", SqlDbType.VarChar, 50);
                parametro4.Value = DBNull.Value;

                var parametro5 = _comandosql.Parameters.Add("@Capitulo", SqlDbType.TinyInt, 2);
                parametro5.Value = DBNull.Value; ;
                var parametro6 = _comandosql.Parameters.Add("@Versiculo", SqlDbType.TinyInt, 2);
                parametro6.Value = DBNull.Value;

                var parametro8 = _comandosql.Parameters.Add("@Palabras", SqlDbType.VarChar, 100);
                parametro8.Value = DBNull.Value;

                _comandosql.CommandTimeout = 1200;
                SqlDataReader reader = _comandosql.ExecuteReader();

                while (reader.Read())
                    capitulosTotales.Add(reader.GetByte(0));

                reader.Close();


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return capitulosTotales;
        }
    }


    public class usuario()
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApPat { get; set; }
        public string ApMat { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdiomaPref { get; set; }
        public int TamañoLetra { get; set; }
        public bool genero { get; set; }
    }

}
/*
 *     public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

   public bool Autentificar(string us, string ps)
   {
       bool isValid = false;
       try
       {
           conectar();
           string qry = "SP_ValidaUser";
           _comandosql = new SqlCommand(qry, _conexion);
           _comandosql.CommandType = CommandType.StoredProcedure;
           _comandosql.CommandTimeout = 9000;

           var parametro1 = _comandosql.Parameters.Add("@u", SqlDbType.Char, 20);
           parametro1.Value = us;
           var parametro2 = _comandosql.Parameters.Add("@p", SqlDbType.Char, 20);
           parametro2.Value = ps;

           _adaptador.SelectCommand = _comandosql;
           _adaptador.Fill(_tabla);

           if(_tabla.Rows.Count > 0)
           {
               isValid = true;
           }

       }
       catch(SqlException e)
       {
           isValid = false;
       }
       finally
       {
           desconectar();
       }

       return isValid;
   }

   public DataTable get_Users()
   {
       var msg = "";
       DataTable tabla = new DataTable();
       try
       {
           conectar();
           // Ejemplo de cómo ejecutar un query, 
           // PERO lo correcto es siempre usar SP para cualquier consulta a la base de datos
           string qry = "Select Nombre, email, Fecha_modif from Usuarios where Activo = 0;";
           _comandosql = new SqlCommand(qry, _conexion);
           _comandosql.CommandType = CommandType.Text;
                   // Esta opción solo la podrían utilizar si hacen un EXEC al SP concatenando los parámetros.
           _comandosql.CommandTimeout = 1200;

           _adaptador.SelectCommand = _comandosql;
           _adaptador.Fill(tabla);

       }
       catch (SqlException e)
       {
           msg = "Excepción de base de datos: \n";
           msg += e.Message;
           MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
       }
       finally
       {
           desconectar();
       }

       return tabla;
   }

   // Ejemplo de método para recibir una consulta en forma de tabla
   // Cuando el SP ejecutará un SELECT
   /*public DataTable get_Deptos(string opc)
   {
       var msg = "";
       DataTable tabla = new DataTable();
       try
       {
           conectar();
           string qry = "sp_Gestiona_Deptos";
           _comandosql = new SqlCommand(qry, _conexion);
           _comandosql.CommandType = CommandType.StoredProcedure;
           _comandosql.CommandTimeout = 1200;

           var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
           parametro1.Value = opc;


           _adaptador.SelectCommand = _comandosql;
           _adaptador.Fill(tabla); 
           // la ejecución del SP espera que regrese datos en formato tabla

       }
       catch (SqlException e)
       {
           msg = "Excepción de base de datos: \n";
           msg += e.Message;
           MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
       }
       finally
       {
           desconectar();
       }

       return tabla;
   }*/
// Ejemplo de método para ejecutar un SP que no se espera que regrese información, 
// solo que ejecute ya sea un INSERT, UPDATE o DELETE
/*public bool Add_Deptos(string opc, string depto)
  {
      var msg = "";
      var add = true;
      try
      {
          conectar();
          string qry = "sp_Gestiona_Deptos";
          _comandosql = new SqlCommand(qry, _conexion);
          _comandosql.CommandType = CommandType.StoredProcedure;
          _comandosql.CommandTimeout = 1200;

          var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
          parametro1.Value = opc;
          var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
          parametro2.Value = depto;

          _adaptador.InsertCommand = _comandosql;
          // También se tienen las propiedades del adaptador: UpdateCommand  y DeleteCommand

          _comandosql.ExecuteNonQuery();

      }
      catch (SqlException e)
      {
          add = false;
          msg = "Excepción de base de datos: \n";
          msg += e.Message;
          MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
      finally
      {
          desconectar();                
      }

      return add;
  }
*/