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

        private TipoAgregacion tipoAgregacion = TipoAgregacion.UnoAMuchos;

        public ObjetoLista(TipoAgregacion pTipoAgregacion)
        {
            tipoAgregacion = pTipoAgregacion;
        }

        public void Cargar(bool pExceptoQueEsteCargada = false)
        {
            if (!coleccionCargada | !pExceptoQueEsteCargada)
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
                    AgregarElementoSinCambio((T)Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance, null, new object[] { pDr }, null));

                coleccionCargada = true;
            }
        }

        protected override int GetKeyForItem(T item)
        {
            item.IndiceLista = Items.Count;
            return item.IndiceLista;
        }

        public virtual int Agregar(T pObjeto)
        {
            pObjeto.EstadosLista = EstadosLista.Agregado;
            cambiosSinGuardar = true;

            Add(pObjeto);
            ElementoAgregado?.Invoke(ref pObjeto);

            pObjeto.RequerimientoLazyLoad += DispararRequerimientoLazyLoad;
            return pObjeto.IndiceLista;
        }

        public virtual void Eliminar(T pObjeto)
        {
            int indice;
            //if (pObjeto.IndiceLista == null)
            indice = IndexOf(pObjeto);
            //else
            //    indice = pObjeto.IndiceLista;

            Eliminar(indice);
        }

        public virtual void Eliminar(int pIndice)
        {
            if (GetItem(pIndice).EstadosLista == EstadosLista.Agregado)
                GetItem(pIndice).EstadosLista = EstadosLista.Quitado;
            else
                GetItem(pIndice).EstadosLista = EstadosLista.Eliminado;

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

        public T GetItem(int pIndice)
        {
            return Items[pIndice];
        }

        protected override void SetItem(int pIndice, T value)
        {
            if (GetItem(pIndice).EstadosLista != EstadosLista.Agregado)
            {
                value.EstadosLista = EstadosLista.Modificado;
            }

            if (pIndice < Items.Count)
            {
                Items[pIndice] = value;
            }
            else
            {
                base.SetItem(pIndice, value);
            }

            cambiosSinGuardar = true;
        }

        public ObjetoLista<T> get_ItemsVisibles(bool pMantenerIndicesOriginales = true)
        {
            var lista = new ObjetoLista<T>(tipoAgregacion);

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
            Add(pObjeto);

            return pObjeto.IndiceLista;
        }

        public void Limpiar()
        {
            Limpiar();
        }

        public void AceptarCambios()
        {
            bool reacomodar = false;

            lock (new object())
            {
                int eliminados = 0;
                for (int i = 0; i <= Count - 1; i++)
                {
                    switch (((T)GetItem(i - eliminados)).EstadosLista)
                    {
                        case EstadosLista.Agregado:
                        case EstadosLista.Modificado:
                            {
                                ((T)GetItem(i - eliminados)).EstadosLista = EstadosLista.SinCambios;
                                break;
                            }

                        case EstadosLista.Eliminado:
                        case EstadosLista.Quitado:
                            {
                                RemoveAt(i - eliminados);
                                eliminados++;
                                reacomodar = true;
                                break;
                            }
                    }
                }
            }
            if (reacomodar)
                ReacomodarIndices();
        }

        private void ReacomodarIndices()
        {
            foreach (var objeto in Items)
                objeto.IndiceLista = Items.IndexOf(objeto);
        }

        public DataSet ObtenerDataSet()
        {
            if (!coleccionCargada)
                Cargar();

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

            foreach (ObjetoSimple pObjeto in Items)
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

                foreach (var objeto in Items)
                {
                    if (objeto.EstadosLista != EstadosLista.Eliminado && objeto.EstadosLista != EstadosLista.Quitado)
                        x++;
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
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            var entidad = GetItem(i);

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

                        AceptarCambios();
                        break;
                    }

                case TipoAgregacion.MuchosAMuchos:
                    {
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            var entidad = GetItem(i);

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

                        AceptarCambios();
                        break;
                    }
            }
        }

    }

}
