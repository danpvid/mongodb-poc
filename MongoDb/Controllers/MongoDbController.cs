using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDb.Interfaces;
using MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoDbController : ControllerBase
    {
        private readonly ILogger<MongoDbController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public MongoDbController(ILogger<MongoDbController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoRepository.GetAll());
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _produtoRepository.GetById(id));
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _produtoRepository.Remove(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Produto input)
        {
            await _produtoRepository.Add(input);
            return Ok(input.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Produto input)
        {
            await _produtoRepository.Update(input);
            return Ok();
        }
    }
}
