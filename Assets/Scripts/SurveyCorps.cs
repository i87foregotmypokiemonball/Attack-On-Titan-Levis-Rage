using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurveyCorps : MonoBehaviour
{
    public GameObject player;
    public GameObject surveyCorps2;
    public float speed;
    public bool escape = false;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
        surveyCorps2 = FindObjectOfType<SurveyCorps2>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (surveyCorps2)
        {
            surveyCorps2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
