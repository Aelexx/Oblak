using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera position starts with: 915; 22; 600
public class CameraFollows : MonoBehaviour
{
    public Transform player;
    public float mouseSensitive = 3.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 3, -13);
        
        if (Input.GetMouseButton(0))
            {
            float h = mouseSensitive * Input.GetAxis("Mouse X");
            float v = mouseSensitive * Input.GetAxis("Mouse Y");
            
            transform.Rotate(-v, h, 0);
            //Add these two lines
            float z = transform.eulerAngles.z;
            transform.Rotate(0, 0, -z);
            }
    
    }
}
