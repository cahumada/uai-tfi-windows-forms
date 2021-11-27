using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFramework
{
    [Flags]
    public enum EstadosABM
    {
        Nuevo = 1,
        Modificar = 2,
        Eliminar = 3,
        Consulta = 4,
        CambiarIdioma = 5,
        Desbloquear = 6,
        BlanquearClave = 7,
        Cancelar = 8,
        SinCambios = 9
    }

    [Flags]
    public enum EstadosLista
    {
        SinCambios = 0,
        Agregado = 1,
        Eliminado = 2,
        Quitado = 3,
        Modificado = 4
    }

    [Flags]
    public enum TipoAgregacion
    {
        UnoAMuchos,
        MuchosAMuchos
    }
}
