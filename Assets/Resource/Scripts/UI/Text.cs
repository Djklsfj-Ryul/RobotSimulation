using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    private TextMeshProUGUI[] resourceText;
    private void Start()
    {
        resourceText = GetComponentsInChildren<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        var T = gameObject.GetComponentInParent<Unity.Robotics.UrdfImporter.Control.FKRobot>();
        var uiAngles = T.currentAngles;

        for (int i = 0; i < resourceText.Length; i++)
        {
            resourceText[i].text = uiAngles[i].ToString();
        }
    }
}
