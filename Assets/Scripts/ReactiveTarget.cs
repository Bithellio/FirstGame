using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private int StartingHealth = 5;
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = StartingHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit(int damage)
    {
        _health -= damage;
        if (_health == 0)
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
