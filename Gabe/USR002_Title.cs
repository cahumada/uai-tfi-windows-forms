using eSecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static eFramework.Constantes;

namespace Gabe
{
    public partial class USR002_Title : Form
    {
        int codigoUsuario;
        Usuarios usuario;
        EstadosABM estados;


        public USR002_Title(int pCodigoUsuario, Usuarios usuario = null, EstadosABM pEstado = EstadosABM.Nuevo)
        {
            InitializeComponent();
        }
    }
}
