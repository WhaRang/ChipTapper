using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSoundPlayer : MonoBehaviour
{
    public string soundNameOnPressDown;
    public string soundNameOnPressUp;

    public void OnPressDown()
    {
        FindObjectOfType<AudioManager>().Play(soundNameOnPressDown);
    }

    public void OnPressUp()
    {
        FindObjectOfType<AudioManager>().Play(soundNameOnPressUp);
    }
}
