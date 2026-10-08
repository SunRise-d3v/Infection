namespace Infection;

internal sealed class Application : IDisposable
{
    private bool _isRunning;

    private Human[] _humans = [];
    private int _humanCount;

    private const int MAX_HUMAN_COUNT = 2000000000;
    private const int MIN_HUMAN_COUNT = 1;

    private int _humanHealthyCount;
    private int _humanInfectedCount;
    private int _humanDeadCount;

    private bool _canStart;

    private byte _numberDisease;

    private Disease? _disease;
    private ushort _day;

    private Random _rnd;

    public Application()
    {
        Console.CursorVisible = false;
        _rnd = new();
    }

    public void Awake()
    {
        Console.Write("Enter the number of people: ");

        while (!int.TryParse(Console.ReadLine(), out _humanCount)
               || _humanCount < MIN_HUMAN_COUNT
               || _humanCount > MAX_HUMAN_COUNT)
            Console.Write($"Invalid input. Enter a number from {MIN_HUMAN_COUNT} to {MAX_HUMAN_COUNT}: ");

        _humans = new Human[_humanCount];
        for (int i = 0; i < _humans.Length; i++)
            _humans[i] = new();

        _humanHealthyCount = _humanCount;

        _disease = new();
        _numberDisease = (byte)_rnd.Next(1, byte.MaxValue + 1);

        Console.Clear();
        Console.Write($"Human: {_humanCount} | ");
        Console.Write($"№ {_numberDisease} Bacterium: {_disease.Name}\n");

        Console.Write("Press Space to start the simulation.");

        while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("Press SPACE to start the simulation.\n");
        }

        Console.Clear();

        Console.SetCursorPosition(default, default);
        Console.Write("Starting the simulation.");
        Thread.Sleep(333);

        Console.SetCursorPosition(default, default);
        Console.Write("Starting the simulation..");
        Thread.Sleep(333);

        Console.SetCursorPosition(default, default);
        Console.Write("Starting the simulation...");
        Thread.Sleep(333);

        Console.SetCursorPosition(default, default);
        Console.Write("Starting the simulation.. \n");
        Thread.Sleep(400);

        _day = 1;

        _isRunning = true;
    }

    public void Update()
    {
        Input();

        _day++;

        if (_day == 2)
        {
            _humans[_rnd.Next(0, _humanCount)].IsInfected = true;
            _humanInfectedCount++;
            _humanHealthyCount--;
        }

        Thread.Sleep(250);
    }

    public void Draw()
    {
        Console.SetCursorPosition(default, default);

        Console.Write($"Human: {_humanCount} | ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Healthy");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($": {_humanHealthyCount} | ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Infected");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($": {_humanInfectedCount} | ");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Dead");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($": {_humanDeadCount}\n");

        Console.Write($"Day: {_day}\n");
    }

    private void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Q:
                    _isRunning = false;
                    break;

                default:
                    break;
            }
        }
    }

    public void Quit()
    {
        Dispose();
    }

    public void run()
    {
        Awake();

        while (_isRunning)
        {
            Update();
            Draw();
        }

        Quit();
    }

    public void Dispose()
    {

    }
}