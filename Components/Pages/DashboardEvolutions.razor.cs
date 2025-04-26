using BlazingConso.Dtos;
using BlazingConso.Entities;
using BlazingConso.Enums;
using BlazingConso.Services.Implementations;
using BlazingConso.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazingConso.Components.Pages;

public partial class DashboardEvolutions
{
    [Inject]
    private IConsoDayService ConsoDayService { get; set; }
    [Inject]
    private IConsoMonthService ConsoMonthService { get; set; }

    private ModeAffichage Mode = ModeAffichage.kWh;
    private bool isAffichagekWh
    {
        get => Mode == ModeAffichage.kWh;
        set => Mode = value ? ModeAffichage.kWh : ModeAffichage.Euros;
    }

    // ----- Données quotidiennes pour la comparaison des 3 dernières semaines
    IEnumerable<ConsoDay> consoDays = new List<ConsoDay>();

    // ----- Liste des données de consommation pour le graphique de comparaison des 3 dernières semaines
    private List<WeeklyComparaisonConsoDto> weeklyConsoChartData {get; set; } = new ();

    // ----- Liste des données de coût pour le graphique de comparaison des 3 dernières semaines
    private List<WeeklyComparaisonCoutDto> weeklyCoutChartData { get; set; } = new();

    // ----- Données mensuelles pour la comparaison des 3 dernières années
    IEnumerable<ConsoMonth> consoMonths = new List<ConsoMonth>();

    // ----- Liste des données de consommation pour le graphique de comparaison des 3 dernières années
    private List<MonthlyComparaisonConsoDto> monthlyConsoChartData { get; set; } = new();

    private string ChartHeight = "400px";

    // --------------------------------------------------------------------------------------------------------------------------------
    private int GetSemaineRelative(string? dateStr, DateTime dateRef)
    {
        if (string.IsNullOrEmpty(dateStr)) return 0;

        if (DateTime.TryParse(dateStr, out var date))
        {
            var diff = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateRef, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
                     - CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return -diff;
        }
        return 0;
    }


    // --------------------------------------------------------------------------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await LoadDataWeeks();
        await LoadDataMonths();
    }


    // --------------------------------------------------------------------------------------------------------------------------------
    private async Task LoadDataWeeks()
    {
        DateTime dateFin = DateTime.Today;
        DateTime dateDebut = dateFin.AddDays(-20);

        consoDays = await ConsodayService.GetConsoDaysPeriod(dateDebut, dateFin);

        // ----- Regroupement par jour (Mon, Tue...) et par semaine relative pour la partie consommation
        var ConsoDataGrouped = consoDays
            .GroupBy(d => new { d.Semaine, d.Jour, d.DateJour }) // groupement par nom + numéro du jour
            .Select(g =>
            {
                return new WeeklyComparaisonConsoDto
                {
                    JourSemaine = g.Key.Semaine, // ex: "Lundi"
                    JourNumero = g.Key.Jour.GetValueOrDefault(),     // ex: 1 pour Lundi
                    DateJour = g.Key.DateJour, // <=== On garde la date exacte ici !
                    ConsoSemaine0 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == 0).Sum(d => d.ConsoJourTotal ?? 0) / 1000,
                    ConsoSemaineMoins1 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == -1).Sum(d => d.ConsoJourTotal ?? 0) / 1000,
                    ConsoSemaineMoins2 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == -2).Sum(d => d.ConsoJourTotal ?? 0) / 1000
                };
            })
            .OrderBy(d => d.JourNumero) // trie les jours dans l’ordre Lundi (1) → Dimanche (7)
            .ToList();

        weeklyConsoChartData = ConsoDataGrouped;

        // ----- Regroupement par jour (Mon, Tue...) et par semaine relative pour la partie consommation
        var CoutDataGrouped = consoDays
            .GroupBy(d => new { d.Semaine, d.Jour }) // groupement par nom + numéro du jour
            .Select(g =>
            {
                return new WeeklyComparaisonCoutDto
                {
                    JourSemaine = g.Key.Semaine, // ex: "Lundi"
                    JourNumero = g.Key.Jour.GetValueOrDefault(),     // ex: 1 pour Lundi
                    CoutSemaine0 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == 0).Sum(d => d.CoutJour) ,
                    CoutSemaineMoins1 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == -1).Sum(d => d.CoutJour),
                    CoutSemaineMoins2 = g.Where(d => GetSemaineRelative(d.DateJour, dateFin) == -2).Sum(d => d.CoutJour)
                };
            })
            .OrderBy(d => d.JourNumero) // trie les jours dans l’ordre Lundi (1) → Dimanche (7)
            .ToList();

        weeklyCoutChartData = CoutDataGrouped;
    }


    // --------------------------------------------------------------------------------------------------------------------------------
    private async Task LoadDataMonths()
    {
        int currentYear = DateTime.Today.Year;

        // Appel au service pour les 3 dernières années
        consoMonths = await ConsoMonthService.GetConsoMonthsOfYearAsync(1, currentYear - 2, 12, currentYear);

        // Vérifie que les données sont présentes et non nulles
        if (consoMonths != null && consoMonths.Any())
        {
            monthlyConsoChartData = Enumerable.Range(1, 12)
                .Select(month => new MonthlyComparaisonConsoDto
                {
                    Mois = month,
                    NomMois = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), // ou juste "Janvier", etc.
                    AnneeN = consoMonths.FirstOrDefault(m => m.annee == currentYear && m.mois == month),
                    AnneeNmoins1 = consoMonths.FirstOrDefault(m => m.annee == currentYear - 1 && m.mois == month),
                    AnneeNmoins2 = consoMonths.FirstOrDefault(m => m.annee == currentYear - 2 && m.mois == month),
                })
                .ToList();
        }
        else
        {
            // Gérer le cas où les données sont vides ou nulles
            monthlyConsoChartData = new List<MonthlyComparaisonConsoDto>();
        }
    }
}
