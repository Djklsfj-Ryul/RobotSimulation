using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private bool isPicked;

    public Camera mainCamera;

    public GameObject currentRobot;


    // Update is called once per frame
    void Update()
    {
        // 로봇이 선택되지 않은 상태라면
        if (!isPicked)
        {
            // 로봇 객체를 클릭
            ClickRobot();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                returnMain();
                isPicked = false;
            }
        }
    }

    private string ClickRobot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                if(objectName.Split()[0] == "Robot")
                {
                    currentRobot = hit.collider.gameObject;
                    currentRobot.transform.Find("Canvas").gameObject.SetActive(true);
                    currentRobot.transform.Find("Camera").gameObject.SetActive(true);
                    mainCamera.gameObject.SetActive(false);

                    isPicked = true;

                    return objectName;
                }
            }
        }
        return "";
    }
    private void returnMain()
    {
        currentRobot.transform.Find("Canvas").gameObject.SetActive(false);
        currentRobot.transform.Find("Camera").gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

        currentRobot = null;
    }
}
