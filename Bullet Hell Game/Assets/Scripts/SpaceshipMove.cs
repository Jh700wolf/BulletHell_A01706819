using System;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpaceshipMove : MonoBehaviour
{
    public float velocidad = 5.0f;

    public float horizontalInput;
    public float verticalInput;

    private float xMax, xMin, yMax, yMin;

    void Start()
    {
        var camara = Camera.main;
        var hCamara = camara.orthographicSize;
        var wCamara = camara.orthographicSize*camara.aspect;

        var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * .5f;

        yMin = -hCamara + spriteSize; // 
        yMax = hCamara - spriteSize; 

        xMin = -wCamara + spriteSize; 
        xMax = wCamara - spriteSize;


    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        var direccion = new Vector2(horizontalInput, verticalInput).normalized;
        direccion *= velocidad * Time.deltaTime;

        var xValida = Mathf.Clamp(transform.position.x + direccion.x, xMin, xMax);
        var yValida = Mathf.Clamp(transform.position.y + direccion.y, yMin, yMax);

        transform.position = new Vector3(xValida, yValida, 0f);

    }
}
