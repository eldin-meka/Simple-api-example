using API_prvaVjezba.Models;
using API_prvaVjezba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_prvaVjezba.Processors
{
    public class DostavaProcessor
    {
        public static bool Process(Narudzba narudzba)
        {
            //procesiranje

           return DostavaRepository.AddToDatabase(narudzba);
        }

        public static bool Process(int id)
        {
            //procesiranje

            return DostavaRepository.DeleteRecord(id);
        }

        public static bool Process(int id, Narudzba narudzba)
        {
            //procesiranje
            return DostavaRepository.UpdateRecord(id, narudzba);
        }
    }
}