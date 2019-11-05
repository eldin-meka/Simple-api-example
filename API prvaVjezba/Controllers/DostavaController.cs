using API_prvaVjezba.Models;
using API_prvaVjezba.Processors;
using API_prvaVjezba.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_prvaVjezba.Controllers
{
    public class DostavaController : ApiController
    {
        [HttpGet]
        [Route("GetAllData")]
        public DataTable Get()
        {
            return DostavaRepository.ReturnFromDB();
        }

        [HttpGet]
        [Route("GetByID")]
        public DataTable Get(int id)
        {
            return DostavaRepository.ReturnFromDB(id);
        }

        [Route("dodajNarudzbu")]
        [HttpPost]
        public bool Post(Narudzba narudzba)
        {
            if(narudzba == null)
            {
                return false;
            }
            return DostavaProcessor.Process(narudzba);
        }

        [HttpPut]
        [Route("UpdateRecord")]
        public bool Put(int id,Narudzba narudzba)
        {
            if (narudzba == null)
                return false;
            return DostavaProcessor.Process(id, narudzba);
        }

        [HttpDelete]
        [Route("DeleteByID")]
        public bool Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }

            DostavaProcessor.Process(id);
            return true;
        }
    }
}
