using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooling 
{
    [SerializeField]
    private GameObject projectilePrefab = null;
    static private ObjectPooling Instance = null;
    public int length = 10;
    private Projectile[] gamePooling = null;

    public ObjectPooling()
    {
        Instance = this;        
    }

    public void OnStart()
    {
        gamePooling = new Projectile[length];
        for (int i = 0; i < length; i++)
        {
            GameObject projectile = GameObject.Instantiate<GameObject>(projectilePrefab);
            gamePooling[i] = projectile.GetComponent<Projectile>();
            gamePooling[i].gameObject.SetActive(false);
        }
    }

    public static Projectile GetProjectile()
    {
        if (Instance.gamePooling == null)
            return null;
        for (int i = 0; i < Instance.length; i++)
        {
            if(Instance.gamePooling[i].gameObject.activeSelf == false)
            {
                Instance.gamePooling[i].gameObject.SetActive(true);
                return Instance.gamePooling[i];
            }
        }

            return null;
    }

    public static void ReturnProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

}