using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject surveyCorps;
    public GameObject location;
    public bool hasEscaped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEscaped)
        {
            try
            {
                Destroy(surveyCorps);
                hasEscaped = true;
            }
            catch
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            surveyCorps.transform.position = location.transform.position;
            hasEscaped = false;
        }

    }
}
