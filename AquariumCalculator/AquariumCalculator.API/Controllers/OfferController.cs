﻿using AquariumCalculator.Contracts;
using AquariumCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquariumCalculator.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OfferController : ControllerBase
  {
    private IAquariumCatalog _aquariumCatalog;

    public OfferController(IAquariumCatalog aquariumCatalog)
    {
      _aquariumCatalog = aquariumCatalog;
    }

    // GET: api/Offer
    [HttpGet]
    public ActionResult Get([FromQuery]AquariumViewModel aquariumViewModel)
    {
      AquariumOffer offer = _aquariumCatalog.GetOfferFor(new Aquarium(aquariumViewModel.Lenght, aquariumViewModel.Width, aquariumViewModel.Height, aquariumViewModel.SafeFactor));
      return Ok(offer);
    }

    // GET: api/Offer/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Offer
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Offer/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
