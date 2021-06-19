using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float Lifetime;
    IEnumerator Deathdelay()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
      
    }

    void Start()
    {
        StartCoroutine(Deathdelay());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
    }

}
