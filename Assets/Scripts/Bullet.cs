using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5.0f;
    public int damage = 1;


    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

   
    void OnTriggerEnter(Collider other)
    {
        ReactiveTarget Enemy = other.GetComponent<ReactiveTarget>();
        if (Enemy != null)
        {
            Enemy.ReactToHit(damage);
        }

        Destroy(this.gameObject);
    }


    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(4);

        Destroy(this.gameObject);
    }
}
