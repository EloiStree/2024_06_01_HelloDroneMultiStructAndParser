
//12 time per second refresh
using UnityEngine.UIElements;

[System.Serializable]
public struct S_DroneSoccerPositions
{
    public long m_dateTimeUtcTick;
    public long m_framePushed;
    public S_DronePositionCompressed m_redDrone0Stricker;
    public S_DronePositionCompressed m_redDrone1;
    public S_DronePositionCompressed m_redDrone2;
    public S_DronePositionCompressed m_redDrone3;
    public S_DronePositionCompressed m_redDrone4;
    public S_DronePositionCompressed m_redDrone5;
    public S_DronePositionCompressed m_blueDrone0Stricker;
    public S_DronePositionCompressed m_blueDrone1;
    public S_DronePositionCompressed m_blueDrone2;
    public S_DronePositionCompressed m_blueDrone3;
    public S_DronePositionCompressed m_blueDrone4;
    public S_DronePositionCompressed m_blueDrone5;

    public S_DroneSoccerPositions GetCopy()
    {
        return new S_DroneSoccerPositions()
        {
            m_dateTimeUtcTick = m_dateTimeUtcTick,
            m_framePushed = m_framePushed,
            m_redDrone0Stricker = m_redDrone0Stricker.GetCopy(),
            m_redDrone1 = m_redDrone1.GetCopy(),
            m_redDrone2 = m_redDrone2.GetCopy(),
            m_redDrone3 = m_redDrone3.GetCopy(),
            m_redDrone4 = m_redDrone4.GetCopy(),
            m_redDrone5 = m_redDrone5.GetCopy(),
            m_blueDrone0Stricker = m_blueDrone0Stricker.GetCopy(),
            m_blueDrone1 = m_blueDrone1.GetCopy(),
            m_blueDrone2 = m_blueDrone2.GetCopy(),
            m_blueDrone3 = m_blueDrone3.GetCopy(),
            m_blueDrone4 = m_blueDrone4.GetCopy(),
            m_blueDrone5 = m_blueDrone5.GetCopy()
        };
    }
}
