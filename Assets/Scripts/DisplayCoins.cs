using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
    public GameObject player;
    public GameObject displayer;
    TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText = displayer.GetComponent<TextMeshProUGUI>();
        int amount = player.GetComponent<PlayerCoins>().coins;
        myText.text = string.Format("{0:N0}", amount);
    }
}
