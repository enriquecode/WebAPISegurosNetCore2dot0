using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPISegurosNetCore2dot0.Models;
using WebAPISegurosNetCore2dot0.RepositoryCatalogos;

namespace WebAPISegurosNetCore2dot0.Controllers
{
    [Produces("application/json")]
    [Route("api/Seguros/Catalogos")]
    public class CatalogosController : Controller
    {
        ICatalogosRepository catalogosRepository;
        public CatalogosController(ICatalogosRepository _postRepository)
        {
            catalogosRepository = _postRepository;
        }

        [HttpGet]
        [Route("ObtenerMarcas")]
        public async Task<IActionResult> ObtenerMarcas()
        {
            try
            {
                var marcas = await catalogosRepository.ObtenerMarcas();
                if (marcas == null)
                {
                    return NotFound();
                }

                return Ok(marcas);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("ObtenerSubMarcas")]
        public async Task<IActionResult> ObtenerSubMarcas(int MarcaId)
        {
            try
            {
                var subMarcas = await catalogosRepository.ObtenerSubMarcas(MarcaId);
                if (subMarcas == null)
                {
                    return NotFound();
                }

                return Ok(subMarcas);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("ObtenerModelos")]
        public async Task<IActionResult> ObtenerModelos(int SubMarcaId)
        {
            try
            {
                var modelos = await catalogosRepository.ObtenerModelos(SubMarcaId);
                if (modelos == null)
                {
                    return NotFound();
                }

                return Ok(modelos);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("ObtenerDescripciones")]
        public async Task<IActionResult> ObtenerDescripciones(int ModeloId)
        {
            try
            {
                var descripciones = await catalogosRepository.ObtenerDescripciones(ModeloId);
                if (descripciones == null)
                {
                    return NotFound();
                }

                return Ok(descripciones);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("ObtenerUbicacionesGeograficas")]
        public async Task<IActionResult> ObtenerUbicacionesGeograficas(string CodigoPostalNumero)
        {
            try
            {
                var ubicacionGeograficas = await catalogosRepository.ObtenerUbicacionesGeograficas(CodigoPostalNumero);
                if (ubicacionGeograficas == null)
                {
                    return NotFound();
                }

                return Ok(ubicacionGeograficas);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}