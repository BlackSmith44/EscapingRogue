using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private SpriteRenderer sprite;
    private GameObject Player;

    public Vector2 TargetPos;
    public Vector2 currPos;
    public Vector2 PlayerPos;
    public Vector2 direction;

    private float speed = 2.5f;

    public float movetimer;
    public float waittimer;

    public bool imMoving;
    public bool imWaiting;
    public bool imHit;
    public bool trigged;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 12, true);
        rb = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        PlayerPos = Player.transform.position;
        currPos = transform.position;
        

        if(imHit)
        {
            trigged = false;
        }
        
        if (!imWaiting && !trigged)
        {
            if (imMoving)
            {
                zerosVeliocity();
                TargetPos = new Vector2(transform.position.x + Random.Range(-20, 20), transform.position.y + Random.Range(-20, 20));
                flyaway(currPos, TargetPos);
                movetimer = Random.Range(0.5f, 3);
                imMoving = false;
            }
            if (movetimer >= 0)
            {
                movetimer -= Time.deltaTime;
            }
            else
            {
                zerosVeliocity();
                imWaiting = true;
                waittimer = Random.Range(0.5f, 3);
            }

            if (imHit)
            {
                zerosVeliocity();
                imMoving = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                imWaiting = true;
                waittimer = 1;
            }

        }
        
        else 
        {
            if (waittimer >=0 )
            {
                waittimer -= Time.deltaTime;
            }
            else
            {
                imWaiting = false;
                imHit = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                imMoving = true;
            }
           
        }

        

        if (trigged && !imHit)
        {
            PlayerPos = Player.transform.position;
            Activate(currPos, PlayerPos);
        }
        if(!trigged)
        {
            sprite.color = new Color(0, 120, 8, 255);
        }
    }

    public void flyaway( Vector2 start, Vector2 end)
    {
        direction = end - start;
        direction = Vector3.Normalize(direction);
        rb.AddForce((direction) * (speed), ForceMode2D.Impulse);
        
    }

    public void zerosVeliocity()
    {
        rb.velocity = Vector3.zero;
    }

    private void Activate (Vector2 currPos, Vector2 playerPos)
    {
        zerosVeliocity();
        sprite.color = new Color(120, 0, 6, 255);
        flyaway(currPos, playerPos);
    }


}
