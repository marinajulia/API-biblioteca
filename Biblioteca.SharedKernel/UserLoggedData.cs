using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.SharedKernel {
    public class UserLoggedData
    {
        private readonly List<DataToken> _data;

        public UserLoggedData() 
        {
            _data = new List<DataToken>();
        }

        public void Add(int idUsuario, int idPerfilUsuario)
        {
            _data.Add(new DataToken 
            {
                Id_PerfilUsuario = idPerfilUsuario,
                Id_Usuario = idUsuario
            });
        }

        public DataToken GetData() 
        {
            return _data.FirstOrDefault();
        }
    }

    public class DataToken 
    {
        public int Id_Usuario { get; set; }
        public int Id_PerfilUsuario { get; set; }
    }
}
