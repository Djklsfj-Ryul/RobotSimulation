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
        print(resourceText.Length);
    }
    // Update is called once per frame
    void Update()
    {
        float[] T = new float[8];

        T[0] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).GetComponent<ArticulationBody>().xDrive.target;
        T[1] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().zDrive.target;
        T[2] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().yDrive.target;
        T[3] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().xDrive.target;
        T[4] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().xDrive.target;
        T[5] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().xDrive.target;
        T[6] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().zDrive.target;
        T[7] = GameObject.Find("Robot" + "1").transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>().xDrive.target;
        var uiAngles = T;

        for (int i = 0; i < resourceText.Length; i++)
        {
            resourceText[i].text = uiAngles[i].ToString();
        }
    }
}
