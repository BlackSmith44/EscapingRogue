using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject myParent;
    private TesterScript testerScript;

    

    void Start()
    {
         testerScript = myParent.GetComponent<TesterScript>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.name == "Player")
        {
            testerScript.trigged = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            testerScript.trigged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            testerScript.trigged = false;
        }
    }


}
