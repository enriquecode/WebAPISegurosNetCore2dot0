using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPISegurosNetCore2dot0.Models;

namespace WebAPISegurosNetCore2dot0.RepositoryCatalogos
{
    public interface ICatalogosRepository
    {
        Task<List<Marca>> ObtenerMarcas();

        Task<List<SubMarca>> ObtenerSubMarcas(int IdMarca);

        Task<List<Modelo>> ObtenerModelos(int IdSubMarca);

        Task<List<Descripcion>> ObtenerDescripciones(int IdModelo);
    }
}
