using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{

    public float horizontal = 0;
    public float vertical = 0;
    public float mouseSensitivity = 1;
    public GameObject player;
    public GameObject player_camera;

    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -90, 90);

        player.transform.Rotate(0, horizontal, 0);
        player_camera.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
    }
}
