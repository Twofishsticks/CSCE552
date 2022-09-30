using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEraser : MonoBehaviour
{
    public GameObject eraser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eraser == null)
        return;
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newEraser = Instantiate(eraser, transform.position, Quaternion.identity);
        }
    }
}
