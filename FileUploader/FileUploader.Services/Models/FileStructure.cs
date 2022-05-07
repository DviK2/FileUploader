using FileHelpers;

namespace FileUploader.Services.Models;

[IgnoreFirst]
[IgnoreEmptyLines]
[DelimitedRecord("|")]
public class FileStructure
{
    public int Id { get; set; }

    public string Name { get; set; }
}