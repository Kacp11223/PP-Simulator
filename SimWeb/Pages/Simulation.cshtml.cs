using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

public class SimulationModel : PageModel
{
    private SimulationHistory _history;

    public List<IMappable> Items => _history.Items;  // W³aœciwoœæ do zwracania kolekcji postaci

    public int SizeX => _history.SizeX;
    public int SizeY => _history.SizeY;
    public int CurrentTurn { get; private set; }
    public int PreviousTurnIndex => Math.Max(0, CurrentTurn - 1);
    public int NextTurnIndex => Math.Min(_history.TurnLogs.Count - 1, CurrentTurn + 1);
    public string Moves { get; private set; }

    public SimulationModel()
    {
        // Inicjalizacja symulacji (przyk³adowe dane)
        var map = new SmallTorusMap(8);
        var items = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };

        var positions = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(3, 2),
            new Point(6, 5),
            new Point(5, 5)
        };

        string moves = "drudrudluluddlrludlruddurlr";
        var simulation = new Simulation(map, items, positions, moves);
        _history = new SimulationHistory(simulation);
        Moves = moves;
    }
    public char GetSymbolAt(int x, int y)
    {
        var point = new Point(x, y);

        // Pobierz symbole dla danego punktu w obecnym turze
        if (_history.TurnLogs[CurrentTurn].Symbols.TryGetValue(point, out var symbols))
        {
            if (symbols.Count > 1)
            {
                return 'X'; // Symbol grupy
            }

            return symbols[0]; // Pojedynczy symbol
        }

        return ' '; // Puste pole
    }
    public void OnGet(int? index)
    {
        // Jeœli index jest null (pierwszy raz za³adowana strona), ustawiamy CurrentTurn na 1
        if (index == null)
        {
            CurrentTurn = 0;  // Rozpoczynamy od pierwszej tury
        }
        else
        {
            CurrentTurn = index.Value;
        }

        // Upewnij siê, ¿e CurrentTurn nie wychodzi poza zakres dostêpnych tur
        if (CurrentTurn < 0)
        {
            CurrentTurn = 0;
        }

        if (CurrentTurn >= _history.TurnLogs.Count)
        {
            CurrentTurn = _history.TurnLogs.Count - 1;
        }
    }

}
