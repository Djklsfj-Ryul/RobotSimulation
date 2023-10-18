using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RobotAxis
{ 
    x,
    y,
    z
}

public enum RobotJointType
{ 
    Prismatic,  //선형 이동
    Revolution, //회전
}

public class Parameter
{
    private float robotJoint = 0f;
    private RobotJointType jointType;
    private RobotAxis robotAxis;

    public float RobotJoint { get => robotJoint; set => robotJoint = value; }
    public float JointType { get => robotJoint; set => robotJoint = value; }
    public float RobotAxis { get => robotJoint; set => robotJoint = value; }

    public Parameter(RobotAxis axis, RobotJointType type) 
    {
        robotAxis = axis;
        jointType = type;
    }
}

[CreateAssetMenu(fileName = "Robot", menuName = "Robot/RobotParameter")]
public class RobotParameter : ScriptableObject
{
    public Parameter joint0 = new Parameter(RobotAxis.x, RobotJointType.Prismatic);
    public Parameter joint1 = new Parameter(RobotAxis.z, RobotJointType.Prismatic);
    public Parameter joint2 = new Parameter(RobotAxis.y, RobotJointType.Prismatic);
    public Parameter joint3 = new Parameter(RobotAxis.x, RobotJointType.Revolution);
    public Parameter joint4 = new Parameter(RobotAxis.x, RobotJointType.Revolution);
    public Parameter joint5 = new Parameter(RobotAxis.x, RobotJointType.Revolution);
    public Parameter joint6 = new Parameter(RobotAxis.z, RobotJointType.Prismatic);
    public Parameter joint7 = new Parameter(RobotAxis.x, RobotJointType.Revolution);
}
