using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject grapple;
    public GameObject str;
    public GameObject obstacle;
    public GameObject surveyCorps2;
    [HideInInspector]
    public GameObject newPursuer;
    public float speed = 15f;
    public float jumpStrength = 10f;
    bool touchingFloor = true;
    bool rotating = false;
    float rotation = 0;
    Vector3 initialLength;
    float initialPosition;
    public float strLength = 3f;
    [HideInInspector]
    public bool stuck = false;

    // Start is called before the first frame update
    void Start()
    {
        initialLength = new Vector3(4.952652f, 4.952652f, 9f);
        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !rotating && stuck)
        {
            rotating = true;
            if (newPursuer)
                Destroy(newPursuer);
            if (stuck)
            {
                obstacle.GetComponent<Obstacle>().hasEscaped = true;
                if (surveyCorps2 && surveyCorps2.activeSelf)
                    Destroy(surveyCorps2);
                else
                    surveyCorps2.SetActive(true);

            }
            stuck = false;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && !stuck)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }   
        else if(Input.GetKey(KeyCode.UpArrow) && touchingFloor && !stuck)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpStrength);
            touchingFloor = false;
        }
        if(rotating)
        {
            Rotate();
        }

    }


    void Rotate()
    {
        rotation += 10f;
        transform.Rotate(0, 0, 10f);
        if (rotation >= 360)
        {
            rotating = false;
            rotation = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingFloor = true;
        if (collision.tag == "Obstacle")
        {
            stuck = true;
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
