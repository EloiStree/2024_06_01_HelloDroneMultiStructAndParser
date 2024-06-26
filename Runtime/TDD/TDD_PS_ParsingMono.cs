using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_PS_ParsingMono : MonoBehaviour
{

    public Debug m_data;
    [System.Serializable]
    public class Debug { 
        public CPS_NetworkGameFramePushTiming gameNetworkFrame;
        public CPS_DroneSoccerBallGoals ballGoalInfo;
        public CPS_DroneSoccerBallPosition ballStatePosition;
        public CPS_DroneSoccerPositions positionOfDrones;
        
        public CPS_DroneSoccerTimeValue timeState;

        public CPS_DroneSoccerMatchState matchStateInfo;
        public CPS_DroneSoccerMatchStaticInformation staticMatchInfo;

        public CPS_LinearProjectilePoolItemCreationEvent projectilCreated;
        public CPS_PoolItemDestructionEvent destructionEvent;
        
        public CPS_DroneSoccerIndexIntegerClaim indexClaimInteger;
        public CPS_DroneSoccerPublicXmlRsaKey1024Claim rsaClaim;

        public CPS_DoubleGuidItemPosition m_guidPosition;
        public CPS_DoubleGuidItemPosition m_guidDestruction;
    }



    public bool m_tryToCatch = false;


    [ContextMenu("Try to Parse")]
    public void TryToParse()
    {
        Try(m_data.ballGoalInfo.TryParse);
        Try(m_data.ballStatePosition.TryParse);
        Try(m_data.indexClaimInteger.TryParse);
        Try(m_data.matchStateInfo.TryParse);
        Try(m_data.staticMatchInfo.TryParse);
        Try(m_data.positionOfDrones.TryParse);
        Try(m_data.rsaClaim.TryParse);
        Try(m_data.timeState.TryParse);
        Try(m_data.projectilCreated.TryParse);
        Try(m_data.gameNetworkFrame.TryParse);
        Try(m_data.destructionEvent.TryParse);
        Try(m_data.m_guidPosition.TryParse);
        Try(m_data.m_guidDestruction.TryParse);
    }

    private void Try(Action tryParse)
    {
        if (m_tryToCatch) { 
            try { 
                if(tryParse != null)    
                    tryParse();
            }
            catch (Exception e)
            {
               UnityEngine. Debug.Log(e);
            }
        }
        else
        {
            if (tryParse != null)
                tryParse();
        }
    }
}
