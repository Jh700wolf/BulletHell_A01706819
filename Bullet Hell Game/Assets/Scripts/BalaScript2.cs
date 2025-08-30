using UnityEngine;
using System;

public class BalaScript2 : MonoBehaviour
{
    private const float TIEMPO_DE_ESTADIA = 2F;
    private float tiempo = 0f;

    public Vector2 Velocidad;

    // Update is called once per frame
    void Update()
    {

        // Genera el movimiento de la bala a la velocidad indicada.
        Velocidad.x = (float)Math.Sin(tiempo);
        Velocidad.y = (float)Math.Cos(tiempo);
        transform.position += (Vector3)Velocidad  * Time.deltaTime;

        // Cuenta el tiempo de la bala dentro del mapa para eliminarla.
        tiempo += Time.deltaTime;

        if (tiempo > TIEMPO_DE_ESTADIA)
            Desaparecer();
    }

    private void Desaparecer()
    {
        tiempo = 0f;
        gameObject.SetActive(false);
    }
}
