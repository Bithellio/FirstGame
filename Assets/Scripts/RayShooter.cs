using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;

    
    private Camera _camera;


    // Start is called before the first frame update
    void Start()
    {        
        _camera = GetComponent<Camera>();        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false; 
    }

    void OnGUI()
    {
        var size = 12;
        var posx = _camera.pixelWidth / 2 - size / 4;
        var posy = _camera.pixelHeight / 2 - size / 2;  
        GUI.Label(new Rect(posx,posy,size,size),"*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            var ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {


                GameObject bullet;
                    bullet = Instantiate(BulletPrefab) as GameObject;
                    bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    bullet.transform.rotation = transform.rotation; 
                }
               

                   // StartCoroutine(SphereIndicator(hit.point));
                

            
        }
    }


    private IEnumerator SphereIndicator(Vector3 point)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;

        yield return new WaitForSeconds(1);
        
        Destroy(sphere);
    }
}

