using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public int objNum = 1;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > objNum)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }
}
