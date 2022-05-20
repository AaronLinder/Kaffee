using Microsoft.AspNetCore.Mvc;

namespace Caffee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeeController : ControllerBase
    {
        public static Kaffee kaffee = new(0.8, 1.2, 0);


        private readonly ILogger<KaffeeController> _logger;

        public KaffeeController(ILogger<KaffeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/getKaffe")]
        public Kaffee getKaffee()
        {
            return kaffee;
        }

        [HttpPost]
        [Route("/wasserAuffuellen")]
        public string wasserAuffuellen(double menge)
        {
        return "Es war " + kaffee.Wasser + "kg Wasser in der Kaffeemaschiene, jetzt sind " + Kaffee.wasserAuffuellen(menge) + "kg Wasser in der Kaffemaschiene";
        }

        [HttpPost]
        [Route("/bohnenAuffuellen")]
        public string bohnenAuffuellen(double menge)
        {
            return "Es waren " + kaffee.Kaffeebohnen + "kg Kaffeebohnen in der Kaffeemaschiene, jetzt sind " + Kaffee.bohnenAuffuellen(menge) + " kg Kaffeebohnen in der Kaffemaschiene";
        }

        [HttpPost]
        [Route("/machKaffee")]
        public string macheKaffee(double menge, double verhaeltnisWasserBohnen)
        {
            if( Kaffee.macheKaffee(menge,verhaeltnisWasserBohnen) == true)
            {
                return "Kaffee wurde gemacht";
            }
            return "Kaffe wurde nicht gemacht";
        }
    }
}