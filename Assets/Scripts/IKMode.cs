using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKMode : MonoBehaviour
{
    [SerializeField]
    private float ikPosX;
    [SerializeField]
    private float ikPosY;
    [SerializeField]
    private float ikPosZ;
    [SerializeField]
    private float ikRot;

    public float relPosX;

    [SerializeField]
    private Vector3 endEffectorPos;

    [SerializeField]
    private ArticulationBody parentDrive;
    public ArticulationBody[] joints;
    [SerializeField]
    private ArticulationDrive currentDrive;

    // Start is called before the first frame update
    void Start()
    {
        joints = this.GetComponentsInChildren<ArticulationBody>();
        endEffectorPos = gameObject.GetComponentInChildren<EndEffectorWorldPosition>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endEffectorPos = gameObject.GetComponentInChildren<EndEffectorWorldPosition>().transform.position;
    }
}
