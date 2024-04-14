using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] 
    private Subject subjectToObserve;

    private void OnThingHappened()
    {
        print("Observer responds");
    }

    private void Awake()
    {
        if(subjectToObserve != null)
            {
                subjectToObserve.ThingHappened += OnThingHappened;
            }
    }

    private void onDestroy()
    {
        if(subjectToObserve != null)
        {
            subjectToObserve.ThingHappened -= OnThingHappened;
        }
    }





}
