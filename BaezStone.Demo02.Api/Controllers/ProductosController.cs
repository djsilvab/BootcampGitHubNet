using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Data;
using BaezStone.Demo02.Models.Dtos;
using BaezStone.Demo02.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaezStone.Demo02.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProductoDto>> Get()
        {
            return ProductoData
                    .ListaProducto.Select(x => new ProductoDto{
                        FullName = x.FullName,
                        Category = x.Category,
                        Marca = x.Marca,
                        Precio = x.Precio
                    }).ToList();
        }
    }
}