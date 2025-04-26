using BlazingConso.Dtos;
using BlazingConso.Entities;
using BlazingConso.Enums;
using BlazingConso.Services.Implementations;
using BlazingConso.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazingConso.Components.Pages;

public partial class DashboardJoursMois
{
    [Inject]
    private IConsoDayService ConsoDayService { get; set; }

    private string TitrePeriode => $"Plusieurs Jours / Consommation journalière pour la période du {startDate:dd/MM/yyyy} au {endDate:dd/MM/yyyy}";

    private ModeAffichage Mode = ModeAffichage.kWh;
    private bool isAffichagekWh
    {
        get => Mode == ModeAffichage.kWh;
        set => Mode = value ? ModeAffichage.kWh : ModeAffichage.Euros;
    }

    private bool allowPaging = false;

    private DateTime startDate = DateTime.Today.AddDays(-30);
    private DateTime endDate = DateTime.Today;
    private DateTime minDate = DateTime.Today.AddDays(-90);
    private DateTime maxDate = DateTime.Today;
    private DateTime LastMonth { get; set; }
    private DateTime WeekStart { get; set; }
    private DateTime WeekEnd { get; set; }
    private DateTime LastWeekStart { get; set; }
    private DateTime LastWeekEnd { get; set; }
    private DateTime MonthStart { get; set; }
    private DateTime MonthEnd { get; set; }
    private DateTime LastMonthStart { get; set; }
    private DateTime LastMonthEnd { get; set; }
    private DateTime LastQuarterStart { get; set; }
    private DateTime LastQuarterEnd { get; set; }
    private DateTime LastYearStart { get; set; }
    private DateTime LastYearEnd { get; set; }
    private int Days { get; set; }

    private IEnumerable<ConsoDay> consoDays = new List<ConsoDay>();

    private List<HistoDayConsoDto> ConsoChartData = new();

    private List<HistoDayCoutDto> CoutChartData = new();

    private bool isGridReady = false;
    private bool isChartReady = false;
    private bool isAllReady => isGridReady && isChartReady;

    private bool isDataLoaded;
    private bool isLoading = false;

    private int RowHeight = 26;       // Par défaut dans Syncfusion
    private int HeaderHeight = 56;    // Ajuste selon ton thème / padding
    private string ChartHeight = "550px";
    private string GridHeight
    {
        get
        {
            if (consoDays == null || !consoDays.Any())
                return "200px"; // valeur par défaut si vide
            if (consoDays.Count() > 20)
                return "550px";
            // ----- Calcul dynamique : (nb de lignes * row height) + header
            return $"{consoDays.Count() * RowHeight + HeaderHeight}px";
        }
    }


    // ---------------------------------------------------------------------------------------------------
    private void AfficherDonnees()
    {
        LoadData();
    }


    // ---------------------------------------------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        Days = (int)DateTime.Now.DayOfWeek;
        LastMonth = DateTime.Now.AddMonths(-1);
        WeekStart = DateTime.Now.AddDays(-Days);
        WeekEnd = WeekStart.AddDays(6);
        MonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        MonthEnd = MonthStart.AddMonths(1).AddDays(-1);
        LastMonthStart = new DateTime(LastMonth.Year, LastMonth.Month, 1);
        LastMonthEnd = LastMonthStart.AddMonths(1).AddDays(-1);
        LastYearStart = new DateTime(DateTime.Now.Year - 1, 1, 1);
        LastYearEnd = new DateTime(DateTime.Now.Year - 1, 12, 31);
        CalculerSemaineDerniere();
        CalculerDernierTrimestre();

        await LoadData();
    }


    // ---------------------------------------------------------------------------------------------------
    private void CalculerSemaineDerniere()
    {
        // Date d'aujourd'hui
        var today = DateTime.Today;

        // ------ Trouver le jour de la semaine (lundi = 1, dimanche = 0 en .NET sauf qu'ici on veut lundi = 0)
        int delta = DayOfWeek.Monday - today.DayOfWeek;
        if (delta > 0) delta -= 7; // Pour reculer au dernier lundi

        // ----- Début de cette semaine
        var startOfThisWeek = today.AddDays(delta);

        // ----- Semaine dernière = -7 jours
        LastWeekStart = startOfThisWeek.AddDays(-7);
        LastWeekEnd = startOfThisWeek.AddDays(-1); // Dimanche dernier
    }


    // ---------------------------------------------------------------------------------------------------
    private void CalculerDernierTrimestre()
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        // ----- Trouver le trimestre actuel
        int currentQuarter = (currentMonth - 1) / 3 + 1;

        // Trimestre précédent
        int lastQuarter = currentQuarter - 1;
        int yearOfLastQuarter = currentYear;

        if (lastQuarter == 0)
        {
            lastQuarter = 4;
            yearOfLastQuarter -= 1;
        }

        // ----- Calcul des dates de début et de fin
        LastQuarterStart = new DateTime(yearOfLastQuarter, (lastQuarter - 1) * 3 + 1, 1);
        LastQuarterEnd = LastQuarterStart.AddMonths(3).AddDays(-1);
    }


    // ---------------------------------------------------------------------------------------------------
    private async Task LoadData()
    {
        isLoading = true;

        try
        {
            consoDays = await ConsoDayService.GetConsoDaysPeriod(startDate, endDate);

            if (consoDays.Any())
            {
                var frenchCulture = new CultureInfo("fr-FR");

                // Prétraitement des données
                foreach (var cd in consoDays)
                {
                    cd.DateJour = DateTime.Parse(cd.DateJour).ToString("ddd dd/MM/yyyy", frenchCulture);
                    cd.ConsoJourHP = Math.Round(cd.ConsoJourHP.Value / 1000m, 2);
                    cd.ConsoJourHC = Math.Round(cd.ConsoJourHC.Value / 1000m, 2);
                    cd.ConsoJourTotal = Math.Round(cd.ConsoJourTotal.Value / 1000m, 2);
                }

                // Création parallèle des données pour le graphique
                var consoChartTask = Task.Run(() =>
                    consoDays.Select(cd => new HistoDayConsoDto
                    {
                        DateJour = DateTime.Parse(cd.DateJour),
                        Consommation = cd.ConsoJourTotal.Value
                    }).ToList());

                var coutChartTask = Task.Run(() =>
                    consoDays.Select(cd => new HistoDayCoutDto
                    {
                        DateJour = DateTime.Parse(cd.DateJour),
                        CoutTotal = cd.CoutJour
                    }).ToList());

                await Task.WhenAll(consoChartTask, coutChartTask);

                ConsoChartData = consoChartTask.Result;
                CoutChartData = coutChartTask.Result;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erreur de chargement : {ex.Message}");
        }

        isLoading = false;
        StateHasChanged();
    }

    // ---------------------------------------------------------------------------------------------------
    private List<(int Id, string Name)> moisList = Enumerable.Range(1, 12)
        .Select(i => (i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)))
        .ToList();
}
