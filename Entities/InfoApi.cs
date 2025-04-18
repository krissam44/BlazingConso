namespace BlazingConso.Entities;

public class InfoApi
{
    public string Nom { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public string Auteur { get; set; } = string.Empty;

    public List<string> Endpoints { get; set; } = new List<string>();
}
