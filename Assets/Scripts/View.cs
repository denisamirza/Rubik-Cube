using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            transform.Rotate(10, 0, 0);
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
            transform.Rotate(-10, 0, 0);
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0, -10, 0);
        if(Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0, 10, 0);
    }
}
