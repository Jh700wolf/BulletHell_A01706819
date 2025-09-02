using UnityEngine;
using System;
using static UnityEngine.Rendering.STP;

public class AtaquesBoss : MonoBehaviour
{
    public static void DisparoBasicoBoss(Vector2 origen, Vector2 velocidad)
    {
        BalaScript bala = PoolBalasBoss.Instance.RequestBala();
        bala.transform.position = origen;
        bala.Velocidad = velocidad;
    }


    public static void DisparoBasico2(Vector2 origen, Vector2 velocidad)
    {
        BalaScript bala = PoolBalasBoss.Instance.RequestBala();
        bala.transform.position = origen;
        bala.Velocidad = velocidad;
        bala.corte = true;


    }

    public static void DisparoSenoidalBoss(Vector2 origen, Vector2 velocidad, bool senoidal = true)
    {
        BalaScript bala = PoolBalasBoss.Instance.RequestBala();
        bala.transform.position = origen;
        bala.Velocidad = velocidad;
        bala.senoidal = senoidal;
    }


    public static void DisparoRadial(Vector2 origen, Vector2 direccion, DisparoBossSettings config)
    {
        float anguloDisparos = 360f / config.numBalasAtaqueA;

        for (int i = 0; i < config.numBalasAtaqueA; i++)
        {
            float anguloBala = anguloDisparos * i;
            Vector2 direccionBala = direccion.Rotate(anguloBala);
            DisparoBasicoBoss(origen, direccionBala * config.velocidadBalasAtaqueA);

        }
    }

    public static void DisparoDiagonales(Vector2 origen, Vector2 direccion, DisparoBossSettings config)
    {
        float anguloDisparos = 360f / config.numBalasAtaqueA;
        for (int i = 0; i < config.numBalasAtaqueB; i++)
        {
            float anguloBala = anguloDisparos * i;
            Vector2 direccionBala = direccion.Rotate(anguloBala);
            float velocidadMod = (float)Math.Sin(config.velocidadBalasAtaqueA);
            direccionBala.x *= velocidadMod;
            DisparoSenoidalBoss(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x + 2;
            DisparoSenoidalBoss(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x - 4;
            DisparoSenoidalBoss(origen, direccionBala * config.velocidadBalasAtaqueA);


        }

    }

    public static void DisparoZig(Vector2 origen, Vector2 direccion, DisparoBossSettings config)
    {

            Vector2 direccionBala = direccion.Rotate(0);
            
            DisparoBasico2(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x + 2;
            origen.y = origen.y + 1;
            DisparoBasico2(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x + 2;
            origen.y = origen.y + 1;
            DisparoBasico2(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x - 6;
            origen.y = origen.y - 1;
            DisparoBasico2(origen, direccionBala * config.velocidadBalasAtaqueA);
            origen.x = origen.x - 2;
            origen.y = origen.y + 1;

      

    }
}

