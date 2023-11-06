using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snowbal : MonoBehaviour
{

    private Rigidbody rb;
    private float AlturaAnterior;

    public float ExtraFactorScale = 0.5f;
    public float MassExtraFactor = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AlturaAnterior = transform.localPosition.y;
    }

    void Update()
    {
        float alturaActual = transform.localPosition.y * ExtraFactorScale;

        if (alturaActual > AlturaAnterior)
        {
            // Calcula el aumento en altura desde la última frame.
            float aumentoDeAltura = alturaActual - AlturaAnterior;

            // Aumenta la escala del objeto.
            Vector3 nuevaEscala = transform.localScale;
            nuevaEscala.x += aumentoDeAltura;
            nuevaEscala.y += aumentoDeAltura;
            nuevaEscala.z += aumentoDeAltura;
            transform.localScale = nuevaEscala;

            // Aumenta la masa del Rigidbody.
            float aumentoDeMasa = (transform.localPosition.y * MassExtraFactor) - AlturaAnterior;
            rb.mass += aumentoDeMasa;
        }

        // Actualiza la altura anterior para la próxima frame.
        AlturaAnterior = alturaActual;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lose_Floor")) 
        {
            SceneManager.LoadScene("Lose_Screen"); //Pantalla de perdiste
        }
    }
}
