using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Data.Context;
using BaezStone.Demo02.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaezStone.Demo02.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetAll()
            => await context.Libros
                            .Include(x => x.Categoria)
                                .ToListAsync();
    }
}