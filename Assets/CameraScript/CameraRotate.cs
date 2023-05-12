using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public CinemachineVirtualCamera virtualCamera;
    public Vector3 newFollowOffset;
    public float offsetSpeed = 0.1f;
    public float minZOffset = 0f;

    private float currentZOffset;

    public float maxRotation = 90f;
    public float minRotation = -90f;

    private float currentRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentZOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        //}

        if (Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);

            float mouseY = Input.GetAxis("Mouse Y");
                transform.Rotate(Vector3.right, -mouseY * rotationSpeed * Time.deltaTime);
            Debug.Log(transform.rotation.eulerAngles.x);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentZOffset < -1)
            {
                currentZOffset += offsetSpeed * Time.deltaTime;
            }
            //currentZOffset = Mathf.Clamp(currentZOffset, minZOffset, 0f);
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z = currentZOffset;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentZOffset > -3)
            {
                currentZOffset -= offsetSpeed * Time.deltaTime;
            }
            //currentZOffset = Mathf.Clamp(currentZOffset, minZOffset, 0f);
            virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z = currentZOffset;
        }

        if (transform.rotation.eulerAngles.x > 30f && transform.rotation.eulerAngles.x < 300)
        {
            transform.rotation = Quaternion.Euler(30, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        if (transform.rotation.eulerAngles.x < 340 && transform.rotation.eulerAngles.x > 40)
        {
            transform.rotation = Quaternion.Euler(340, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}
