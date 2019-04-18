using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestRadisInTheWorld.Models
{
    public class Note
    {
        public string Auteur { get; set; }
        public DateTime DateCreation { get; set; }
        public string Contenu { get; set; }

        public Note(string _auteur, string _contenu)
        {
            Auteur = _auteur;
            Contenu = _contenu;
            DateCreation = DateTime.Now;
        }

    }
}