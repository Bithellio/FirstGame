using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes Axes = RotationAxes.MouseXAndY;
    public float SensitivityHor = 9.0f;
    public float SensitivityVer = 9.0f;


    public float MinimumVer = -45.0f;
    public float MaximumVer = 45.0f;

    private float _rotationX = 0; 



    // Start is called before the first frame update
    void Start()
    {
        var body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, MinimumVer, MaximumVer);


            float delta = Input.GetAxis("Mouse X") * SensitivityHor;

            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else if (Axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, MinimumVer, MaximumVer);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX,rotationY,0);
        }
        else if (Axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*SensitivityHor,0);
        }
    }
}
