using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo1Api.Models;
using Demo1Api.Entidades;
using Demo1Api.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Demo1Api.Services
{
    public class DataRepository : IData
    {
        public IEnumerable<Registrado> ListRegistrado
        {
            get { return CargaRegistrados(); }
        }

        public IEnumerable<DTORegistrados> DatosRegistradosEmpresas
        {
            get { return DatosRegistradosEmpresas2(); }
        }

        public IEnumerable<Registrado> DatosRegistrado(string Identificacion)
        {
            return CargaDatosByIdentificacion(Identificacion);
        }


        //Acceso a datos

        public List<Registrado> CargaRegistrados()
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.ToList();
            }
        }

        //Devolver registro por parametro de entrada
        public List<Registrado> CargaDatosByIdentificacion(string identificacion)
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a => a.Identificacion == identificacion).ToList();
            }
        }

        public List<DTORegistrados> DatosRegistradosEmpresas2()
        {
            using (var ctx = new DBRegistradosContext())
            {
                var x = (

                        from a in ctx.Registrados
                        join b in ctx.EmpresaRegistrados
                        on a.IdRegistrado equals b.IdRegistrado
                        join c in ctx.Empresas
                        on b.IdEmpresa equals c.IdEmpresa
                        where b.Estado == "ACTIVO"
                        orderby b.IdEmpresaRegistrado descending

                        select new DTORegistrados()
                        {
                            IdRegistrado = a.IdRegistrado,
                            Identificacion = a.Identificacion
                            //NombresCompletos = a.NombresCompletos,
                            //NombresEmpresa = c.NombrEmpresa,
                            //EstadoRelacionEmpresa = b.Estado
                        }

                    ).ToList();
                return x;
            }
        }

        public void InsertRegistrado(Registrado NewItem)
        {
            using (var context = new DBRegistradosContext())
            {
                context.Registrados.Add(NewItem);
                context.SaveChanges();
            }
        }

        public List<Registrado> ItemExists(int IdRegistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(z => z.IdRegistrado == IdRegistrado).ToList();
            }

        }


        public void UpdateRegistrado(Registrado Item)
        {
            using (var context = new DBRegistradosContext())
            {
                var transac = context.Database.BeginTransaction();

                try
                {

                    var registro = context.Registrados
                        .Where(a => a.IdRegistrado == Item.IdRegistrado)
                        .ToList();

                    if (registro.Count > 0)
                    {
                        foreach (Registrado reg in registro)
                        {
                            reg.Apellidos = Item.Apellidos;
                            reg.Nombres = Item.Nombres;
                            reg.NombresCompletos = Item.NombresCompletos;
                            reg.Identificacion = Item.Identificacion;

                            context.SaveChanges();
                            transac.Commit();
                        }
                    }

                }
                catch (Exception)
                {
                    transac.Rollback();
                }

            }

        }

        public void DeleteRegistrado(int IdRegistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                var Registro = context.Registrados
                    .Where(a => a.IdRegistrado == IdRegistrado)
                    .FirstOrDefault();

                if (Registro != null)
                {
                    context.Registrados.Remove(Registro);
                    context.SaveChanges();
                }

            }
        }

        //Stored procedures

        //public async List<DTORegistrados> DatosRegistradosSP()
        //{
        //    using (var context = new DBRegistradosContext())
        //    {
        //        return await context.Registrados
        //            .FromSqlRaw<DTORegistrados>("");
        //    }

        //}


    }
}
