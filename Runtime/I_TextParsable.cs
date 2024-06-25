public interface I_TextParsable<T>
{
    public bool IsValideForParsing(string text);
    bool TryParse(string text,  out T paresed);
    void Parse(T toParse, out string text);
}
