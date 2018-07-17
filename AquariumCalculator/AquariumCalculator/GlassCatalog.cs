using System;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculatorTests
{
    internal class GlassCatalog
    {
        private static List<GlassPrice> _catalog = new List<GlassPrice>();

        static GlassCatalog()
        {
            _catalog.Add(new GlassPrice(4, 14));
            _catalog.Add(new GlassPrice(6, 18));
            _catalog.Add(new GlassPrice(8, 25));
            _catalog.Add(new GlassPrice(10, 31));
            _catalog.Add(new GlassPrice(12, 45));
            _catalog.Add(new GlassPrice(15, 100));
            _catalog.Add(new GlassPrice(20, 100));
            _catalog.Add(new GlassPrice(30, 155));
            _catalog.Add(new GlassPrice(40, 215));
            _catalog.Add(new GlassPrice(50, 300));
        }

        public GlassCatalog()
        {

        }

        public GlassCatalog(IEnumerable<GlassPrice> catalog)
        {
            _catalog.AddRange(catalog);
        }

        internal GlassPrice GetPrice(double tickness)
        {
            var clampedTickness = Math.Clamp(tickness, 0d, 50d);

            return _catalog
                  .OrderBy(x => x.Tickness)
                  .Where(item => item.Tickness >= clampedTickness)
                  .Aggregate((min, next) => min.Tickness < next.Tickness ? min : next);
        }
    }
}