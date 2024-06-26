using System.Collections.Generic;

[System.Serializable]
public class ByteCategoryToBytesHolder {

    public List<ByteCategoryToBytes> m_list= new List<ByteCategoryToBytes>();
    [System.Serializable]
    public class ByteCategoryToBytes
    {
        public byte m_category = 0;
        public byte[] m_bytes = new byte[0];

    }
}
