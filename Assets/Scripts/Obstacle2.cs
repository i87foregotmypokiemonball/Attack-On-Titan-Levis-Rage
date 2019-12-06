using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    public GameObject surveyCorps;
    public GameObject surveyCorps2; 
    public GameObject location;
    public bool hasEscaped = false;
    // Start is called before the first frame update
    void Start()
    {
        surveyCorps2 = FindObjectOfType<SurveyCorps2>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEscaped)
        {
            hasEscaped = true;
            Destroy(surveyCorps);
            if (surveyCorps2)
            {
                surveyCorps2.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject copy = Instantiate(surveyCorps, location.transform.position, Quaternion.identity) as GameObject;
            collision.GetComponent<Movement>().newPursuer = copy;
            hasEscaped = false;
        }

    }
}

