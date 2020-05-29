using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly DataContext _context;

        public ValueController(DataContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values=await _context.values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetValues(int id)
        {
            var values=await _context.values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(values);
        }

    }
}