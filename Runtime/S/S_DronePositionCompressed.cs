using UnityEngine;


// I_BytesParsable


[System.Serializable]
public struct S_DronePositionCompressed
{
    public short m_localPositionX;
    public short m_localPositionY;
    public short m_localPositionZ;
    public byte m_eulerAngleX;
    public byte m_eulerAngleY;
    public byte m_eulerAngleZ;

    public void SetPosition(Vector3 localPosition)
    {
        m_localPositionX = (short)(Mathf.Clamp(localPosition.x * 1000f, short.MinValue, short.MaxValue));
        m_localPositionY = (short)(Mathf.Clamp(localPosition.y * 1000f, short.MinValue, short.MaxValue));
        m_localPositionZ = (short)(Mathf.Clamp(localPosition.z * 1000f, short.MinValue, short.MaxValue));
    }
    public void SetRotation(Quaternion localRotation)
    {
        Vector3 euler = localRotation.eulerAngles;
        Convert360AngleTo255(euler.x, out m_eulerAngleX);
        Convert360AngleTo255(euler.y, out m_eulerAngleY);
        Convert360AngleTo255(euler.z, out m_eulerAngleZ);
    }

    private void Convert360AngleTo255(float angle, out byte angle255)
    {
        angle255 = (byte)((angle % 360) / 360f * 255f);
    }
    private void Convert255AngleTo360(float angle255, out byte angle360)
    {
        angle360 = (byte)(angle255 / 255f * 360f);
    }
    public Vector3 GetPosition()
    {
        return new Vector3(m_localPositionX/1000f, m_localPositionY / 1000f, m_localPositionZ / 1000f);
    }
    public Quaternion GetRotation()
    {
        Convert255AngleTo360(m_eulerAngleX, out byte x);
        Convert255AngleTo360(m_eulerAngleY, out byte y);
        Convert255AngleTo360(m_eulerAngleZ, out byte z);
        return Quaternion.Euler(x, y,z);
    }

   
}
