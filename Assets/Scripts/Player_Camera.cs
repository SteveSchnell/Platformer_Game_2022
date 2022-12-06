using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField]
    private float Seneitivity = 2f,
        CameraMovementSpeed = .9f;

    private float cameraXRotation,
        cameraYRotation = 180f;

    public GameObject Player;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Sensitivity") > 0)
        {
            Seneitivity = PlayerPrefs.GetInt("Sensitivity");
        }
    }

    void Update()
    {
        cameraXRotation += Input.GetAxis("Mouse_Y") * Seneitivity;
        cameraYRotation += Input.GetAxis("Mouse_X") * Seneitivity;

        cameraXRotation = Mathf.Clamp(cameraXRotation, -45, 45);

        transform.rotation = Quaternion.Euler(cameraXRotation * -1, cameraYRotation, 0);

        if (Player != null)
            transform.position = Vector3.Lerp(Player.transform.position, transform.position, CameraMovementSpeed);


    }
}
