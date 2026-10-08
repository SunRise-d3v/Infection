namespace Infection;

internal class Disease
{
    private readonly string _name = GenerateDiseaseName();
    public string Name => _name;

    private static string GenerateDiseaseName()
    {
        Random rnd = new();
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        char randomLetter1 = letters[rnd.Next(letters.Length)];
        char randomLetter2 = letters[rnd.Next(letters.Length)];

        string name = randomLetter1 + rnd.Next(0, 100 + 1).ToString() +
                       randomLetter2 + rnd.Next(0, 10 + 1).ToString();
        
        return name;
    }
}