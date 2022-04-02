using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] GameObject persistentObject;
    static bool hasSpawn = false;
    private void Awake()
    {
        if (hasSpawn) return;
        SpawnPersistentObject();
        hasSpawn = true;
    }

    private void SpawnPersistentObject()
    {
        GameObject persistent = Instantiate(persistentObject);
        DontDestroyOnLoad(persistent);
    }
}
