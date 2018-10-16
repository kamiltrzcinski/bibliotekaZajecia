using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using zbiorksiazek;
using System.Web.Http.Cors;

namespace biblioteka.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class ksiazkiController : ApiController
    {
 
        public IEnumerable<ksiazka> Get()
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                return encje.ksiazka.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                var pozycja = encje.ksiazka.FirstOrDefault(e => e.id == id);
                if(pozycja!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pozycja);
                }
                
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Książka o numerze " + id.ToString() + " nie istnieje.");
                
            }
        }

        public HttpResponseMessage Post([FromBody] ksiazka pozycja)
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                encje.ksiazka.Add(pozycja);
                encje.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                var pozycja = encje.ksiazka.FirstOrDefault(e => e.id == id);
                if (pozycja != null)
                {
                    encje.ksiazka.Remove(pozycja);
                    encje.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, pozycja);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Książka o numerze " + id.ToString() + " nie istnieje.");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] ksiazka pozycja)
        {
            using (bibliotekaEntities encje = new bibliotekaEntities())
            {
                var stara = encje.ksiazka.FirstOrDefault(e => e.id == id);
                if (stara != null)
                {
                    stara.autor = pozycja.autor;
                    stara.tytul = pozycja.tytul;
                    stara.rok_wydania = pozycja.rok_wydania;
                    encje.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, pozycja);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Książka o numerze " + id.ToString() + " nie istnieje.");
            }
        }
    }
}
