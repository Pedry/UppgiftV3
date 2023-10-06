using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float time;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, Vector2.up.y * 5);

        }

    }
    private void FixedUpdate()
    {



        if (Input.GetKey(KeyCode.D))
        {

            if (time < 0.2)
            {

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.right.x * time * 25, gameObject.GetComponent<Rigidbody2D>().velocity.y);

                time += Time.fixedDeltaTime;

            }

        }
        if (Input.GetKey(KeyCode.A))
        {

            if (time < 0.2)
            {

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.left.x * time * 25, gameObject.GetComponent<Rigidbody2D>().velocity.y);

                time += Time.fixedDeltaTime;

            }


        }

        if(time < 0)
        {

            time = 0;

        }

        if (time > 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || time > 0.2)
        {

            time -= Time.fixedDeltaTime;

        }

    }
}
