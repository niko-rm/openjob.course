using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenJob.Course.Web.Models;

namespace OpenJob.Course.Web.Controllers
{
    public class JsonController
    {
        private List<Json> GetStudenti()
        {
            var usersList = new List<Json>
            {
                new Json
                {
                    Id = 1,
                    NomeStudente = "Francesco",
                    CognomeStudente = "Simeoni"
                },
                new Json
                {
                    Id = 2,
                    NomeStudente = "Michele",
                    CognomeStudente = "Giulietti"
                },
                new Json
                {
                    Id = 1,
                    NomeStudente = "Simone",
                    CognomeStudente = "Prova"
                }
            };

            return GetStudenti();
        }
    }
}