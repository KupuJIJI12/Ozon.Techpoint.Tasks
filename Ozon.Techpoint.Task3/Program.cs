using System.Text;

var berlandCarNumber1 = new BerlandCarNumber(2, 3);
var berlandCarNumber2 = new BerlandCarNumber(1, 3);
var list = new List<string>();

var strCount = Convert.ToInt16(Console.ReadLine());
while (strCount-- > 0)
{
    var startIndex = 0;
    var str = Console.ReadLine();
    while (startIndex + 5 <= str.Length)
    {
        var substring1 = str.Substring(startIndex, 4);
        if (berlandCarNumber2.IsCorrect(substring1))
        {
            str = str.Substring(startIndex, 4);
            
            list.Add(substring1);
            startIndex += 4;
            
            continue;
        }

        var substring2 = str.Substring(startIndex, 5);
        if(berlandCarNumber1.IsCorrect(substring2))
        {
            list.Add(substring2);
           
            startIndex += 5;
            continue;
        }
        
        Console.WriteLine("-");
        list.Clear();
        break;
    }
}

if (list.Any())
{
    Console.WriteLine(string.Join(' ', list));
}

return;

class BerlandCarNumber
{
    private readonly int _countDigits;
    private readonly int _countSymbols;

    public BerlandCarNumber(int countDigits, int countSymbols)
    {
        _countDigits = countDigits;
        _countSymbols = countSymbols;
    }

    public bool IsCorrect(string input)
    {
        if (input.Count(char.IsDigit) == _countDigits && input.Count(char.IsLetter) == _countSymbols)
        {
            return true;
        }

        return false;
    }
}