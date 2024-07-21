using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerMovmentScript player;
    

    // Update is called once per frame
    void Update()
    {
        text.text = player.maxPosition.ToString("f0");
    }
}
