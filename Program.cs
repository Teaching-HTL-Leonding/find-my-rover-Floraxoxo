Console.Clear();

#region variables
string input = "";                              //defining variables I need everywhere
int countNorthSouth = 0, countWestEast = 0;
int manhattanCount = 0;
bool falseInput = false;
#endregion

#region code
CheckIfCorrectInput(""); //Method to check if the input is valid
 ReplaceNumbers("", 'o'); 
if (countWestEast != 0)
{
    if (countWestEast < 0) { countWestEast *= -1; Console.WriteLine($"The Robo went {countWestEast}m east, "); }
    else if (countWestEast > 0) { Console.WriteLine($" The Robo went {countWestEast}m west, "); }
}
else { Console.WriteLine(""); }
if (countNorthSouth != 0)
{
    if (countNorthSouth < 0) { countNorthSouth *= -1; Console.WriteLine($"The Robo went {countNorthSouth}m south, "); }
    else if (countNorthSouth > 0) { Console.WriteLine($" The Robo went {countNorthSouth}m north, "); }
}
else { Console.WriteLine(""); }
//Console.WriteLine($"Your manhattan distance is {manhattanCount}m, ");
//Console.WriteLine(CalculateShortDistance(0));
#endregion

#region methods
void CheckIfCorrectInput(string help)
{
    do
    {
        Console.Write("Please enter the way you want to go: ");
        input = Console.ReadLine()!;
        help = input.Replace("<", "").Replace(">", "").Replace("^", "").Replace("V", ""); //Replacement of every valid character to see if the input is correct
        if (help == "" || int.Parse(help) < int.MaxValue && int.Parse(help) > 0) { falseInput = false;  }
        else { falseInput = true; }
    } while (falseInput == true);
}
string ReplaceNumbers(string newWay, char help2)
{
    string way = input;
    string  number = way.Replace("<", "").Replace(">", "").Replace("^", "").Replace("V", "");
    int toAdd;
    for (int i = 0; i < way.Length; i++)
    {
        if(i+1 == way.Length) {toAdd = 1;}
        else if(char.IsAsciiDigit(way[i + 1]))
        {toAdd = int.Parse(number[0].ToString());
        number = number.Substring(1);}
        else{
            toAdd = 1;
        }
        CalculateDistance(way[i].ToString(), toAdd);
    } //after that just go into the method to calculate the input and give the newWay for the parameter
    return newWay;
}

void CalculateDistance(string character,int toAdd)
{
        switch (character)
        {
            case "<":
                countWestEast+= toAdd; 
                manhattanCount+= toAdd;
                break;
            case ">":
                countWestEast-= toAdd;
                manhattanCount+= toAdd;
                break;
            case "^":
                countNorthSouth+= toAdd;
                manhattanCount+= toAdd;
                break;
            case "V":
                countNorthSouth-= toAdd;
                manhattanCount+= toAdd;
                break;
            default:
                break;
        }
    }

/*string CalculateShortDistance(double solution)
{
    solution = Math.Sqrt((countWestEast * countWestEast) + (countNorthSouth * countNorthSouth));
    return $"The linear distance is: {solution}";
}*/
#endregion