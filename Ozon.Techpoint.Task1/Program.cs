IDictionary<SheepType, int> seaBattleRule = new Dictionary<SheepType, int>
{
    {SheepType.SingleDeck, 4},
    {SheepType.DoubleDeck, 3},
    {SheepType.ThreeDeck, 2},
    {SheepType.FourDeck, 1},
};

IDictionary<SheepType, BattleSheep> seaBattleSheepCollection = new Dictionary<SheepType, BattleSheep>();

foreach (var keyValuePair in seaBattleRule)
{
    seaBattleSheepCollection.TryAdd(keyValuePair.Key, new(0, keyValuePair.Value));
}

var strCount = Convert.ToInt16(Console.ReadLine());
while (strCount-- > 0)
{
    var str = Console.ReadLine();
    var intSheepCollection = str.Split().Select(v => Convert.ToInt16(v));
    var tooMuch = false;
    foreach (var i in intSheepCollection)
    {
        if (seaBattleSheepCollection.TryGetValue((SheepType) i, out var battleSheep))
        {
            if (battleSheep.Count >= battleSheep.Limit)
            {
                Console.WriteLine("NO");
                tooMuch = true;
                break;
            }

            battleSheep.Count++;
        }
    }

    ReInitCount();

    if (!tooMuch) Console.WriteLine("YES");
}

return;

void ReInitCount()
{
    foreach (var battleSheep in seaBattleSheepCollection.Values)
    {
        battleSheep.Count = 0;
    }
}

internal record BattleSheep(int Count, int Limit)
{
    public int Count { get; set; } = Count;
}

internal enum SheepType
{
    SingleDeck = 1,
    DoubleDeck = 2,
    ThreeDeck = 3,
    FourDeck = 4
}