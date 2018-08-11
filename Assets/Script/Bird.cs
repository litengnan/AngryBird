using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isClick = false;
    public float maxDis = 3;
    [HideInInspector]
    public SpringJoint2D sp;
    private Rigidbody2D rg;

    public LineRenderer right;
    public Transform rightPos;
    public LineRenderer left;
    public Transform leftPos;

    public GameObject boom;
    private TestMyTrail trail;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        trail = GetComponent<TestMyTrail>();
    }

    private void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);

        //禁用画线组件
        right.enabled = false;
        left.enabled = false;
    }

    private void Update()
    {
        if(isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if(Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }

            Line();
        }
    }

    void Fly()
    {
        sp.enabled = false;
        Invoke("Next",5);

        trail.StartTrails();
    }

    void Line()
    {
        right.enabled = true;
        left.enabled = true;

        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    void Next()
    {
        GameManger._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManger._instance.NextBirds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trail.ClearTrails();
    }
}
