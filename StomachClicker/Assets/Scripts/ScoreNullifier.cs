using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNullifier : MonoBehaviour
{
    void Start()
    {
        ScoreManager.manager.ZeroScore();
    }
}
