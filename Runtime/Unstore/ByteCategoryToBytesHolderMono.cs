using UnityEngine;

public class ByteCategoryToBytesHolderMono : MonoBehaviour {
    public ByteCategoryToBytesHolder m_data;

    public void TryPushIn(byte[] bytes) { 
    
        if(bytes==null || bytes.Length == 0) return;

        byte bytesType = bytes[0];
        foreach (var item in m_data.m_list)
        {
            if(item.m_category == bytesType) {
                item.m_bytes = bytes;
            }
        }

    }
}
