using eSecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public partial class Gabe_Splash : Form
    {
        const int TiempoPorDefecto = 1000;
        private delegate void LlamarProceso(string pMensaje, SplashProcess pProceso);
        private Thread _Thread;

        enum SplashProcess
        {
            Inicializar = 0,
            Actualizando = 1,
            BaseDeDatos = 2,
            Integridad = 3,
            Iniciar = 4
        }

        public Gabe_Splash()
        {
            InitializeComponent();
        }

        private void InicializarValores()
        {
            Splash_LblStatus.Text = Idioma.ObtenerEtiqueta("Splash001_Msg000");
            Splash_BtnCancel.Text = Idioma.ObtenerEtiqueta("Splash_BtnCancel");
        }

        private void IniciarAplicacion()
        {
            Thread.Sleep(TiempoPorDefecto);
            this.Invoke(new LlamarProceso(ActualizarMensaje), Idioma.ObtenerEtiqueta("Splash001_Msg001"), SplashProcess.Actualizando);

            Thread.Sleep(TiempoPorDefecto);
            this.Invoke(new LlamarProceso(ActualizarMensaje), Idioma.ObtenerEtiqueta("Splash001_Msg002"), SplashProcess.BaseDeDatos);

            Thread.Sleep(TiempoPorDefecto);
            this.Invoke(new LlamarProceso(ActualizarMensaje), Idioma.ObtenerEtiqueta("Splash001_Msg003"), SplashProcess.Integridad);

            Thread.Sleep(TiempoPorDefecto);
            this.Invoke(new LlamarProceso(ActualizarMensaje), Idioma.ObtenerEtiqueta("Splash001_Msg004"), SplashProcess.Iniciar);

            if (this.InvokeRequired)
                this.Invoke(new Action(FinalizarProceso));
        }

        private void ActualizarMensaje(string pMensaje, SplashProcess pProceso)
        {
            Splash_LblStatus.Text = pMensaje;

            if (pProceso == SplashProcess.Integridad)
            {
                if (DigitoVerificador.VerificarIntegridad() == 2)
                    MessageBox.Show(Idioma.ObtenerEtiqueta("Splash001_MsgBox001"), "", MessageBoxButtons.OK);
            }
        }

        private void FinalizarProceso()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Gabe_Splash_Shown(object sender, EventArgs e)
        {
            InicializarValores();
            _Thread = new Thread(IniciarAplicacion);
            _Thread.Start();
        }

        private void Gabe_Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Thread != null && _Thread.IsAlive)
            {
                _Thread.Abort();
                _Thread = null;
            }
        }
    }
}
