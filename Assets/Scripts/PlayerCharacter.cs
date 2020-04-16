using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    [SerializeField] private int StartingHealth = 5;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _health = StartingHealth;
    }
    

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
