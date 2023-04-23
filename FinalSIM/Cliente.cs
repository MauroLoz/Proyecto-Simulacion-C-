using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSIM
{
    class Cliente
    {
        //Variables Cliente
        private int id;
        private double fin_atencion;
        private double hora_espera;

        //GETs
        public int getId()
        {
            return id;
        }
        public double getFin_atencion()
        {
            return fin_atencion;
        }
        public double getHora_espera()
        {
            return hora_espera;
        }

        //SETs
        public void setId(int idNuevo)
        {
            id = idNuevo;
        }
        public void setFin_atencion(double fin_atencionNuevo)
        {
            fin_atencion = fin_atencionNuevo;
        }
        public void setHora_espera(double hora_esperaNuevo)
        {
            hora_espera = hora_esperaNuevo;
        }
    }
}
