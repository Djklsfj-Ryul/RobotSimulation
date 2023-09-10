using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Axis
{
    x,
    y,
    z,
}
public class UrdfJointTag:MonoBehaviour
{
    [SerializeField]
    private Axis jointAxis;

    public Axis JointAxis { get => jointAxis; set => jointAxis = value; }
}
