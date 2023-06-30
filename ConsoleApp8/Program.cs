using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

string connectionString = "mongodb://localhost:27017";

var client = new MongoClient(connectionString);


var database = client.GetDatabase("local");
var collection = database.GetCollection<BsonDocument>("books");

Insert();

var filter = Builders<BsonDocument>.Filter.Empty; // Boş bir filtre kullanarak tüm belgeleri çekiyoruz

var documents = collection.Find(filter).ToList();

foreach (var document in documents)
{
    Console.WriteLine(document[1] + " " + document[2]);
}

Console.WriteLine(collection);

Console.ReadLine();


void Insert()
{

    var document = new BsonDocument
    {
        { "title", "sefiller" },
        { "author", "victor hugo" }
    };

    collection.InsertOne(document);
    Console.WriteLine("ekleme gerceklesti...");
}

