using UnityEngine;

public class BossAtaques : MonoBehaviour
{
    [SerializeField] private float cooldownDisparo;
    [SerializeField] private DisparoBossSettings settings;

    public float timerBossFases = 0f;
    private float timerCooldown = 0f;
    private void Update()
    {

        if (timerBossFases > 20f)
        {
            if (timerCooldown < 0f)
            {
                AtaquesBoss.DisparoRadial(transform.position, transform.up, settings);
                timerCooldown += cooldownDisparo;
            }
        }
        else if (timerBossFases > 10f)
        {
            if (timerCooldown < 0f)
            {
                AtaquesBoss.DisparoZig(transform.position, transform.up, settings);
                timerCooldown += cooldownDisparo;
            }
        }
        else
        {
            if (timerCooldown < 0f)
            {
                AtaquesBoss.DisparoSenoCombo(transform.position, transform.up, settings);
                timerCooldown += cooldownDisparo;
            }
        }

        timerCooldown -= Time.deltaTime;
        timerBossFases -= Time.deltaTime;

    }
}
