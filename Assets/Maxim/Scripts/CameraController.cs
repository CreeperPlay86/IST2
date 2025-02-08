using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 0.5f;
    
    public CinemachineFreeLook FreeLook;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            FreeLook.enabled = true;
        }
        else
        {
            FreeLook.enabled = false;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            FreeLook.m_Orbits[0].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            FreeLook.m_Orbits[1].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            FreeLook.m_Orbits[2].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
    }
}
