using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace DocumentDB
{
    class Program
    {
        private static string endpoint = "https://menudb.documents.azure.com:443/";
        private static string authKey = "Ak8tRCnSdAbdXPK8W7BlT9FHSGDM2RFRO4mZpJKzLosEX39mogaz2YNarmVYEFcqG6mXqQRK8P9aoD5+sRywyg==";

        static void Main(string[] args)
        {
            using (var client = new DocumentClient(new Uri(endpoint), authKey))
            {
                var database = new Database { Id = "MenuDemoDB" };
                database = client.CreateDatabaseAsync(database).Result;

                var collection = new DocumentCollection { Id = "Menus" };
                collection = client.CreateDocumentCollectionAsync(database.SelfLink, collection).Result;

                //DocumentDB supports strongly typed POCO objects and also dynamic objects
                dynamic menujson = JsonConvert.DeserializeObject(File.ReadAllText("13140.json"));

                //persist the documents in DocumentDB
                client.CreateDocumentAsync(collection.SelfLink, menujson);


                //very simple query returning the full JSON document matching a simple WHERE clause
                var query = client.CreateDocumentQuery(collection.SelfLink, "SELECT * FROM m in Menus.menus");
                var family = query.AsEnumerable().FirstOrDefault();

                Console.WriteLine("The Anderson family have the following pets:");
                foreach (var pet in family.pets)
                {
                    Console.WriteLine(pet.givenName);
                }

                ////select JUST the child record out of the Family record where the child's gender is male
                //query = client.CreateDocumentQuery(collection.DocumentsLink, "SELECT * FROM c IN Families.children WHERE c.gender='male'");
                //var child = query.AsEnumerable().FirstOrDefault();

                //Console.WriteLine("The Andersons have a son named {0} in grade {1} ", child.firstName, child.grade);

                //cleanup test database
                client.DeleteDatabaseAsync(database.SelfLink);
            }
        }

        
    }
}
