using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Don't use to move, just to create and update a big change
/// If you really need to move it. You need a network int id and position rotation compressed => that an other system.
/// </summary>
/// 

[System.Serializable]
public struct S_DoubleGuidItemSpawn 
{
    public ulong m_serverUtcTimeTicksNow;
    public string m_itemString;
    public string m_prefabString;
    public byte[] m_itemGuidAsBytes;
    public byte[] m_prefabGuidAsBytes;
    public Vector3 m_arenaPosition;
    public Quaternion m_arenaRotation;
    public Vector3 m_arenaScale;

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
        if(m_itemGuidAsBytes==null || m_itemGuidAsBytes.Length==0)
            m_itemGuidAsBytes = new byte[36];
        if (m_prefabGuidAsBytes == null || m_prefabGuidAsBytes.Length == 0)
            m_prefabGuidAsBytes = new byte[36];

        m_itemString = System.Text.Encoding.UTF8.GetString(m_itemGuidAsBytes);
        m_prefabString = System.Text.Encoding.UTF8.GetString(m_prefabGuidAsBytes);
    }
}

[System.Serializable]
public class CPS_DoubleGuidItemPosition : AbstractCategoryBytesParsable<S_DoubleGuidItemSpawn>
{
    public int m_bytesSize = 1 + (8 + (36 + 36)) + ((3 * 4) + (4 * 4) + (3 * 4));
    public override void Parse(byte category255, S_DoubleGuidItemSpawn toParse, out byte[] bytes)
    {
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        System.BitConverter.GetBytes(toParse.m_serverUtcTimeTicksNow).CopyTo(bytes, 1);
        toParse.m_itemGuidAsBytes.CopyTo(bytes, 9);
        toParse.m_prefabGuidAsBytes.CopyTo(bytes, 9+36);
        int index = 9+36*2;
        System.BitConverter.GetBytes(toParse.m_arenaPosition.x).CopyTo(bytes, index);
        System.BitConverter.GetBytes(toParse.m_arenaPosition.y).CopyTo(bytes, index + 4);
        System.BitConverter.GetBytes(toParse.m_arenaPosition.z).CopyTo(bytes, index + 8);
        System.BitConverter.GetBytes(toParse.m_arenaRotation.x).CopyTo(bytes, index + 12);
        System.BitConverter.GetBytes(toParse.m_arenaRotation.y).CopyTo(bytes, index + 16);
        System.BitConverter.GetBytes(toParse.m_arenaRotation.z).CopyTo(bytes, index + 20);
        System.BitConverter.GetBytes(toParse.m_arenaRotation.w).CopyTo(bytes, index + 24);
        System.BitConverter.GetBytes(toParse.m_arenaScale.x).CopyTo(bytes, index + 28);
        System.BitConverter.GetBytes(toParse.m_arenaScale.y).CopyTo(bytes, index + 32);
        System.BitConverter.GetBytes(toParse.m_arenaScale.z).CopyTo(bytes, index + 36);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DoubleGuidItemSpawn fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DoubleGuidItemSpawn();
        fromBytes.m_serverUtcTimeTicksNow = System.BitConverter.ToUInt64(bytes, 1);
        fromBytes.m_itemGuidAsBytes = new byte[36];
        fromBytes.m_prefabGuidAsBytes = new byte[36];
        System.Array.Copy(bytes, 9, fromBytes.m_itemGuidAsBytes, 0, 36);
        System.Array.Copy(bytes, 9 + 36, fromBytes.m_prefabGuidAsBytes, 0, 36);
        int index = 9 + 36 * 2;
        fromBytes.m_arenaPosition = new Vector3();
        fromBytes.m_arenaPosition.x = System.BitConverter.ToSingle(bytes, index);
        fromBytes.m_arenaPosition.y = System.BitConverter.ToSingle(bytes, index + 4);
        fromBytes.m_arenaPosition.z = System.BitConverter.ToSingle(bytes, index + 8);
        fromBytes.m_arenaRotation = new Quaternion();
        fromBytes.m_arenaRotation.x = System.BitConverter.ToSingle(bytes, index + 12);
        fromBytes.m_arenaRotation.y = System.BitConverter.ToSingle(bytes, index + 16);
        fromBytes.m_arenaRotation.z = System.BitConverter.ToSingle(bytes, index + 20);
        fromBytes.m_arenaRotation.w = System.BitConverter.ToSingle(bytes, index + 24);
        fromBytes.m_arenaScale = new Vector3();
        fromBytes.m_arenaScale.x = System.BitConverter.ToSingle(bytes, index + 28);
        fromBytes.m_arenaScale.y = System.BitConverter.ToSingle(bytes, index + 32);
        fromBytes.m_arenaScale.z = System.BitConverter.ToSingle(bytes, index + 36);
        fromBytes.RefreshStringFromBytes();
        return true;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public override void Randomize(S_DoubleGuidItemSpawn source, out S_DoubleGuidItemSpawn copy)
    {
        copy = new S_DoubleGuidItemSpawn();
        copy.SetItem(System.Guid.NewGuid().ToString());
        copy.SetPrefab(System.Guid.NewGuid().ToString());
        copy.m_serverUtcTimeTicksNow = (ulong)UnityEngine.Random.Range(0, 1000000);
        copy.m_arenaPosition = new Vector3(UnityEngine.Random.Range(-32f, 32f), UnityEngine.Random.Range(0,32f), UnityEngine.Random.Range(-32f, 32f));
        copy.m_arenaRotation = new Quaternion(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        copy.m_arenaScale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));

        copy.RefreshStringFromBytes();
    }

    public override void GetCopy(S_DoubleGuidItemSpawn source, out S_DoubleGuidItemSpawn copy)
    {
        copy = new S_DoubleGuidItemSpawn();
        copy.m_serverUtcTimeTicksNow = source.m_serverUtcTimeTicksNow;
        copy.m_itemGuidAsBytes = new byte[36];
        source.m_itemGuidAsBytes.CopyTo(copy.m_itemGuidAsBytes, 0);
        copy.m_prefabGuidAsBytes = new byte[36];
        source.m_prefabGuidAsBytes.CopyTo(copy.m_prefabGuidAsBytes, 0);
        copy.m_arenaPosition = source.m_arenaPosition;
        copy.m_arenaRotation = source.m_arenaRotation;
        copy.m_arenaScale = source.m_arenaScale;
        copy.RefreshStringFromBytes();
    }
}
