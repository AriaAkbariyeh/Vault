using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vault.Core;

namespace Vault.Data
{
    public class MongoPasswordData : IPasswordData
    {
        List<Password> passwords = new List<Password>();
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase ContextDatabase { get; private set; }
        public IMongoCollection<BsonDocument> ContextCollection { get; private set; }
        public object jsonDocument { get; }

        private readonly string _contextDatabase = "Passwords";
        private readonly string _contextColection = "Passwords";


        public MongoPasswordData(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
            ContextDatabase = MongoClient.GetDatabase(_contextDatabase);
            ContextCollection = ContextDatabase.GetCollection<BsonDocument>(_contextColection);
            List<BsonDocument> documents = ContextCollection.Find(new BsonDocument()).ToList();

            if (documents.Count > 0)
            {
                foreach(BsonDocument doc in documents)
                {
                    passwords.Add(BsonSerializer.Deserialize<Password>(doc));
                }
            }
        }

        public Password Add(Password newPassword)
        {
            if(passwords.Count > 0)
            {
                newPassword._id = passwords.Max(p => p._id) + 1;
            }
            else
            {
                newPassword._id = 0;
            }
            passwords.Add(newPassword);
            string json = JsonConvert.SerializeObject(newPassword);
            BsonDocument document = BsonDocument.Parse(json);
            ContextCollection.InsertOne(document);
            return newPassword;
        }

        public int Commit()
        {
            return 0;
        }

        public Password GetPasswordById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Password> GetPasswordByName(string name)
        {
           
            string loweredCaseName = null;
            if (!string.IsNullOrEmpty(name))
            {
                loweredCaseName = name.ToLower();
            }

            return from p in passwords
                   where string.IsNullOrEmpty(loweredCaseName) || p.Name.ToLower().StartsWith(loweredCaseName)
                   orderby p.Name
                   select p;
        }

        public Password Update(Password updatedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
