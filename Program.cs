var letters = new[] {
    "STLNBDMJPR",
    "RTLHAEIOUY",
    "STLNACDEOR",
    "STLNEDHKYR",
};

var words = letters[0].SelectMany(r0 => letters[1].SelectMany(r1 => letters[2].SelectMany(r2 => letters[3].Select(r3 => $"{r0}{r1}{r2}{r3}"))));
Console.WriteLine($"{words.Count()} words");

var englishWords = words.Where(w => gnuciDictionary.EnglishDictionary.Define(w) != null);
Console.WriteLine($"{englishWords.Count()} english words");

var filter = new ProfanityFilter.ProfanityFilter();
var censoredWords = words.Where(w => filter.IsProfanity(w));
Console.WriteLine($"{censoredWords.Count()} censored words:");
Console.Write(string.Join(Environment.NewLine, censoredWords));
