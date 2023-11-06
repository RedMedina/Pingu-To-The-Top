using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float Speed = 10.0f;
    public float FuerzaDeEmpuje = 2f;
    private Rigidbody rb;

    public Camera camara;
    public Vector3 offsetCamera = new Vector3(0f, 2f, -5f);

    public ParticleSystem Nieve;
    public Vector3 offsetNieve = new Vector3(0f, 5.741f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D
        float verticalInput = Input.GetAxis("Vertical"); // W/S

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        float MultiplicadorNormal = 0.2f;
        if (verticalInput > 0f) // Fuerza mayor en W
        {
            MultiplicadorNormal = FuerzaDeEmpuje;
        }

        rb.AddForce(movement * Speed * MultiplicadorNormal, ForceMode.Force);

        //Movimiento de camara
        Vector3 CameraPositon = transform.localPosition + offsetCamera;
        camara.transform.localPosition = CameraPositon;

        //Movimiento de particulas
        Vector3 NievePos = transform.localPosition + offsetNieve;
        Nieve.transform.localPosition = NievePos;
    }
}
