using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ACoins : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI acornCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //points += points;
        acornCounter.text = points.ToString();
    }
}
