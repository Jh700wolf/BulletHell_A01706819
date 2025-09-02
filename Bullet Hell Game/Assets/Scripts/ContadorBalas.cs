using UnityEngine;
using TMPro;

public class ContadorBalas : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textoBalas;


    // Update is called once per frame
    void Update()
    {
        int balas = 0;
        foreach (var bala in PoolBalasBoss.Instance.poolBalaBoss)
        {
            if (bala.gameObject.activeSelf)
                balas++;
        }
        textoBalas.text = $"Balas activas: {balas}\n";
    }
}
