using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] private float cooldownDisparo;
    [SerializeField] private float velocidadBala;

    private float timerCooldown = 0f;
    private void Update()
    {
        timerCooldown -= Time.deltaTime;
        if (timerCooldown < 0f)
        {
            AtaqueBasico.DisparoBasico(transform.position, transform.up * velocidadBala);
            timerCooldown += cooldownDisparo;
        }
    }

}
  