using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Linq;

public class SpatialMapToggle : MonoBehaviour
{

    public void ToggleSpatialMap()
    {
        if(CoreServices.SpatialAwarenessSystem != null)
        {
            if (IsObserverRunning)
            {
                CoreServices.SpatialAwarenessSystem.SuspendObservers();
                CoreServices.SpatialAwarenessSystem.ClearObservations();
            }
            else
            {
                CoreServices.SpatialAwarenessSystem.ResumeObservers();
            }
        }
    }

    private bool IsObserverRunning
    {
        get
        {
            var providers = ((IMixedRealityDataProviderAccess)CoreServices.SpatialAwarenessSystem)
                .GetDataProviders<IMixedRealitySpatialAwarenessObserver>();
            return providers.FirstOrDefault()?.IsRunning == true;
        }
    }
}
