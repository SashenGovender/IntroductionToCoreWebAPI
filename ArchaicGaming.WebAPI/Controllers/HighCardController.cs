﻿using System.Collections.Generic;
using BlackjackLib;
using Microsoft.AspNetCore.Mvc;

namespace ArchaicGaming.WebAPI.Controllers
{
    // [Route("api/[controller]/[action]/{id?}")]
    [Route("api/[controller]")]
    [ApiController]
    public class HighCardController : ControllerBase
    {
       // private HighCard highCardGame;
        public HighCardController()
        {
       //     highCardGame = new HighCard();
        }

        //[Route("api/Play/Deal/{userID:int}/{age:int}")]
        // public Card Deal(int userID, int age)


        //[HttpGet]
        //[Route("Deal")]
        ////[ResponseType(typeof(Card))]
        //public ActionResult<Card> Deal()
        //{
        //    Card card = null;//highCardGame.Deal();
        //    //return 5;
        //    return card;
        //}

        //// GET api/play

        //[HttpGet]
        ////[Route("api/play")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/play/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/play
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/play/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/play/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
