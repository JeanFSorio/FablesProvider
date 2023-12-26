namespace FablesProvider.Core.Models;

public class BookCover : DbEntityBase
{
    public required string Name { get; set; }
    public string Cover { get; set; } = "";
    public bool IsImage { get; set; }
}
