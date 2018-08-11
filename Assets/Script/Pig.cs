using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed = 10;
    public float minSpeed = 5;
    public SpriteRenderer render;
    public Sprite hurt;

    public GameObject boom;
    public GameObject score;
    public bool isPig;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude <= maxSpeed)
        {
            render.sprite = hurt;
        }
    }

    void Dead()
    {
        if(isPig)
        {
            GameManger._instance.pigs.Remove(this);
        }
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);

        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
}
