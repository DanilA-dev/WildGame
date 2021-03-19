using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    private CinemachineBrain CMBrain;

    private void Awake() => CMBrain = FindObjectOfType<CinemachineBrain>();

    private void OnEnable()
    {
        MovingPlatform.OnEnterPlatform += CMSmartUpdateChange;
        MovingPlatform.OnExitPlatform += CMFixedUpdateChange;
    }

    private void OnDisable()
    {
        MovingPlatform.OnEnterPlatform -= CMSmartUpdateChange;
        MovingPlatform.OnExitPlatform -= CMFixedUpdateChange;
    }

    
    private void CMFixedUpdateChange() => CMBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;

    private void CMSmartUpdateChange() => CMBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.SmartUpdate;
    

}
