using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurveyCorps2 : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool escape = false;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(1, 501) == 6)
            {
                Vector3 v = player.transform.position;
                v.x += 5;
                v.y += 2;
                transform.position = v;
                isMoving = true;
                player.GetComponent<Movement>().stuck = true;
            }
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
