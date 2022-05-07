using FileHelpers;
using FileUploader.Services.Models;

namespace FileUploader.Services;

public interface ICsvParser
{
    IEnumerable<FileStructure>? ParseCsv(Stream stream);
}

public class CsvParser : ICsvParser
{
    public IEnumerable<FileStructure>? ParseCsv(Stream stream)
    {
        try
        {
            var engine = new FileHelperEngine<FileStructure>();
            var records = engine.ReadStream(new StreamReader(stream));

            return records;
        }
        catch (FileHelpersException e)
        {
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}