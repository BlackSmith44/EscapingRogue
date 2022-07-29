using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);
        Physics2D.IgnoreLayerCollision(9, 9, true);
        Physics2D.IgnoreLayerCollision(8, 0, true);
        Physics2D.IgnoreLayerCollision(9, 0, true);
        Physics2D.IgnoreLayerCollision(10, 10, true);
        Physics2D.IgnoreLayerCollision(10, 0, true);
        Physics2D.IgnoreLayerCollision(11, 10, true);
        //Physics2D.IgnoreLayerCollision(10, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
