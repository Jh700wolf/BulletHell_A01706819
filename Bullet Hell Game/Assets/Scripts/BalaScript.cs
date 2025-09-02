using UnityEngine;

public class BalaScript : MonoBehaviour
{
    // Estas variables me sirven para poder mantener las balas solo por un momento
    // De esta forma evito que se crashee todo.
    private const float TIEMPO_DE_ESTADIA = 2F;
    private float tiempo = 0f;
    public float frecuencia = 6f;
    public float amplitud = 0.5f;

    // Para determinar la velocidad de la bala
    public Vector2 Velocidad;
    public bool senoidal;
    public bool cosenoidal;
    public bool corte;
    public bool dir = false;
    

    // Metodo de Update con los cambios a la posicion de la bala
    // void
    void Update()
    {
        if (senoidal == true)
        {
            
            float nuevoX = transform.position.x + Mathf.Sin(tiempo * frecuencia) * amplitud; 
            float nuevoY = transform.position.y + Velocidad.y * Time.deltaTime;
            transform.position = new Vector3(nuevoX, nuevoY, transform.position.z);
        }
        // Genera el movimiento de la bala a la velocidad indicada.
        else if (cosenoidal == true)
        {
            Quaternion q = Quaternion.Euler(0, 0, 50f);
            transform.rotation = q * transform.rotation;
            float nuevoX = transform.position.x + Velocidad.x * Time.deltaTime;
            float nuevoY = transform.position.y + Mathf.Sin(tiempo * frecuencia) * -amplitud;
            transform.position = new Vector3(nuevoX, nuevoY, transform.position.z);
        }
        else if (corte == true)
        {
            if(transform.position.x < 10 && dir== false) 
            {
                float nuevoY = transform.position.y + Velocidad.y * 2 * Time.deltaTime;
                float nuevoX = transform.position.x + 2 * Velocidad.x * Time.deltaTime;
                transform.position = new Vector3(nuevoX, nuevoY, transform.position.z);
            }
            else if (transform.position.x >= 10 && dir == false)
            {
                dir = true;
            }
            else if (transform.position.x > 4 && dir == true)
            {
                float nuevoY = transform.position.y + Velocidad.y * 2 * Time.deltaTime;
                float nuevoX = transform.position.x - (2 * Velocidad.x * Time.deltaTime);
                transform.position = new Vector3(nuevoX, nuevoY, transform.position.z);
            }
            else
            {
                dir = false;
            }
            
        }
        else
        {
            transform.position += (Vector3)Velocidad * Time.deltaTime;
        }
        // Cuenta el tiempo de la bala dentro del mapa para eliminarla.
        tiempo += Time.deltaTime;

        if (tiempo > TIEMPO_DE_ESTADIA)
            Desaparecer();
    }

    // Funcion para desaparecer la bala
    // void
    private void Desaparecer()
    {
        tiempo = 0f;
        gameObject.SetActive(false);
    }
}
