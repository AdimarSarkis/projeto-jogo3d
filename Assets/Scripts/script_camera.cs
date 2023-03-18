using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_camera : MonoBehaviour
{
    private Quaternion rotOriginal;
    private float rotMouseY = 0;
    // Start is called before the first frame update
    void Start()
    {
        rotOriginal = transform.localRotation;
    }

    private void verificaRotacao()
    {
        rotMouseY += Input.GetAxis("Mouse Y");
        rotMouseY = Mathf.Clamp(rotMouseY, -50, 50);

        Quaternion cimabaixo = Quaternion.AngleAxis(rotMouseY, Vector3.left);
        transform.localRotation = rotOriginal * cimabaixo;
    }

    // Update is called once per frame
    void Update()
    {
        verificaRotacao();
    }
}
