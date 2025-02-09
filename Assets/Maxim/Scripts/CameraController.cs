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
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    
    {
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

        if (FreeLook.m_Orbits[0].m_Radius < 2f) //Блокировка Приближения
        {
            FreeLook.m_Orbits[0].m_Radius = 2;
            FreeLook.m_Orbits[1].m_Radius = 2;
            FreeLook.m_Orbits[2].m_Radius = 2;
        }

        if (FreeLook.m_Orbits[0].m_Radius > 10f) //Блокировка Дальности
        {
            FreeLook.m_Orbits[0].m_Radius = 10;
            FreeLook.m_Orbits[1].m_Radius = 10;
            FreeLook.m_Orbits[2].m_Radius = 10;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0) //Приближение и Отдаление в зависимости от прокрутки колеса мыши
        {
            
            FreeLook.m_Orbits[0].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            FreeLook.m_Orbits[1].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            FreeLook.m_Orbits[2].m_Radius += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            
        }
        
    }
}
