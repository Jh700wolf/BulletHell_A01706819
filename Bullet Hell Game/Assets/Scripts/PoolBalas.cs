using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    private static PoolBalas instance;

    public static PoolBalas Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("No hay Instance para PoolBalas");
            }
            return instance;
        }
    }
    //Prefab de las balas
    [SerializeField] private BalaScript prefabBala;
    //Total de Balas
    [SerializeField] private int numBalas = 15;


    // Lista con los objetos de balas
    private List<BalaScript> poolBala = new List<BalaScript>();

    private void Awake()
    {
        // Se gene
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        // Se generan las balas iniciales
        AñadirBalaAPool(numBalas);
    }

    private void AñadirBalaAPool(int num)
    {
        for (int i = 0; i < num; i++)
        {
            BalaScript bala = Instantiate(prefabBala);
            bala.gameObject.SetActive(false);
            poolBala.Add(bala);
            bala.transform.parent = transform;
        }

    }

    public BalaScript RequestBala()
    {
        for (int i = 0;i < poolBala.Count;i++)
        {
            if (!poolBala[i].gameObject.activeSelf)
            {
                poolBala[i].gameObject.SetActive(true);
                return poolBala[i];
            }
        }
        AñadirBalaAPool(1);
        poolBala[poolBala.Count -1].gameObject.SetActive(true);
        return poolBala[poolBala.Count - 1];
    }

}
