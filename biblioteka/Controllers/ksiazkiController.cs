using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using zbiorksiazek;

namespace biblioteka.Controllers
{
    public class ksiazkiController : ApiController
    {
        [AllowAnonymous]
        public IEnumerable<ksiazka> Get()
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                return encje.ksiazka.ToList();
            }
        }
    }
}
