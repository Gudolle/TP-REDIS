using BestRadisInTheWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace BestRadisInTheWorld.Controllers
{
    public class NoteController : ApiController
    {
        private RedisConnect Redis { get; }
        public NoteController() => Redis = new RedisConnect();

        [HttpGet]
        public List<Data> NoteGet() => Redis.GetAll();

        [HttpGet]
        [Route("Note/{key}")]
        public Data NoteGetId(string Key) => Redis.GetOne(Key);

        [HttpPost]
        public object Note(string note, string Auteur) => Redis.AddNote(new Note(Auteur, note));

        [HttpDelete]
        public bool NoteRemove(string key) => Redis.DeleteOne(key);
    }
}
