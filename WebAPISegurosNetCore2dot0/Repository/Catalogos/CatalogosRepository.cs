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

        public async Task<List<SubMarca>> ObtenerSubMarcas(int MarcaId)
        {
            if (db != null)
            {
                return await db.SubMarca.Where(x => x.MarcaId == MarcaId).ToListAsync();
            }

            return null;
        }

        public async Task<List<Modelo>> ObtenerModelos(int SubMarcaId)
        {
            if (db != null)
            {
                return await db.Modelo.Where(x => x.SubMarcaId == SubMarcaId).ToListAsync();
            }

            return null;
        }

        public async Task<List<Descripcion>> ObtenerDescripciones(int ModeloId)
        {
            if (db != null)
            {
                return await db.Descripcion.Where(x => x.ModeloId == ModeloId).ToListAsync();
            }

            return null;
        }

        public async Task<List<UbicacionGeografica>> ObtenerUbicacionesGeograficas(string CodigoPostalNumero)
        {
            if (db != null)
            {
                List<UbicacionGeografica> listaUbicacionesGeograficas = new List<UbicacionGeografica>();

                var ubicacionesGeograficas = await db.CodigoPostal
            .Join(
                db.Colonia,
                codigoPostal => codigoPostal.CodigoPostalId,
                colonia => colonia.CodigoPostalId,
                (codigoPostal, colonia) => new { codigoPostal.MunicipioId, codigoPostal.CodigoPostalId, codigoPostal.CodigoPostalNumero, colonia.ColoniaNombre }
            )
            .Join(
                db.Municipio,
                codigoPostalEntrante => codigoPostalEntrante.MunicipioId,
                municipio => municipio.MunicipioId,
                (codigoPostalEntrante, municipio) => new
                {
                    municipio.EntidadId,
                    municipio.MunicipioNombre,
                    codigoPostalEntrante.CodigoPostalNumero,
                    codigoPostalEntrante.ColoniaNombre
                }
            )
            .Join(
                db.Entidad,
                municipioEntrante => municipioEntrante.EntidadId,
                entidad => entidad.EntidadId,
                (municipioEntrante, entidad) => new
                {
                    entidad.EntidadNombre,
                    municipioEntrante.MunicipioNombre,
                    municipioEntrante.CodigoPostalNumero,
                    municipioEntrante.ColoniaNombre
                }
            )

            .Where(r => r.CodigoPostalNumero == CodigoPostalNumero)
            .Select(r => new
            {
                EntidadNombre = r.EntidadNombre,
                MunicipioNombre = r.MunicipioNombre,
                CodigoPostalNumero = r.CodigoPostalNumero,
                ColoniaNombre = r.ColoniaNombre
            })
            .ToListAsync();

                foreach (var ubicacionGeografica in ubicacionesGeograficas)
                {
                    listaUbicacionesGeograficas.Add(new UbicacionGeografica { EntidadNombre = ubicacionGeografica.EntidadNombre, MunicipioNombre = ubicacionGeografica.MunicipioNombre, CodigoPostalNumero = ubicacionGeografica.CodigoPostalNumero, ColoniaNombre = ubicacionGeografica.ColoniaNombre });
                }

                return listaUbicacionesGeograficas;
            }

            return null;
        }
    }
}
