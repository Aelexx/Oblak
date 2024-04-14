using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subject : MonoBehaviour
{
    public event Action ThingHappened;

        public void DoThing()
        {
            ThingHappened?.Invoke();
        }
}
