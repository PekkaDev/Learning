namespace RepickStore.Models;

public class Review
{
    public int ID { get; set; }
    public int Grades { get; set; }
    public string? Description { get; set; }

    public ApplicationUser Reviewer { get; set; } = new();
}