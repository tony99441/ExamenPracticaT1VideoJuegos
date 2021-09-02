using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform PlayerTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = PlayerTransform.position.x + 3f; 
        var y = PlayerTransform.position.y + 1f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
