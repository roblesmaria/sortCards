using cs;

IList<string> testInput = new List<string>() { "3c", "Js", "2d", "10h", "Kh", "8s", "Ac", "4h" };
SortCards sort = new SortCards();

var output = sort.SortCardList(testInput);

foreach (var card in output)
{
    Console.WriteLine(card);
}