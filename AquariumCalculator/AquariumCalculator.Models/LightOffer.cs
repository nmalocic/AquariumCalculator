using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumCalculator.Models
{
  public class LightOffer
  {
    public LightOffer(int numberOfLigts, Light model)
    {
      Number = numberOfLigts;
      Model = model;
    }

    public int Number { get; }
    public Light Model { get; }
  }
}
