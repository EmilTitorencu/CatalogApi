using CatalogApi.Dtos;
using CatalogApi.Utils;
using Data.AccessLayer;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursuriController : ControllerBase
    {
        private readonly IAccessLayer dal;
        public CursuriController (IAccessLayer dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Add course
        /// </summary>
        [HttpPost()]
        public void AddCurs([FromBody] CursToCreateDto curs) =>
           dal.AddCurs(curs.ToEntity());


        [HttpGet()]
        public List<Curs> GetAll() =>
           dal.GetAllCursuri();
    }
}
