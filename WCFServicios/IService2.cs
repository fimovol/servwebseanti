using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

//librerias
using System.Data;
using System.Data.SqlClient;
namespace WCFServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService2" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService2
    {
        //definicíon de metodos
        [OperationContract] DataSet Clientes();
        [OperationContract] DataSet Paises();
        [OperationContract] string Agregar(Cliente reg);
        [OperationContract] string Actualizar(Cliente reg);
        [OperationContract] string Eliminar(Cliente reg);

    }
    [DataContract]
    public class Cliente
    {
        //atributos
        private string idcliente, nombrecli, direccion, idpais, telefono;
        
        [DataMember]
        public string Idcliente
        {
            get { return idcliente; } set { idcliente = value; }
        }
        [DataMember]
        public string Nombrecli
        {
            get { return nombrecli; }
            set { nombrecli = value; }
        }
        [DataMember]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [DataMember]
        public string Idpais
        {
            get { return idpais; }
            set { idpais = value; }
        }
        [DataMember]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}
