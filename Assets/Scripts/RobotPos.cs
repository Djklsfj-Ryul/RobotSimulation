using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPos : MonoBehaviour
{
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = transform.Find("base_link").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        A.transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
    }
}
