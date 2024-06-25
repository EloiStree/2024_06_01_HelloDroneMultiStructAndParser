
using UnityEngine;

[System.Serializable]
public abstract class AbstractCategoryBytesParsable<T> : I_CategoryBytesParsable<T>, I_ItemCopyable<T>, I_ItemRandomizable<T> 
{
    public byte m_category255;

    [Header("Randomized Parse")]
    public T m_randomized;
    public T m_randomizedParsed;
    public T m_copyOfRandomized;

    [Header("Test Parse")]
    public T m_startData;
    public byte [] m_data;
    public T m_parseData;



    [Header("Size")]
    public bool m_hasFixedSize;
    public int m_debugBytesSize;




    public abstract void Parse(byte category255, T toParse, out byte[] bytes);
    public abstract bool TryParse(byte[] bytes, out byte category255, out T fromBytes);
    public abstract void HasFixedSize(out bool hasFixedSize, out int bytesSize);

    public void TryParse() {

        Randomize(m_startData, out m_randomized);
        GetCopy(m_randomized, out m_copyOfRandomized);

        Parse(m_category255, m_startData, out m_data);
        TryParse(m_data, out m_category255, out m_parseData);
        
        Parse(m_category255, m_randomized, out byte []data);
        TryParse(data, out m_category255, out m_randomizedParsed);

        HasFixedSize(out m_hasFixedSize, out m_debugBytesSize);
    }

    public abstract void Randomize(T source, out T copy);
    public abstract void GetCopy(T source, out T copy);
}
