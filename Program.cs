Console.Clear();

#region variables
string input = "";
int countNorthSouth = 0, countWestEast = 0;
bool falseInput = false;
#endregion

#region code
CheckIfCorrectInput("");
CalculateDistance(input);
if (countWestEast != 0)
{
    if (countWestEast < 0) { countWestEast *= -1; Console.WriteLine($"The Robo went {countWestEast}m east"); }
    else if (countWestEast > 0) { Console.WriteLine($"The Robo went {countWestEast}m west"); }
}
else { Console.WriteLine(""); }
if (countNorthSouth != 0)
{
    if (countNorthSouth < 0) {countNorthSouth *= -1; Console.WriteLine($"The Robo went {countNorthSouth}m south"); }
    else if (countNorthSouth > 0) { Console.WriteLine($"The Robo went {countNorthSouth}m north"); }
}
else { Console.WriteLine(""); }
#endregion

#region methods
void CheckIfCorrectInput(string help)
{
    do
    {
        Console.Write("Please enter the way you want to go: ");
        input = Console.ReadLine()!;
        help = input.Replace("<", "").Replace(">", "").Replace("^", "").Replace("V", "");
        if (help == "") { falseInput = false; }
        else { falseInput = true; }
    } while (falseInput == true);
}
void CalculateDistance(string way)
{
    for (int i = 0; i < way.Length; i++)
    {
        char help = way[i];
        switch (help)
        {
            case '<':
                countWestEast++;
                break;
            case '>':
                countWestEast--;
                break;
            case '^':
                countNorthSouth++;
                break;
            case 'V':
                countNorthSouth--;
                break;
            default:
                break;
        }
    }
}
#endregion

