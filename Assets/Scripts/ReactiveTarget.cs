using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public int health = 3 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit()
    {
        health--;
        if (health == 0)
        {
            var behaviour = GetComponent<WanderingAi>();
            if (behaviour != null)
            {
                behaviour.SetAlive(false);
            }
            StartCoroutine(Die());
        }
        
            
        
    }

    private IEnumerator Die()
    {
        
        this.transform.Rotate(-75,0,0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
