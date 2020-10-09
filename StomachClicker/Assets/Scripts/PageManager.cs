using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public static PageManager manager;

    public int currPage;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<PageManager>();
    }
}
