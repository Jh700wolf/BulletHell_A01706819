using UnityEngine;

public class AtaqueBasico
{
    public static void DisparoBasico(Vector2 origen, Vector2 velocidad)
    {
        BalaScript bala = PoolBalas.Instance.RequestBala();
        bala.transform.position = origen;
        bala.Velocidad = velocidad;
    }

}
