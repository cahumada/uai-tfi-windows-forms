using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFramework
{
    public abstract class ObjetoSimple
    {
        private EstadosLista estadoLista;
        private int indiceLista;
        private int codigoUsuario;

        public event RequerimientoLazyLoadEventHandler RequerimientoLazyLoad;

        public delegate void RequerimientoLazyLoadEventHandler();

        public EstadosLista EstadosLista
        {
            get { return estadoLista; }
            set { estadoLista = value; }
        }

        public int IndiceLista
        {
            get { return indiceLista; }
            set { indiceLista = value; }
        }

        public int CodigoUsuario
        {
            get { return codigoUsuario; }
            set { codigoUsuario = value; }
        }

        public abstract void Guardar();
        public abstract void Eliminar();
        public abstract DataSet ObtenerDataSet();

    }
}

