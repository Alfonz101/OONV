namespace FactoryMethod;

public interface IConverter
{
    void Convert(string inputFilePath, string outputFilePath);
}

class PdfConverter : IConverter
{
    public void Convert(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine("Converted to PDF");
    }
}

class TxtConverter : IConverter
{
    public void Convert(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine("Converted to .txt");
    }
}

class DocxConverter : IConverter
{
    public void Convert(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine("Converted to Docx");
    }

}

class ConverterFactory
{
    public IConverter CreateProduct(string targetFileFormat)
    {
        switch (targetFileFormat.ToUpper())
        {
            case "PDF":
                return new PdfConverter();
            case "DOCX":
                return new DocxConverter();
            case "TXT":
                return new TxtConverter();

            default:
                Console.WriteLine("Error: unsupported format");
                return null!;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConverterFactory factoryuwu = new ConverterFactory();

        Console.Write("Target format [txt/pdf/docx]: ");
        string? format = Console.ReadLine();

        IConverter converter = factoryuwu.CreateProduct(format);

        if (converter != null)
        {
            converter.Convert("input.txt", "output." + format.ToLower());
        }
    }
}



/* Beranek priklad
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
*/