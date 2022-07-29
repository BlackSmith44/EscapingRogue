using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargeting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targeting;
    private Vector3 target;

    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - targeting.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg -90f;
        targeting.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}
