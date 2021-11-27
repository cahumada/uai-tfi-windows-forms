using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eFramework
{
    public class ObjetoLista<T> : KeyedCollection<int, T> where T : ObjetoSimple
    {
        #region Eventos
        public event ElementoAgregadoEventHandler ElementoAgregado;

        public delegate void ElementoAgregadoEventHandler(ref T pElemento);

        public event ElementoEliminadoEventHandler ElementoEliminado;

        public delegate void ElementoEliminadoEventHandler(ref T pElemento);

        public event RelacionGuardadaEventHandler RelacionGuardada;

        public delegate void RelacionGuardadaEventHandler(ref T pElemento);

        public event RelacionEliminadaEventHandler RelacionEliminada;

        public delegate void RelacionEliminadaEventHandler(ref T pElemento);

        public event RequerimientoCargaEventHandler RequerimientoCarga;

        public delegate void RequerimientoCargaEventHandler();

        public event AsignarRelacionUnoAMuchosEventHandler AsignarRelacionUnoAMuchos;

        public delegate void AsignarRelacionUnoAMuchosEventHandler(ref T pElemento);

        public event InsertarRelacionMuchosAMuchosEventHandler InsertarRelacionMuchosAMuchos;

        public delegate void InsertarRelacionMuchosAMuchosEventHandler(ref T pElemento);

        public event EliminarRelacionMuchosAMuchosEventHandler EliminarRelacionMuchosAMuchos;

        public delegate void EliminarRelacionMuchosAMuchosEventHandler(ref T pElemento);

        #endregion

        public bool cambiosSinGuardar = false;
        public bool coleccionCargada = false;
        private int contador = 0;

        private TipoAgregacion tipoAgregacion = TipoAgregacion.UnoAMuchos;

        public ObjetoLista(TipoAgregacion pTipoAgregacion)
        {
            tipoAgregacion = pTipoAgregacion;
        }

        public void Cargar(bool pExceptoQueEsteCargada = false)
        {
            if (!this.coleccionCargada | !pExceptoQueEsteCargada)
                RequerimientoCarga?.Invoke();
        }

        public void Cargar(DataSet pDataset)
        {
            if (pDataset.Tables.Count > 0)
                Cargar(pDataset.Tables[0]);
        }

        public void Cargar(DataTable pDataTable)
        {
            if (pDataTable != null && pDataTable.Rows.Count > 0)
            {
                foreach (DataRow pDr in pDataTable.Rows)
                    this.AgregarElementoSinCambio((T)Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance, null, new object[] { pDr }, null));

                this.coleccionCargada = true;
            }
        }

        protected override int GetKeyForItem(T item)
        {
            item.IndiceLista = contador;
            contador++;
            return item.IndiceLista;
        }

        public virtual int Agregar(T pObjeto)
        {
            pObjeto.EstadosLista = EstadosLista.Agregado;
            cambiosSinGuardar = true;

            this.Add(pObjeto);
            ElementoAgregado?.Invoke(ref pObjeto);

            pObjeto.RequerimientoLazyLoad += this.DispararRequerimientoLazyLoad;
            return pObjeto.IndiceLista;
        }

        public virtual void Eliminar(T pObjeto)
        {
            int indice;
            if (pObjeto.IndiceLista == null)
                indice = this.IndexOf(pObjeto);
            else
                indice = pObjeto.IndiceLista;

            this.Eliminar(indice);
        }

        public virtual void Eliminar(int pIndice)
        {
            if (this.GetItem(pIndice).EstadosLista == EstadosLista.Agregado)
                this.GetItem(pIndice).EstadosLista = EstadosLista.Quitado;
            else
                this.GetItem(pIndice).EstadosLista = EstadosLista.Eliminado;

            var objeto = GetItem(pIndice);
            ElementoEliminado?.Invoke(ref objeto);
            cambiosSinGuardar = true;
        }

        public virtual void EliminarTodo()
        {
            for (int i = 0; i < base.Count; i++)
            {
                var objeto = this[i];

                if (EstadosLista.Agregado == objeto.EstadosLista)
                    objeto.EstadosLista = EstadosLista.Quitado;
                else
                    objeto.EstadosLista = EstadosLista.Eliminado;

                ElementoEliminado?.Invoke(ref objeto);

                cambiosSinGuardar = true;
            }
        }

        public virtual new T GetItem(int pIndice)
        {
            return base.Items[pIndice];
        }

        public virtual new void SetItem(int pIndice, T value)
        {
            if (this.GetItem(pIndice).EstadosLista != EstadosLista.Agregado)
            {
                value.EstadosLista = EstadosLista.Modificado;
            }

            if (pIndice < base.Items.Count)
            {
                base.Items[pIndice] = value;
            }
            else
            {
                base.SetItem(pIndice, value);
            }

            cambiosSinGuardar = true;
        }

        public ObjetoLista<T> get_ItemsVisibles(bool pMantenerIndicesOriginales = true)
        {
            var lista = new ObjetoLista<T>(this.tipoAgregacion);

            foreach (var objeto in this)
            {
                int mIndiceOriginal = objeto.IndiceLista;
                if (objeto.EstadosLista != EstadosLista.Quitado && objeto.EstadosLista != EstadosLista.Eliminado)
                {
                    lista.Add(objeto);
                }

                if (pMantenerIndicesOriginales)
                {
                    objeto.IndiceLista = mIndiceOriginal;
                }
            }

            return lista;
        }

        protected int AgregarElementoSinCambio(T pObjeto)
        {
            pObjeto.EstadosLista = EstadosLista.SinCambios;
            this.Add(pObjeto);

            return pObjeto.IndiceLista;
        }

        public void Limpiar()
        {
            this.Limpiar();
        }

        public void AceptarCambios()
        {
            bool reacomodar = false;

            lock (new object())
            {
                int eliminados = 0;
                for (int i = 0; i <= base.Count; i++)
                {
                    switch (((T)this.GetItem(i - eliminados)).EstadosLista)
                    {
                        case EstadosLista.Agregado:
                        case EstadosLista.Modificado:
                            {
                                ((T)this.GetItem(i - eliminados)).EstadosLista = EstadosLista.SinCambios;
                                break;
                            }

                        case EstadosLista.Eliminado:
                        case EstadosLista.Quitado:
                            {
                                this.RemoveAt(i - eliminados);
                                eliminados ++;
                                reacomodar = true;
                                break;
                            }
                    }
                }
            }
            if (reacomodar)
                this.ReacomodarIndices();
        }

        private void ReacomodarIndices()
        {
            foreach (var objeto in this.Items)
                objeto.IndiceLista = this.Items.IndexOf(objeto);
        }

        public DataSet ObtenerDataSet()
        {
            if (!this.coleccionCargada)
                this.Cargar();

            // Dataset que se devolverá
            DataSet mDs = new DataSet();

            // Se le carga el DataTable del DTO del objeto
            DataSet mDsEB = ((ObjetoSimple)Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance, null, new object[] { }, null)).ObtenerDataSet();

            mDs.Tables.Add(mDsEB.Tables[0].Clone());

            if (mDsEB.Tables.Count > 0)
            {
                for (int x = 1; x <= mDsEB.Tables.Count - 1; x++)
                {
                    foreach (DataColumn mDC in mDsEB.Tables[x].Columns)
                    {
                        if (!mDs.Tables[0].Columns.Contains(mDC.ColumnName))
                            mDs.Tables[0].Columns.Add(mDC.ColumnName, mDC.DataType);
                    }
                }
            }

            mDs.Tables[0].Columns.Add("IndiceLista", typeof(int));

            foreach (ObjetoSimple pObjeto in this.Items)
            {
                if (pObjeto.EstadosLista != EstadosLista.Eliminado && pObjeto.EstadosLista != EstadosLista.Quitado)
                {
                    DataRow mDr2 = mDs.Tables[0].NewRow();

                    // Dim mDr As DataRow
                    // If pObjeto.ObtenerDataSet.Copy.Tables(0).Rows.Count <= 0 Then
                    // mDr = pObjeto.ObtenerDataSet.Copy.Tables(0).NewRow
                    // Else
                    // mDr = pObjeto.ObtenerDataSet.Copy.Tables(0).Rows(0)
                    // End If
                    DataRow mDr;

                    for (int y = 0; y <= mDsEB.Tables.Count - 1; y++)
                    {
                        mDr = pObjeto.ObtenerDataSet().Copy().Tables[y].Rows[0];

                        for (int x = 0; x <= mDr.Table.Columns.Count - 1; x++)
                            mDr2[mDr.Table.Columns[x].ColumnName] = mDr[mDr.Table.Columns[x].ColumnName];
                    }


                    mDr2["IndiceLista"] = pObjeto.IndiceLista;
                    mDs.Tables[0].Rows.Add(mDr2);
                }
            }
            return mDs;
        }

        public new int Count
        {
            get
            {
                var x = 0;

                foreach (var objeto in this.Items)
                {
                    if (objeto.EstadosLista != EstadosLista.Eliminado && objeto.EstadosLista != EstadosLista.Quitado)
                        x ++;
                }
                return x;
            }
        }

        private void DispararRequerimientoLazyLoad()
        {
            RequerimientoCarga?.Invoke();
        }

        public void Persistir()
        {
            switch (tipoAgregacion)
            {
                case TipoAgregacion.UnoAMuchos:
                    {
                        for (int i = 0; i < base.Count; i++)
                        {
                            var entidad = this.GetItem(i);

                            switch (entidad.EstadosLista)
                            {
                                case EstadosLista.Agregado:
                                case EstadosLista.Modificado:
                                {
                                    AsignarRelacionUnoAMuchos?.Invoke(ref entidad);
                                    entidad.Guardar();

                                    RelacionGuardada?.Invoke(ref entidad);
                                    break;
                                }

                                case EstadosLista.Eliminado:
                                {
                                    entidad.Eliminar();

                                    RelacionEliminada?.Invoke(ref entidad);
                                    break;
                                }
                            }
                        }

                        this.AceptarCambios();
                        break;
                    }

                case TipoAgregacion.MuchosAMuchos:
                    {
                        for (int i = 0; i < base.Count; i++)
                        {
                            var entidad = this.GetItem(i);

                            switch (entidad.EstadosLista)
                            {
                                case EstadosLista.Agregado:
                                {
                                    InsertarRelacionMuchosAMuchos?.Invoke(ref entidad);
                                    break;
                                }

                                case EstadosLista.Eliminado:
                                {
                                    EliminarRelacionMuchosAMuchos?.Invoke(ref entidad);
                                    break;
                                }
                            }
                        }

                        this.AceptarCambios();
                        break;
                    }
            }
        }

    }

}
