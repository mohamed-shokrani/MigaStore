namespace SharedProject.Models;

public class LongDescription
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<LongDescriptionImage> LongDescriptionImages  { get; set; }
}
