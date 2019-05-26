﻿using System;
using System.Collections.Generic;
using System.Net;
using ExampleServices;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Core;
using NotFoundResult = ServiceLayer.Core.NotFoundResult;

namespace ExampleAspNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return this.FromServiceResult<string>(new SuccessResult<string>(""));
            //return this.FromServiceResult(new NotFoundResult());

            //return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return this.FromServiceResult(new FileStorageService<Entity>("TestData.txt").Add(null));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
