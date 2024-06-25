public interface I_CategoryBytesParsable<T>
{
    bool TryParse(byte[] bytes, out byte category255, out T fromBytes);
    void Parse(byte category255, T toParse, out byte[] bytes);
    void HasFixedSize(out bool hasFixedSize, out int bytesSize);
}
