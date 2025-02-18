using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] CinemachineVirtualCamera puzzleCam1;
    [SerializeField] Canvas Keypad;
    [SerializeField] Canvas Tutorial;

   /* private void OnEnable(){
        CameraSwitcher.Register(mainCam);
        CameraSwitcher.Register(puzzleCam1);
        CameraSwitcher.SwitchCamera(mainCam);
    }
    

    private void OnDisable(){
        CameraSwitcher.Unregister(mainCam);
        CameraSwitcher.Unregister(puzzleCam1);
    }

    */

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<CinemachineBrain>().enabled == false)
            {
                SwitchCamera();
                Keypad.enabled = true;
                Tutorial.enabled = false;
            }
            
            else if (gameObject.GetComponent<CinemachineBrain>().enabled == true)
            {
                SwitchBackCamera();
                Keypad.enabled = false;
                Tutorial.enabled = true;
            }
        }
    }

    public void SwitchCamera()
    {
        GetComponent<CinemachineBrain>().enabled = true;
        //puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = true;
        //mainCam.GetComponent<CinemachineVirtualCamera>().enabled = false;

    }

    public void SwitchBackCamera()
    {
        GetComponent<CinemachineBrain>().enabled = false;
        //puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = false;
        //mainCam.GetComponent<CinemachineVirtualCamera>().enabled = true;

    }
}



/*public class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera)
            {
                c.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
*/