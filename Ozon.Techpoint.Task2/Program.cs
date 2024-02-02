var table = new Dictionary<int, int>()
{
    {1, 31},
    {3, 31},
    {4, 30},
    {5, 31},
    {6, 30},
    {7, 31},
    {8, 31},
    {9, 30},
    {10, 31},
    {11, 30},
    {12, 31}
};

var strCount = Convert.ToInt16(Console.ReadLine());

while (strCount-- > 0)
{
    var intCollection = Console
        .ReadLine()?
        .Split()
        .Select(v => Convert.ToInt32(v))
        .ToArray();
    (int Day, int Month, int Year) datetime = new(intCollection[0], intCollection[1], intCollection[2]);

    Console.WriteLine(IsCorrectDate(datetime.Day, datetime.Month, datetime.Year) ? "YES" : "NO");
}

return;

bool IsCorrectDate(int day, int month, int year)
{
    var isLeapYear = IsLeapYear(year);
    if (month == 2)
    {
        if (isLeapYear)
        {
            
            return day <= 29;
        }

        return day <= 28;
    }

    if (table.TryGetValue(month, out var d))
    {
        if (day <= d)
        {
            return true;
        }
    }

    return false;
}

bool IsLeapYear(int year)
{
    if (year % 4 != 0) return false;
    if (year % 100 != 0) return true;
    
    return year % 400 == 0;
}