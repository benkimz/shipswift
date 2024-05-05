namespace ShipSwift.CoreBusiness;

public record GroupedQuotes(List<Quote> ShortQuotes, List<Quote> MediumQuotes, List<Quote> LongQuotes);
