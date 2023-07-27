using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.InteropServices;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineFreeLook camera;
    [SerializeField] private Vector2 axisSpeed;

    [Header("Height")]
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float scrollSpeed;

    private float cameraHeight;

    private void Start()
    {
        SetAxisSpeed(Vector2.zero);
        cameraHeight = camera.m_Orbits[1].m_Height;
        print(cameraHeight);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            Cursor.lockState = CursorLockMode.Locked;
           SetAxisSpeed(axisSpeed);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
            SetAxisSpeed(Vector2.zero);
        }

        cameraHeight += (Input.mouseScrollDelta.y * scrollSpeed * Time.deltaTime)*-1;

        cameraHeight = Mathf.Clamp(cameraHeight, minHeight, maxHeight);

        //camera.m_Orbits[0].m_Height = cameraHeight;
       // camera.m_Orbits[1].m_Height = cameraHeight;


    }

    private void SetAxisSpeed(Vector2 speedVector)
    {
        camera.m_YAxis.m_MaxSpeed = speedVector.y;
        camera.m_XAxis.m_MaxSpeed = speedVector.x;
    }
}