using System;
using UnityEngine;

public class TileController : MonoBehaviour
{

    [SerializeField]
    GameObject airTile;

    [SerializeField]
    GameObject droppedItem;

    EntityManager entityManager;
    float miningTime;

    // Start is called before the first frame update
    void Start()
    {


        miningTime = 0;

        entityManager = GameObject.Find("Entities").GetComponent<EntityManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        TileLoader();
        
    }

    void TileLoader()
    {

        float dx = Mathf.Abs(entityManager.player.transform.position.x - gameObject.transform.position.x);
        float dy = Mathf.Abs(entityManager.player.transform.position.y - gameObject.transform.position.y);

        float d = Mathf.Sqrt(dx * dx + dy * dy);

        LoadOnDistance(d);

    }

    void LoadOnDistance(float dx)
    {

        if (dx > 25)
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;

        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;

        }

        LoadDimLeves(dx);

    }

    void LoadDimLeves(float dx)
    {

        if (dx < 5)
        {


            float mx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float my = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            DimOnHover(mx, my);

            OnPlayerInteract(mx, my);


        }

    }

    void DimOnHover(float mx, float my)
    {

        if (gameObject.GetComponent<Collider2D>().OverlapPoint(new Vector2(mx, my)))
        {

            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);

        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);


        }

    }

    void OnPlayerInteract(float mx, float my)
    {

        if (Input.GetMouseButton(0) && gameObject.GetComponent<Collider2D>().OverlapPoint(new Vector2(mx, my)))
        {

            MiningDimming(mx, my);

        }
        else if (miningTime > 0)
        {

            RepairMinedDimming();

        }

    }

    void MiningDimming(float mx, float my)
    {

        miningTime += Time.deltaTime;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1 - miningTime, 1, 1);

        MineTile(mx, my);

    }

    void RepairMinedDimming()
    {

        miningTime -= Time.deltaTime;

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1 - miningTime, 1, 1);

    }

    void MineTile(float mx, float my)
    {

        if (miningTime > 0.5f)
        {

            CheckForTiles(mx, my);

            SpawnMinedItem();

            SpawnAirTile();

        }


    }

    void CheckForTiles(float mx, float my)
    {

        int i = 0;

        foreach (Collider2D tile in Physics2D.OverlapPointAll(new Vector2(mx, my)))
        {

            i = BreakTile(i, tile, mx, my);

        }

    }

    int BreakTile(int index, Collider2D tile, float mx, float my)
    {

        if (tile.CompareTag("Tile"))
        {

            GameObject destroyThis;

            try
            {

                destroyThis = Physics2D.OverlapPointAll(new Vector2(mx, my))[index].gameObject;

            }
            catch (IndexOutOfRangeException)
            {

                destroyThis = Physics2D.OverlapPointAll(new Vector2(mx, my))[index - 1].gameObject;

            }

            Destroy(destroyThis);

        }


        index++;
        return index;


    }

    void SpawnMinedItem()
    {

        GameObject drop = Instantiate(droppedItem);
        drop.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        drop.transform.position = gameObject.transform.position;
        drop.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(
                entityManager.player.transform.position.x - gameObject.transform.position.x,
                entityManager.player.transform.position.y - gameObject.transform.position.y).normalized * 200);

    }

    void SpawnAirTile()
    {

        GameObject obj = Instantiate(airTile);

        obj.transform.position = gameObject.transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(GameObject.FindWithTag("Ground").transform, true);
        obj.GetComponent<SpriteRenderer>().enabled = false;
        obj.GetComponent<BoxCollider2D>().enabled = true;
        obj.GetComponent<BoxCollider2D>().isTrigger = true;


    }

}
