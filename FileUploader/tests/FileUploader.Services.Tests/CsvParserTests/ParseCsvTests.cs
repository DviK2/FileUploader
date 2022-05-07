using FileUploader.Services.Tests.Utils;
using Xunit;
using Xunit.Abstractions;

namespace FileUploader.Services.Tests.CsvParserTests;

public class ParseCsvTests
{
    private readonly ITestOutputHelper _console;
    private readonly CsvParser _parser;

    public ParseCsvTests(ITestOutputHelper console)
    {
        _console = console;
        _parser = new CsvParser();
    }

    [Fact]
    public void ParseFileStructure()
    {
        // assert
        var path = "files/example.csv";
        var stream = FileManager.Load(path);

        // act
        var result = _parser.ParseCsv(stream);

        // assert
        foreach (var structure in result)
            _console.WriteLine($"Id: {structure.Id}\t Name: {structure.Name}");
    }
}