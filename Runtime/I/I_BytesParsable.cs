public interface I_BytesParsable<T>
{
    bool TryParse(byte[] bytes,  out T fromBytes);
    void Parse(T toParse, out byte[] bytes);
    void HasFixedSize(out bool hasFixedSize, out int bytesSize);
}
