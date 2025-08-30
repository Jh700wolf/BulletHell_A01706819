using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float posXMax = 0f;
    public float posXMin = 0f;
    public Vector2 velocidadBoss;
    public Vector2 velocidadBossRetro;
    private bool direccionIzq = false;
    public float timerCooldownMovement = 0f;


    void Update()
    {
        if (timerCooldownMovement < 0f)
        {
            if (transform.position.y < 4f)
            {
                transform.position += (Vector3)velocidadBossRetro * Time.deltaTime;
            }

            if (transform.position.x < posXMax && direccionIzq == false)
            {
                transform.position += (Vector3)velocidadBoss * Time.deltaTime;
            }
            else if (transform.position.x >= posXMax && direccionIzq == false)
            {
                direccionIzq = true;
            }
            else if (transform.position.x > posXMin && direccionIzq == true)
            {
                transform.position -= (Vector3)velocidadBoss * Time.deltaTime;
            }
            else if (transform.position.x <= posXMin && direccionIzq == true)
            {
                direccionIzq = false;

            }
        }
        else
        {

            transform.Rotate(0,0,velocidadBoss.x* Time.deltaTime*18/5);
        }
        timerCooldownMovement -= Time.deltaTime;
    }
}
