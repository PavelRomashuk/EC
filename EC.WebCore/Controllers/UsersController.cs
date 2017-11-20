﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EC.Models;
using EC.Contracts;
using Microsoft.AspNetCore.Cors;

namespace EC.WebCore.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    public class UsersController : Controller
    {
        protected IAccountContract _accountContract;
        public UsersController(IAccountContract accountContract)
        {
            _accountContract = accountContract;
        }

        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            return _accountContract.GetAllUSers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
