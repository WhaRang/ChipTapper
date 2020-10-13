using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBrick : MonoBehaviour
{
    public GameObject brickFrame;
    public int brickNumber;
    

    public void OnPressDown()
    {
        brickFrame.gameObject.transform.position = this.gameObject.transform.position;
    }
}
