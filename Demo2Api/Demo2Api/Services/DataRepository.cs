using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Demo2Api.Interfaces;
using Demo2Api.Model;
using Demo2Api.Model.Entidades;


namespace Demo2Api.Services
{
    public class DataRepository : IData
    {
        public IEnumerable<DTORegistrados> ListRegistrado
        {
            get { return CargaRegistrados(); }
        }

        public IEnumerable<DTORegistrados> DatosRegistrado(string Identificacion)
        {
            return CargaDatosByIdentificacion(Identificacion);
        }

        public IEnumerable<DTORegistrados> InsertRegistrado1(Registrado NewItem)
        {
            return Insert1(NewItem);
        }


        public List<DTORegistrados> CargaRegistrados()
        {
            using (var context = new DataContext())
            {
                return context.DTORegister.FromSqlRaw("ConsRegistrados")
                .ToList();
            }
        }

       
        public List<DTORegistrados> CargaDatosByIdentificacion(string identificacion)
        {
            using (var context = new DataContext())
            {
                return context.DTORegister.FromSqlRaw("ConsRegistradoByIdentificacion {0}", identificacion)
                .ToList();
            }
        }

        public List<DTORegistrados> CargaDatosByIdentificacionId(string Id, string identificacion)
        {
            using (var context = new DataContext())
            {
                return context.DTORegister.FromSqlRaw("ConsRegistradoByIdentificacion {0},{1}", Id, identificacion)
                .ToList();
            }
        }

        public List<DTORegistrados> Insert1(Registrado NewItem)
        {
            using (var context = new DataContext())
            {
               
                return context.DTORegister.FromSqlRaw("InsRegistrados {0},{1},{2}"
                    , NewItem.Identificacion
                    , NewItem.Nombres
                    , NewItem.Apellidos)
                    .ToList();

            }
        }

        public List<DTORegistrados> Insert2(Registrado NewItem)
        {
            using (var context = new DataContext())
            {

                return context.DTORegister.FromSqlRaw("InsRegistrados {0},{1},{2}"
                    , NewItem.Identificacion
                    , NewItem.Nombres
                    , NewItem.Apellidos)
                    .ToList();

            }
        }

    }
}
