using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angles : MonoBehaviour
{
    [SerializeField]
    private ArticulationBody parentDrive;
    public ArticulationBody joint;
    [SerializeField]
    private ArticulationDrive currentDrive;
    [SerializeField]
    private float a;
    // Start is called before the first frame update
    void Start()
    {
        joint = this.GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDrive = joint.xDrive;
        currentDrive.target = parentDrive.xDrive.target;
        joint.xDrive = currentDrive;
        a = parentDrive.xDrive.target;
    }
}
