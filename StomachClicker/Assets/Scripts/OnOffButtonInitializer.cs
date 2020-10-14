using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnOffButton))]
[RequireComponent(typeof(MovingBgActivator))]
public class OnOffButtonInitializer : MonoBehaviour
{
    OnOffButton button;
    MovingBgActivator activator;

    private void Start()
    {
        button = GetComponent<OnOffButton>();
        activator = GetComponent<MovingBgActivator>();

        if (UiSettings.settings.GetMovingBgAlpha() == 1.0)
        {
            activator.SetIsActive(true);
            button.SetIsActive(true);
        }
        else
        {
            activator.SetIsActive(false);
            button.SetIsActive(false);
        }
    }
}
