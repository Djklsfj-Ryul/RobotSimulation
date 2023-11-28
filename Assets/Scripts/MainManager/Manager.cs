using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject robotPrefab;
    public GameObject firstRobot;
    public List<GameObject> robotPrefabs;

    private Toggle addRobot;
    private Toggle moveRobot;

    public Dropdown agentControl;

    private bool addRobotTrigger = true;

    private GameObject currentRobot;

    public List<Vector3> robotPositions;

    public Dropdown agents;

    public int naming = 1;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        robotPrefabs = new List<GameObject>() { firstRobot };
        addRobot = GameObject.Find("AddRobot").GetComponent<Toggle>();
        //moveRobot = GameObject.Find("MoveRobot").GetComponent<Toggle>();
        robotPositions = new List<Vector3>() { firstRobot.transform.position };
    }

    public void AddRobot()
    {
        // 토글이 켜져있다면 로봇 생성가능
        if(!addRobot.isOn && addRobotTrigger)
        {
            var T = Instantiate(robotPrefab, new Vector3(0, 4.6f, 4), Quaternion.identity);
            robotPrefabs.Add(T);
            currentRobot = T;
            currentRobot.name = "Robot " + naming.ToString();
            naming++;
            addRobotTrigger = false;
        }
        else if(addRobotTrigger)
        {
            addRobot.isOn = false;
        }
    }
    int pnaming = 0;
    private void Update()
    {
        if (!addRobotTrigger)
        {
            if (Input.GetKeyDown(KeyCode.J))
                currentRobot.transform.Translate(2, 0, 0);
            if (Input.GetKeyDown(KeyCode.L))
                currentRobot.transform.Translate(-2, 0, 0);
            if (Input.GetKeyDown(KeyCode.I))
                currentRobot.transform.Translate(0, 0, -2);
            if (Input.GetKeyDown(KeyCode.K))
                currentRobot.transform.Translate(0, 0, 2);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (currentRobot.transform.position == new Vector3(0, 4.6f, 4))
                    return;
                for (int i = 0; i < robotPositions.Count; i++)
                {
                    Debug.Log(currentRobot.transform.position);
                    Debug.Log(robotPositions[i]);
                    if(currentRobot.transform.position == robotPositions[i])
                    {
                        return;
                    }
                }
                robotPositions.Add(currentRobot.transform.position);
                addRobot.isOn = true;
                addRobotTrigger = true;
            }    
        }
        // Single-Agent Control
        if(agentControl.value == 1)
        {
            agents.gameObject.SetActive(true);
        }
        else
        {
            agents.gameObject.SetActive(false);
        }
        if (pnaming != naming)
        {
            agents.AddOptions(new List<string> { "Robot " + pnaming.ToString() });
            pnaming = naming;
        }
    }
}
