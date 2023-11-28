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
        float[] T = gameObject.GetComponentInParent<RobotManage>().updateJoint();

        for (int i = 0; i < resourceText.Length; i++)
        {
            resourceText[i].text = (Mathf.Round(T[i] * 1000) / 1000f).ToString();
        }
    }
}
