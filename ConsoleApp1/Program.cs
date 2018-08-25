using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Console.WriteLine("Conectando...");
                Console.Clear();
                 
                MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

                IMongoDatabase database = mongoClient.GetDatabase("crmix");

                var collection = database.GetCollection<BsonDocument>("clientes");                 
                
                //contar documentos de la collection
                //Console.WriteLine(collection.CountDocuments(new BsonDocument()));

                //consultar datos de la collection
                var documents = collection.Find(new BsonDocument()).ToList();
                

                foreach (var document in documents)
                {
                    
                    Console.WriteLine(document.ToJson() + "\n");
                }
                



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | "+e.StackTrace);
            }
            Console.Read();

        }
    }        
}
