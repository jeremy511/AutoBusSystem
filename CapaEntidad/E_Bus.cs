using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Bus
    {
        private int _Id;
        private string _Marca, _Modelo, _Placa, _Color, _Año;

        public int Id { get => _Id; set => _Id = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Placa { get => _Placa; set => _Placa = value; }
        public string Color { get => _Color; set => _Color = value; }
        public string Año { get => _Año; set => _Año = value; }
    }

    public class E_Conductor
    {
        private int _Id,_IdBus,IdRuta;
        private string _Nombre, _Apellido, _Cedula;
        private DateTime _Fecha;

        public int Id { get => _Id; set => _Id = value; }
        public int IdBus { get => _IdBus; set => _IdBus = value; }
        public int IdRuta1 { get => IdRuta; set => IdRuta = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
    }

    public class E_Ruta
    {
        private int _Id;
        private string _Ruta;

        public int Id { get => _Id; set => _Id = value; }
        public string Ruta { get => _Ruta; set => _Ruta = value; }
    }

    public class E_Viaje
    {
        private string _Nombre, _Apellido, _Cedula, _Marca, _Modelo, _Placa, _Ruta;
        private int _Id, _IdBUS,_IdRuta;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Placa { get => _Placa; set => _Placa = value; }
        public string Ruta { get => _Ruta; set => _Ruta = value; }
        public int IdBUS { get => _IdBUS; set => _IdBUS = value; }
        public int IdRuta { get => _IdRuta; set => _IdRuta = value; }
    }
}
