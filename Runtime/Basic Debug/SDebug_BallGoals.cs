using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDebug_BallGoals : MonoBehaviour
{

    public S_DroneSoccerBallGoals m_ballGoals;
    public Transform m_goalRed;
    public Transform m_goalBlue;


    public void SetWith(S_DroneSoccerBallGoals goals)
    {
        m_ballGoals = goals;
        Vector3 position  = new Vector3(
            0,
            m_ballGoals.m_goalGroundHeightMeter/2f,
            m_ballGoals.m_goalDistanceOfCenterMeter
            );

        Vector3 scale = new Vector3(
            m_ballGoals.m_goalWidthRadiusMeter,
            m_ballGoals.m_goalGroundHeightMeter,
            m_ballGoals.m_goalDepthMeter
            );

        m_goalRed.localScale = scale;
        m_goalBlue.localScale = scale;

        m_goalRed.localPosition = SDebug_Relocation.RotatePointAroundPivot(position, Vector3.zero, new Vector3(0, -90, 0));
        m_goalBlue.localPosition = SDebug_Relocation.RotatePointAroundPivot(position, Vector3.zero, new Vector3(0, 90, 0));
        m_goalRed.localRotation = Quaternion.Euler(0, -90, 0);
        m_goalBlue.localRotation = Quaternion.Euler(0, 90, 0);

    }
}

public class SDebug_Relocation
{
    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Transform rootReference, out Vector3 localPosition)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetWorldToLocal_Point(in worldPosition, in p, in r, out localPosition);
    }
    public static void GetLocalToWorld_Point(in Vector3 localPosition, in Transform rootReference, out Vector3 worldPosition)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetLocalToWorld_Point(in localPosition, in p, in r, out worldPosition);
    }
    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);

    public static void GetLocalToWorld_Point(in Vector3 localPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition) =>
        worldPosition = (rotationReference * localPosition) + (positionReference);

    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Transform rootReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetWorldToLocal_DirectionalPoint(in worldPosition, in worldRotation, in p, in r, out localPosition, out localRotation);
    }
    public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Transform rootReference, out Vector3 worldPosition, out Quaternion worldRotation)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetLocalToWorld_DirectionalPoint(in localPosition, in localRotation, in p, in r, out worldPosition, out worldRotation);
    }
    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        localRotation = Quaternion.Inverse(rotationReference) * worldRotation;
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
    }
    public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition, out Quaternion worldRotation)
    {
        worldRotation = localRotation * rotationReference;
        worldPosition = (rotationReference * localPosition) + (positionReference);
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        return rotation * (point - pivot) + pivot;
    }
}