using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_Bus
    {

        D_Bus d_Bus = new D_Bus();

        public List<E_Conductor> showingDrivers(string buscar)
        {
            return d_Bus.driverDataShow(buscar);
        }

        public List<E_Bus> showingBus(string buscar)
        {
            return d_Bus.BusDataShow(buscar);
        }

        public List<E_Ruta> showingRoutes(string buscar)
        {
            return d_Bus.RouteDataShow(buscar);
        }

        public List<E_Viaje> showingTrip (string buscar)
        {
            return d_Bus.TripDataShow(buscar);
        }

        public void insertingDrivers(E_Conductor e)
        {
            d_Bus.insertDriver(e);
        }

        public void insertingBus(E_Bus e)
        {
            d_Bus.insertBus(e);
        }

        public void insertingRoutes(E_Ruta e)
        {
            d_Bus.insertRoute(e);
        }

        public DataTable comboBus()
        {
            return d_Bus.comboAutobus();
        }

        public DataTable comboRuta()
        {
            return d_Bus.comboRuta();
        }

        public void updatingTrip(E_Conductor e)
        {
            d_Bus.updateTrip(e);
        }

        public void updatingDriver(E_Conductor e)
        {
            d_Bus.updateDriver(e);
        }
        public void updatingBus(E_Bus e)
        {
            d_Bus.updateBus(e);
        }
        public void updatingRoute(E_Ruta e)
        {
            d_Bus.updateRoute(e);
        }

        public void deletingDriver(E_Conductor e)
        {
            d_Bus.deleteDriver(e);
        }
        public void deletingBus(E_Bus e)
        {
            d_Bus.deleteBus(e);
        }
        public void deletingRoutes(E_Ruta e)
        {
            d_Bus.deleteRoute(e);
        }

    }
}
