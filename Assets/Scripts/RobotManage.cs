using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RobotManage : MonoBehaviour
{
    [SerializeField]
    private bool isPicked;

    private float[,] minMaxJoint0 = new float[2, 2] { { -0.25f, 0f }, { 0f, 0f } };
    private float[,] minMaxJoint1 = new float[2, 2] { { -0.2f, 0.05f }, { 0f, 0f } };
    private float[,] minMaxJoint2 = new float[2, 2] { { -0.15f, 0.2f }, { 0f, 0f } };
    private float[,] minMaxJoint3 = new float[2, 2] { { 30f, -30f }, { 0f, 4500f } };
    private float[,] minMaxJoint4 = new float[2, 2] { { -0f, 0f }, { 0f, 0f } };
    private float[,] minMaxJoint5 = new float[2, 2] { { -0f, 0f }, { 0f, 0f } };
    private float[,] minMaxJoint6 = new float[2, 2] { { -0f, 0.3f }, { 9700f, 0f } };
    private float[,] minMaxJoint7 = new float[2, 2] { { -90f, 90f }, { 0f, 0f } };

    [SerializeField]
    private RobotParameter robot;
    [SerializeField]
    private ArticulationBody[] robotClass;
    [SerializeField]
    private ArticulationDrive[] jointPos;

    List<Dictionary<string, object>> data_Dialog;
    private float pTime;
    public RobotParameter Robot { get => robot; set => robot = value; }

    public SocketFloat manage;
    public Dropdown agents;

    private void Awake()
    {
       // data_Dialog = CSVReader.Read("TEST2");
    }

    int scenarioIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("Manager").GetComponent<SocketFloat>();
        agents = GameObject.Find("AgentControl").GetComponent<Dropdown>();
        //추후 Parameter를 사용하여 변경예정
        robotClass  = new ArticulationBody[] { transform.GetChild(1).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),
                                              transform.GetChild(1).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).transform.GetChild(2).GetComponent<ArticulationBody>(),};
        jointPos = new ArticulationDrive[] { robotClass[0].xDrive,
                                             robotClass[1].zDrive,
                                             robotClass[2].yDrive,
                                             robotClass[3].xDrive,
                                             robotClass[4].xDrive,
                                             robotClass[5].xDrive,
                                             robotClass[6].zDrive,
                                             robotClass[7].xDrive};

        pTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        updateJoint();
        if(agents.value == 1) // single control이라면 이름이 같은 경우에만 사용
        {
            Dropdown agent = GameObject.Find("MainCanvas").transform.Find("Agents").GetComponent<Dropdown>();
            if (int.Parse(gameObject.name.Split()[1]) != agent.value)
                return;
        }
        setJoint(6, 0.3f * (manage.masterDeviceJointData[1] / (minMaxJoint6[1, 0] - minMaxJoint6[1, 1])));
        setJoint(3, (60f * manage.masterDeviceJointData[0] / (minMaxJoint3[1, 0] - minMaxJoint3[1, 1])) + 30f);

        //print(float.Parse(data_Dialog[scenarioIndex]["endeffect"].ToString()));
        //print(float.Parse(data_Dialog[scenarioIndex]["revol"].ToString()));
        //print("EndEffector : " + 0.3f * (1 - float.Parse(data_Dialog[scenarioIndex]["endeffect"].ToString()) / (minMaxJoint6[1, 0] - minMaxJoint6[1, 1])));
        //print("Revolution : " + (60f * (-1) * float.Parse(data_Dialog[scenarioIndex]["revol"].ToString()) / (minMaxJoint3[1, 0] - minMaxJoint3[1, 1])) + 30f);

        /*
        if (Time.time - pTime >= float.Parse(data_Dialog[scenarioIndex]["time"].ToString()))
        {
            //print(0.3f * float.Parse(data_Dialog[scenarioIndex]["endeffect"].ToString()) / (minMaxJoint6[1, 0] - minMaxJoint6[1, 1]));
            setJoint(6, 0.3f * (1 - float.Parse(data_Dialog[scenarioIndex]["endeffect"].ToString()) / (minMaxJoint6[1, 0] - minMaxJoint6[1, 1])));
            setJoint(3, (60f * float.Parse(data_Dialog[scenarioIndex]["revol"].ToString()) / (minMaxJoint3[1, 0] - minMaxJoint3[1, 1])) + 30f);
            scenarioIndex++;
        }*/

        //print(Time.time - pTime + " |||||||||||| " + float.Parse(data_Dialog[scenarioIndex]["time"].ToString()));
    }

    public void setJoint(int index, float value)
    {
        jointPos[index].target = value;

        switch (index)
        {
            case 0:
                robotClass[0].xDrive = jointPos[0];
                break;
            case 1:
                robotClass[1].zDrive = jointPos[1];
                break;
            case 2:
                robotClass[2].yDrive = jointPos[2];
                break;
            case 3:
                robotClass[3].xDrive = jointPos[3];
                break;
            case 6:
                robotClass[6].zDrive = jointPos[6];
                break;
            case 7:
                robotClass[7].xDrive = jointPos[7];
                break;
            default:
                break;
        }

    }

    public float[] updateJoint()
    {
        //추후 Parameter를 사용하여 변경예정
        robot.joint0.RobotJoint = robotClass[0].GetComponent<ArticulationBody>().xDrive.target;
        robot.joint1.RobotJoint = robotClass[1].GetComponent<ArticulationBody>().zDrive.target;
        robot.joint2.RobotJoint = robotClass[2].GetComponent<ArticulationBody>().yDrive.target;
        robot.joint3.RobotJoint = robotClass[3].GetComponent<ArticulationBody>().xDrive.target;
        robot.joint4.RobotJoint = robotClass[4].GetComponent<ArticulationBody>().xDrive.target;
        robot.joint5.RobotJoint = robotClass[5].GetComponent<ArticulationBody>().xDrive.target;
        robot.joint6.RobotJoint = robotClass[6].GetComponent<ArticulationBody>().zDrive.target;
        robot.joint7.RobotJoint = robotClass[7].GetComponent<ArticulationBody>().xDrive.target;
        
        return new float[] {robot.joint0.RobotJoint,
                            robot.joint1.RobotJoint,
                            robot.joint2.RobotJoint,
                            robot.joint3.RobotJoint,
                            robot.joint4.RobotJoint,
                            robot.joint5.RobotJoint,
                            robot.joint6.RobotJoint,
                            robot.joint7.RobotJoint};
    }
}
