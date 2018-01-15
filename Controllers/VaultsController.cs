using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultRepository db;
        public VaultsController(VaultRepository vaultRepo)
        {
            db = vaultRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return db.GetAll();
        }
        [HttpGet("user/{id}")]
        public IEnumerable<Vault> GetVaultsByUserId(int id)
        {
            return db.GetVaultsByUserId(id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Vault Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        // [Authorize]
        [HttpPost]
        public Vault Post([FromBody]Vault vault)
        {
            return db.Add(vault);
        }

        // PUT api/values/5
        // [Authorize]
        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, vault);
            }
            return null;
        }

        // DELETE api/values/5
        // [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}