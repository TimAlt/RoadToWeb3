using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;

public class Polygon : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void MLogin();

    [DllImport("__Internal")]
    private static extern void MLogout();
    public TextMeshProUGUI txt;
    public TextMeshProUGUI loginTxt;
    public TextMeshProUGUI count;
    public Toggle[] toggles;

    private bool loginBool = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        if (loginBool)
        {
            MLogout();
            
        }
        else
        {
            MLogin();
        }
        
    }

    public void LoggedIn(string loggedIn)
    {
        if (loggedIn == "true")
        {
            loginBool = true;
            loginTxt.text = "Logout";
        }
        else
        {
            loginBool = false;
            loginTxt.text = "Login";
        }
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

    public void JsonData(string json)
    {
        JsonObject jsonObject = JsonUtility.FromJson<JsonObject>(json);
        count.text = jsonObject.total;
        int amount = int.Parse(jsonObject.total);

        if (amount > 0)
        {
            foreach (Toggle toggle in toggles)
            {
                toggle.interactable = true;

            }
        }
        
    }

    public void Toggle0(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 0;
            print(World.playerSelection);
        }
    }
    public void Toggle1(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 1;
            print(World.playerSelection);
        }
    }
    public void Toggle2(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 2;
            print(World.playerSelection);
        }
    }
    public void Toggle3(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 3;
            print(World.playerSelection);
        }
    }
    public void Toggle4(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 4;
            print(World.playerSelection);
        }
    }
    public void Toggle5(Toggle toggle)
    {
        if (toggle.isOn)
        {
            World.playerSelection = 5;
            print(World.playerSelection);
        }
    }

    public class JsonObject
    {
        public string total;
        public string token_address;
        public string token_id;
        public string contract_type;
        public string owner_of;
        public string block_number;
        public string block_number_minted;
        public string token_uri;
        public string metadata;
        public string synced_at;
        public string name;
        public string symbol;
    }
}
