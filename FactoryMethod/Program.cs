namespace FactoryMethod;

interface Database
{
    // Do stuff
    public string ReadRecord();
    public string WriteRecord();
}

class MySQL : Database
{
    public MySQL() { }
    public string ReadRecord() {return "SELECT * FROM ...";}
    public string WriteRecord() {return "INSERT INTO ...";}
}

class MongoDB : Database
{
    public MongoDB() { }
    public string ReadRecord() {return "find bla bla";}
    public string WriteRecord() {return "insertOne bla bla";}
}
class Factory
{
    public Database CreateProduct(string typ)
    {
        if (typ == "NoSQL") { return new MongoDB(); }
        else { return new MySQL(); }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Factory tovarnickaNaDB = new Factory();
        Database db = tovarnickaNaDB.CreateProduct("SQL");
        Console.WriteLine(db.ReadRecord());
    }
}
