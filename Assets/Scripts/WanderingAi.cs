using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAi : MonoBehaviour
{

    [SerializeField] private GameObject FireBallPrefab;

    private GameObject _fireBall;

    public float Speed = 3.0f;

    public float ObstacleRange = 5.0f;

    private bool _alive;



    void Start()
    {
        _alive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        var ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireBall == null)
                {
                    _fireBall = Instantiate(FireBallPrefab) as GameObject;
                    _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireBall.transform.rotation = transform.rotation;
                }
            }

            else if (hit.distance < ObstacleRange)
            {
                var angle = Random.Range(-110, 110); 

                transform.Rotate(0,angle,0);
            }
        }

    }


    public void SetAlive(bool state)
    {
        _alive = state;
    }
}
