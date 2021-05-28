using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo2Api.Model;
using Demo2Api.Model.Entidades;

namespace Demo2Api.Interfaces
{
    public interface IData
    {

        IEnumerable<DTORegistrados> ListRegistrado { get; }

        IEnumerable<DTORegistrados> DatosRegistrado(string Identificacion);

        IEnumerable<DTORegistrados> InsertRegistrado1(Registrado NewItem);

    }
}
