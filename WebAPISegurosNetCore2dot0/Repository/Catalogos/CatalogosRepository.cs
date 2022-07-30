using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebAPISegurosNetCore2dot0.Models;

namespace WebAPISegurosNetCore2dot0.RepositoryCatalogos
{
    public class CatalogosRepository : ICatalogosRepository
    {
        SegurosContext db;
        public CatalogosRepository(SegurosContext _db)
        {
            db = _db;
        }

        public async Task<List<Marca>> ObtenerMarcas()
        {
            if (db != null)
            {
                return await db.Marca.ToListAsync();
            }

            return null;
        }

        public async Task<List<SubMarca>> ObtenerSubMarcas(int IdMarca)
        {
            if (db != null)
            {
                return await db.SubMarca.Where(x => x.IdMarca == IdMarca).ToListAsync();               
            }

            return null;
        }

        public async Task<List<Modelo>> ObtenerModelos(int IdSubMarca)
        {
            if (db != null)
            {
                return await db.Modelo.Where(x => x.IdSubMarca == IdSubMarca).ToListAsync();
            }

            return null;
        }

        public async Task<List<Descripcion>> ObtenerDescripciones(int IdModelo)
        {
            if (db != null)
            {
                return await db.Descripcion.Where(x => x.IdModelo == IdModelo).ToListAsync();
            }

            return null;
        }
    }
}
