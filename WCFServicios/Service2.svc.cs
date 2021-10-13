using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace WCFServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service2" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service2.svc o Service2.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service2 : IService2
    {
        SqlConnection cn = new SqlConnection("Server=tcp:servido602.database.windows.net,1433;Initial Catalog=prueba;Persist Security Info=False;User ID=rootsenati;Password=Contrasena123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        string IService2.Eliminar(Cliente reg)
        {
            string msg = "";
            //SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[tb_clientes2] WHERE idpais=@idpais", cn);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[tb_clientes] WHERE idpais=@idcli", cn);

            //cmd.Parameters.AddWithValue("@idpais", reg.Idcliente);
            cmd.Parameters.AddWithValue("@idcli", reg.Idcliente);

            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                msg = i.ToString() + " Registro ELIMINADO correctamente";

            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return msg;
        }
        string IService2.Actualizar(Cliente reg)
        {
            //throw new NotImplementedException();
            string msg = "";
            //tabla clientes2
            //SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tb_clientes2] SET nom=@nom,dir=@dir,fono=@fono WHERE idpais=@idpais", cn);
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tb_clientes] SET nom=@nom,dir=@dir,fono=@fono WHERE idpais=@idcli", cn);

            //cmd.Parameters.AddWithValue("@idpais", reg.Idcliente);
            cmd.Parameters.AddWithValue("@idcli", reg.Idcliente);
            cmd.Parameters.AddWithValue("@nom", reg.Nombrecli);
            cmd.Parameters.AddWithValue("@dir", reg.Direccion);
            //cmd.Parameters.AddWithValue("@idpais", reg.Idpais);
            cmd.Parameters.AddWithValue("@fono", reg.Telefono);

            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                msg = i.ToString() + " Registro ACTUALIZADO correctamente";

            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return msg;
        }

        string IService2.Agregar(Cliente reg)
        {
            string msg = "";
            //tabla clientes2
            //SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[tb_clientes2] VALUES (@idpais,@nom,@dir,@fono)", cn);
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[tb_clientes] VALUES (@nom,@dir,@fono)", cn);

            //tabla clientes2
            //cmd.Parameters.AddWithValue("@idpais", reg.Idcliente);
            cmd.Parameters.AddWithValue("@nom", reg.Nombrecli);
            cmd.Parameters.AddWithValue("@dir", reg.Direccion);
            //cmd.Parameters.AddWithValue("@idpais", reg.Idpais);
            cmd.Parameters.AddWithValue("@fono", reg.Telefono);

            cn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                msg = i.ToString() + " Registro Ingresado correctamente";
            
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return msg;

           }//Cierre del metodo agregar

        DataSet IService2.Clientes()
        {
            //tabla 2
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [dbo].[tb_clientes2]", cn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT idpais as ID,nom as NOMBRE,dir as DIRECCION,fono as TELEFONO FROM [dbo].[tb_clientes]", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        DataSet IService2.Paises()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [dbo].[tb_pais]", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
