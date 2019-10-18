using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService_CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService2" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void crear(int nc, string nom, int c1, int c2, int c3, int c4, int c5);
        [OperationContract]
        bool modificar(int nc, string nom, int c1, int c2, int c3, int c4, int c5);
        [OperationContract]
        bool eliminar(int nc);
        [OperationContract]
        List<string> leer();
        [OperationContract]
        string[] buscar(int nc);
    }
}
