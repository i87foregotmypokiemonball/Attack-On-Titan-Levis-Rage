using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    public LineRenderer line;
    public float step = 0.4f;
    DistanceJoint2D joint;
    RaycastHit2D hit;
    public float distance = 8f;
    public LayerMask mask;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (joint.distance > 1f)
        {
            joint.distance -= step;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            print(hit.point);
            if (hit.collider && hit.collider.gameObject.GetComponent<Rigidbody2D>())
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y /= hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            line.SetPosition(0, transform.position);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
}
