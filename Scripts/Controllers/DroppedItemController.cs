using UnityEngine;

public class DroppedItemController : MonoBehaviour
{

    SpriteRenderer sr;

    [SerializeField]
    GameObject particle;

    EntityManager entityManager;

    float time;

    // Start is called before the first frame update
    void Start()
    {

        time = 0;
        sr = GetComponent<SpriteRenderer>();

        entityManager = GameObject.Find("Entities").GetComponent<EntityManager>();

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        sr.color = new Color(Mathf.Abs((Mathf.PerlinNoise1D(time)/2) + 0.5f), Mathf.Abs((Mathf.PerlinNoise1D(time)/2) + 0.5f), Mathf.Abs((Mathf.PerlinNoise1D(time)/2) + 0.5f));

        Magnetism();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.name.Equals("Player"))
        {

            SpawnPickupParticle();

        }

    }

    void SpawnPickupParticle()
    {

        GameObject p = Instantiate(particle);
        p.transform.position = gameObject.transform.position;

        Destroy(gameObject);

    }

    void Magnetism()
    {

        float dx = entityManager.player.transform.position.x - gameObject.transform.position.x;
        float dy = entityManager.player.transform.position.y - gameObject.transform.position.y;

        float d = Mathf.Sqrt(dx * dx + dy * dy);


        if (d < 2)
        {

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dx, dy).normalized/(d*d) * 10);

        }
        else
        {

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        }


    }

}
