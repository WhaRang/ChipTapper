using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundStarter : MonoBehaviour
{
    public BackGroundBehaviour firstScreen;
    public BackGroundBehaviour secondScreen;

    float deltaSpeed = 300.0f;

    public void StartMovement()
    {
        firstScreen.StartMovement();
        secondScreen.StartMovement();
    }

    public void AddSpeed()
    {
        firstScreen.AddSpeed(deltaSpeed);
        secondScreen.AddSpeed(deltaSpeed);
    }
}
