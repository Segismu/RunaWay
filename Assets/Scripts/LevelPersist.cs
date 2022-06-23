using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPersist : MonoBehaviour
{
   void Awake()
    {
        int numLevelPersist = FindObjectsOfType<LevelPersist>().Length;
        if (numLevelPersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetLevelPersist()
    {
        Destroy(gameObject);
    }
}
