using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject Camera;
    public float parallaxMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = new Vector2(Camera.transform.position.x, Camera.transform.position.y) * parallaxMultiplier;
        transform.position = distance;
    }
}
