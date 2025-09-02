using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PoolBalasBoss : MonoBehaviour
{
    private static PoolBalasBoss instance;

    public static PoolBalasBoss Instance
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
    [SerializeField] private int numBalas = 50;

    [SerializeField] private BalaScript2 prefabBala2;


    // Lista con los objetos de balas
    public List<BalaScript> poolBalaBoss = new List<BalaScript>();
    private List<BalaScript2> poolBalaBoss2 = new List<BalaScript2>();

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
            poolBalaBoss.Add(bala);
            bala.transform.parent = transform;
        }

    }

    public BalaScript RequestBala()
    {
        for (int i = 0; i < poolBalaBoss.Count; i++)
        {
            if (!poolBalaBoss[i].gameObject.activeSelf)
            {
                poolBalaBoss[i].gameObject.SetActive(true);
                return poolBalaBoss[i];
            }
        }
        AñadirBalaAPool(1);
        poolBalaBoss[poolBalaBoss.Count - 1].gameObject.SetActive(true);
        return poolBalaBoss[poolBalaBoss.Count - 1];
    }


}
