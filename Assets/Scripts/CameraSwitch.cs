using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCam;
    [SerializeField] CinemachineVirtualCamera puzzleCam1;

    private void OnEnable(){
        CameraSwitcher.Register(mainCam);
        CameraSwitcher.Register(puzzleCam1);
        CameraSwitcher.SwitchCamera(mainCam);
    }

    private void OnDisable(){
        CameraSwitcher.Unregister(mainCam);
        CameraSwitcher.Unregister(puzzleCam1);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = false)
            {
                SwitchCamera();
            }
            
            else if (puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = true)
            {
                SwitchBackCamera();
            }
        }
    }
}

public void SwitchCamera()
{
    GetComponent<CineMachineBrain>().enabled = true;
    puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = true;
    mainCam.GetComponent<CinemachineVirtualCamera>().enabled = false;

}

public void SwitchBackCamera()
{
    GetComponent<CineMachineBrain>().enabled = false;
    puzzleCam1.GetComponent<CinemachineVirtualCamera>().enabled = fakse;
    mainCam.GetComponent<CinemachineVirtualCamera>().enabled = true;

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