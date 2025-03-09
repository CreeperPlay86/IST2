using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 1f; //Скорость Приближения и Отдаления
    
    public CinemachineFreeLook FreeLook;

    public float ySpeed = 2f;
    public float xSpeed = 300f;
    
    [Range(2f, 10f)]
    public float zoomLimit = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        FreeLook.m_Orbits[0].m_Radius = zoomLimit;
        FreeLook.m_Orbits[1].m_Radius = zoomLimit;
        FreeLook.m_Orbits[2].m_Radius = zoomLimit;
        FreeLook.m_Orbits[0].m_Height = zoomLimit;
        
        zoomLimit = Mathf.Clamp(zoomLimit, 2f, 10f);
        
         FreeLook.m_Orbits[0].m_Radius = Mathf.Clamp(FreeLook.m_Orbits[0].m_Radius, 2f, 10f);
         FreeLook.m_Orbits[1].m_Radius = Mathf.Clamp(FreeLook.m_Orbits[1].m_Radius, 2f, 10f);
         FreeLook.m_Orbits[2].m_Radius = Mathf.Clamp(FreeLook.m_Orbits[2].m_Radius, 2f, 10f);
         
         FreeLook.m_Orbits[0].m_Height = Mathf.Clamp(FreeLook.m_Orbits[0].m_Height, 2f, 10f);
        
        if (Input.GetMouseButton(1)) //Проверка Зажатия ПКМ
        {
            
            FreeLook.m_XAxis.m_MaxSpeed = xSpeed;
            FreeLook.m_YAxis.m_MaxSpeed = ySpeed;
            
        }
        else
        {
            FreeLook.m_XAxis.m_MaxSpeed = 0f;
            FreeLook.m_YAxis.m_MaxSpeed = 0f;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0) //Приближение и Отдаление в зависимости от прокрутки колеса мыши
        {
            zoomLimit += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
        
    }
}
