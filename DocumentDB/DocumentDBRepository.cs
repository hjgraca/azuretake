using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;

namespace DocumentDB
{
    public static class DocumentDBRepository
    {
        private static string _databaseId = "MenuDemoDB";
        private static string _collectionId = "Menus";
        private static string _endpoint = "https://menudb.documents.azure.com:443/";
        private static string _authKey = "Ak8tRCnSdAbdXPK8W7BlT9FHSGDM2RFRO4mZpJKzLosEX39mogaz2YNarmVYEFcqG6mXqQRK8P9aoD5+sRywyg==";

        public static List<dynamic> GetItems()
        {
            var query = Client.CreateDocumentQuery(collection.SelfLink, "SELECT * FROM Menus");
            return query.ToList();
        }


        private static Database database;
        private static Database Database
        {
            get
            {
                if (database == null)
                {
                    ReadOrCreateDatabase().Wait();
                }

                return database;
            }
        }

        private static DocumentCollection collection;
        private static DocumentCollection Collection
        {
            get
            {
                if (collection == null)
                {
                    ReadOrCreateCollection(Database.SelfLink).Wait();
                }

                return collection;
            }
        }

        private static string databaseId;
        private static String DatabaseId
        {
            get
            {
                if (string.IsNullOrEmpty(databaseId))
                {
                    databaseId = _databaseId;
                }

                return databaseId;
            }
        }

        private static string collectionId;
        private static String CollectionId
        {
            get
            {
                if (string.IsNullOrEmpty(collectionId))
                {
                    collectionId = _collectionId;
                }

                return collectionId;
            }
        }

        private static DocumentClient client;
        private static DocumentClient Client
        {
            get
            {
                if (client == null)
                {
                    String endpoint = _endpoint;
                    string authKey = _authKey;
                    Uri endpointUri = new Uri(endpoint);
                    client = new DocumentClient(endpointUri, authKey);
                }

                return client;
            }
        }

        private static async Task ReadOrCreateCollection(string databaseLink)
        {
            var collections = Client.CreateDocumentCollectionQuery(databaseLink)
                              .Where(col => col.Id == CollectionId).ToArray();

            if (collections.Any())
            {
                collection = collections.First();
            }
            else
            {
                collection = await Client.CreateDocumentCollectionAsync(databaseLink,
                    new DocumentCollection { Id = CollectionId });
            }
        }

        private static async Task ReadOrCreateDatabase()
        {
            var databases = Client.CreateDatabaseQuery()
                            .Where(db => db.Id == DatabaseId).ToArray();

            if (databases.Any())
            {
                database = databases.First();
            }
            else
            {
                Database database = new Database { Id = DatabaseId };
                database = await Client.CreateDatabaseAsync(database);
            }
        }
    }
}
