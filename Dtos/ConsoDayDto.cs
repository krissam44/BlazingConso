namespace BlazingConso.Dtos;

public class ConsoDayDto
{
    public DateTime dateJour { get; set; }
    public int jour { get; set; }         // Lundi = 1 ... Dimanche = 7
    public string semaine { get; set; } = string.Empty; // "Mon", "Tue", ...
    public int consoJourTotal { get; set; }
}
