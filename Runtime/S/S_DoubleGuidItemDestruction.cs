using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct S_DoubleGuidItemDestruction 
{
    public ulong m_serverUtcTimeTicksNow;
    public string m_itemString;
    public string m_prefabString;
    public byte[] m_itemGuidAsBytes;
    public byte[] m_prefabGuidAsBytes;

    public void SetItem(string guidItemAsString)
    {
        m_itemGuidAsBytes = System.Text.Encoding.UTF8.GetBytes(guidItemAsString);
        RefreshStringFromBytes();
        if (m_itemGuidAsBytes.Length != 36) Debug.LogError("item  guid must be 16 bytes long");
    }
    public void SetPrefab(string guidPrefabAsString)
    {
        m_prefabGuidAsBytes = System.Text.Encoding.UTF8.GetBytes(guidPrefabAsString);
        RefreshStringFromBytes();
        if (m_prefabGuidAsBytes.Length != 36) Debug.LogError("prefab guid must be 16 bytes long");
    }
    public string GetItem()
    {
        return System.Text.Encoding.UTF8.GetString(m_itemGuidAsBytes);
    }
    public string GetPrefab()
    {
        return System.Text.Encoding.UTF8.GetString(m_prefabGuidAsBytes);
    }

    public void RefreshStringFromBytes()
    {
        if (m_itemGuidAsBytes == null || m_itemGuidAsBytes.Length == 0)
            m_itemGuidAsBytes = new byte[36];
        if (m_prefabGuidAsBytes == null || m_prefabGuidAsBytes.Length == 0)
            m_prefabGuidAsBytes = new byte[36];
        m_itemString = System.Text.Encoding.UTF8.GetString(m_itemGuidAsBytes);
        m_prefabString = System.Text.Encoding.UTF8.GetString(m_prefabGuidAsBytes);
    }
}

[System.Serializable]
public class CPS_DoubleGuidItemDestruction : AbstractCategoryBytesParsable<S_DoubleGuidItemDestruction>
{
    public int m_bytesSize = 1 + 8 + 36 + 36;
    public override void Parse(byte category255, S_DoubleGuidItemDestruction toParse, out byte[] bytes)
    {
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        System.BitConverter.GetBytes(toParse.m_serverUtcTimeTicksNow).CopyTo(bytes, 1);
        toParse.m_itemGuidAsBytes.CopyTo(bytes, 9);
        toParse.m_prefabGuidAsBytes.CopyTo(bytes, 9+ 36);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DoubleGuidItemDestruction fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DoubleGuidItemDestruction();
        fromBytes.m_serverUtcTimeTicksNow = System.BitConverter.ToUInt64(bytes, 1);
        fromBytes.m_itemGuidAsBytes = new byte[36];
        fromBytes.m_prefabGuidAsBytes = new byte[36];
        System.Array.Copy(bytes, 9, fromBytes.m_itemGuidAsBytes, 0, 36);
        System.Array.Copy(bytes,9+ 36, fromBytes.m_prefabGuidAsBytes, 0, 36);
        fromBytes.RefreshStringFromBytes();
        return true;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public override void Randomize(S_DoubleGuidItemDestruction source, out S_DoubleGuidItemDestruction copy)
    {
        copy = new S_DoubleGuidItemDestruction();
        copy.SetItem(System.Guid.NewGuid().ToString());
        copy.SetPrefab(System.Guid.NewGuid().ToString());
        copy.m_serverUtcTimeTicksNow = (ulong)UnityEngine.Random.Range(0, 1000000);
        copy.RefreshStringFromBytes();
    }

    public override void GetCopy(S_DoubleGuidItemDestruction source, out S_DoubleGuidItemDestruction copy)
    {
        copy = new S_DoubleGuidItemDestruction();
        copy.m_serverUtcTimeTicksNow = source.m_serverUtcTimeTicksNow;
        copy.m_itemGuidAsBytes = new byte[36];
        source.m_itemGuidAsBytes.CopyTo(copy.m_itemGuidAsBytes, 0);
        copy.m_prefabGuidAsBytes = new byte[36];
        source.m_prefabGuidAsBytes.CopyTo(copy.m_prefabGuidAsBytes, 0);
        copy.RefreshStringFromBytes();
       
    }
}
