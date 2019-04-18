using BestRadisInTheWorld.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestRadisInTheWorld.Models
{
    public class RedisConnect
    {
        private readonly string Host = "localhost";
        private readonly string Port = "6379";

        private ConnectionMultiplexer redis {get;set;}
        private IDatabase Database { get; set; }
        public RedisConnect()
        {
            redis = ConnectionMultiplexer.Connect(String.Format("{0}:{1}", Host, Port));
            Database = redis.GetDatabase(1);

        }
        /// <summary>
        /// Permet d'ajouter une Note dans Redis
        /// </summary>
        /// <param name="note">Note</param>
        /// <returns>Retourne l'identifiant de la note</returns>
        public string AddNote(Note MyNote)
        {
            string JsonParse = JsonConvert.SerializeObject(MyNote);

            Guid Identifiant = Guid.NewGuid();
            Database.StringSet(Identifiant.ToString(),JsonParse);
            return Identifiant.ToString();
        }

        /// <summary>
        /// Récupère les clés sur le serveur, puis ajoute les clés et valeurs dans les datas
        /// </summary>
        /// <returns></returns>

        public List<Data> GetAll()
        {
            IEnumerable<RedisKey> MesKey = redis.GetServer(String.Format("{0}:{1}", Host, Port)).Keys(1);

            List<Data> MesData = new List<Data>();
            foreach(RedisKey Key in MesKey)
            {
                MesData.Add(new Data()
                {
                    Key = Key.ToString(),
                    Value = JsonConvert.DeserializeObject<Note>(Database.StringGet(Key))
                });
            }

            return MesData;
        }
        public Data GetOne(String key)
        {
            return new Data()
            {
                Key = key,
                Value = JsonConvert.DeserializeObject<Note>(Database.StringGet(key))
            };
        }

        public bool DeleteOne(String Key) => Database.KeyDelete(Key);
        

    }
}