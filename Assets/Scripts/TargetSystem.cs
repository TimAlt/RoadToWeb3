using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public Transform[] targets;
    public Transform player;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = player.position;
        }

    }
}
