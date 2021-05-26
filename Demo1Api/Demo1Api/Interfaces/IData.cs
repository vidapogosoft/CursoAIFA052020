using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo1Api.Models;
using Demo1Api.Entidades;

namespace Demo1Api.Interfaces
{
    public interface IData
    {

        IEnumerable<Registrado> ListRegistrado { get; }

        IEnumerable<Registrado> DatosRegistrado(string Identificacion);

        IEnumerable<DTORegistrados> DatosRegistradosEmpresas { get; }

        void InsertRegistrado(Registrado NewItem);

        void UpdateRegistrado(Registrado Item);

        void DeleteRegistrado(int IdRegistrado);

        List<Registrado> ItemExists(int IdRegistrado);
    }
}
