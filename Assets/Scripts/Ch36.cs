using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch36 : MonoBehaviour
{
    private CharacterController ch36Controller;
    public bool ch36Grounded;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ch36Controller = gameObject.AddComponent<CharacterController>();
        ch36Controller.radius = 0.65f;
        
    }

    // Update is called once per frame
    void Update()
    {
        ch36Grounded = ch36Controller.isGrounded;
        transform.Rotate(Vector3.back * 2.5f * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * 2.5f * Time.deltaTime, Space.World);


    }
}
