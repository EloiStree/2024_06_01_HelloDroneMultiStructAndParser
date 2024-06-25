


[System.Serializable]
public struct S_DroneSoccerTimeValue {
    public float m_secondsSinceMatchStarted;
    public float m_secondsSinceSetStarted;
    public ulong m_timeOfServerDateTimeUtcNowTicks;

    public S_DroneSoccerTimeValue GetCopy(){ 
    return new S_DroneSoccerTimeValue() {
        m_secondsSinceMatchStarted = m_secondsSinceMatchStarted,
        m_secondsSinceSetStarted = m_secondsSinceSetStarted,
        m_timeOfServerDateTimeUtcNowTicks = m_timeOfServerDateTimeUtcNowTicks
    };
    }
}
