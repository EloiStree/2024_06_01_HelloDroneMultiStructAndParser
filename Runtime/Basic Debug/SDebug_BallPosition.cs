using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDebug_BallPosition : MonoBehaviour
{
    public S_DroneSoccerBallPosition m_ballPositionData;
    public S_DroneSoccerBallGoals m_ballGoals;
    public Transform m_ballLocalPosition;


    public void SetWith(S_DroneSoccerBallPosition ballPosition)
    {
        m_ballPositionData = ballPosition;
        m_ballLocalPosition.localPosition= 
            new Vector3(ballPosition.m_position.x, 
            ballPosition.m_position.y,
            ballPosition.m_position.z);
        m_ballLocalPosition.localRotation =ballPosition.m_rotation;
    }

    public void SetWith(S_DroneSoccerBallGoals goals) { 
    
        m_ballGoals = goals;
        m_ballLocalPosition.localScale= new Vector3(
            goals.m_ballRadius,goals.m_ballRadius,
            goals.m_ballRadius);
    }
}
