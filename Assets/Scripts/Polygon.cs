using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Polygon : MonoBehaviour
{
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoralisConnected(string mConnected)
    {
        if (mConnected == "true")
        {
            txt.text = "Connected";
        }
        else
        {
            txt.text = "Not Connected";
        }
    }
}
