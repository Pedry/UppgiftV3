using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{

    EntityManager entityManager;

    // Start is called before the first frame update
    void Start()
    {
        
        entityManager = GameObject.Find("Entities").GetComponent<EntityManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float x = Mathf.Abs(entityManager.player.transform.position.x - gameObject.transform.position.x);
        float y = Mathf.Abs(entityManager.player.transform.position.y - gameObject.transform.position.y);

        float d = Mathf.Sqrt(x * x + y * y);

        if(d > 20)
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = true;

        }


        
    }
}
