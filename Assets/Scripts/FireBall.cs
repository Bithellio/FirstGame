using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float Speed = 10.0f;
    public int Damage = 1; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(Damage);
            Debug.Log("DIRECT HIT !");
        }

        Destroy(this.gameObject);
    }
}
