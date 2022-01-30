using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{

    [SerializeField]
    private Transform[] position;

    private int index;
    public int Index { get { return index; } }


    public Vector3 GetSpawnPosition()
    {
        Vector3 pos = position[index++].position;
        if(index >= position.Length)
        {
            index = 0;
        }
        return pos;
    }
}
