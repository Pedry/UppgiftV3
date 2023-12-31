using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{


    [SerializeField]
    GameObject groundTile;

    [SerializeField]
    GameObject grassTile;


    GameObject player;

    List<GameObject> tiles;

    Vector2 worldCenter;

    // Start is called before the first frame update
    void Start()
    {

        tiles = new List<GameObject>();

        worldCenter = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        CheckRange(new Vector2(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y)));
        
    }

    void CheckRange(Vector2 pos)
    {

        List<Vector2> checks = new List<Vector2>();

        int radius = 20; 
        int centerX = 0; 
        int centerY = 0; 

        int numberOfPoints = 360; 

        for (int i = 0; i < numberOfPoints; i++)
        {
            double angle = 2 * Math.PI * i / numberOfPoints; 

            int x = (int)(centerX + radius * Math.Cos(angle));
            int y = (int)(centerY + radius * Math.Sin(angle));

            if(!checks.Contains(new Vector2(pos.x + x, pos.y + y)))
            {

                checks.Add(new Vector2(pos.x + x, pos.y + y));


            }


        }

        foreach (Vector2 point in checks)
        {




                Collider2D[] colliders = Physics2D.OverlapPointAll(point);

                if (colliders.Length == 0)
                {

                    GenerateTileRadi(point);
                    GenerateTileVerti(point);

                }


        }


    }

    

    void GenerateTileVerti(Vector2 pos)
    {

        float cordOffset = 1000;

        float tileOffsetY = Mathf.PerlinNoise1D((pos.x + cordOffset) / 10) * 10;

        if(pos.y >= 0)
        {

            for (float i = tileOffsetY; i > -tileOffsetY; i--)
            {

                if(i == tileOffsetY)
                {

                    if (Physics2D.OverlapPointAll(new Vector2(pos.x, Mathf.RoundToInt(i))).Length == 0)
                    {

                        GameObject temp = Instantiate(grassTile);
                        tiles.Add(temp);
                        temp.transform.position = new Vector2(pos.x, Mathf.RoundToInt(i));
                        temp.transform.parent = gameObject.GetComponentInChildren<Transform>().gameObject.transform;

                    }
                    else
                    {

                        break;

                    }

                }
                else
                {

                    if (Physics2D.OverlapPointAll(new Vector2(pos.x, Mathf.RoundToInt(i))).Length == 0)
                    {

                        GameObject temp = Instantiate(groundTile);
                        tiles.Add(temp);
                        temp.transform.position = new Vector2(pos.x, Mathf.RoundToInt(i));
                        temp.transform.parent = gameObject.GetComponentInChildren<Transform>().gameObject.transform;

                    }
                    else
                    {

                        break;

                    }

                }


            }

        }

    }
    void GenerateTileRadi(Vector2 pos)
    {

        float cordOffset = 1000;

        if(Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y)).Length == 0)
        {


            if (pos.y < worldCenter.y && Mathf.PerlinNoise((pos.x + cordOffset) / 10, (pos.y + cordOffset) / 10) < 0.5f)
            {


                GameObject temp = Instantiate(groundTile);
                tiles.Add(temp);
                temp.transform.position = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt( pos.y));
                temp.transform.parent = gameObject.GetComponentInChildren<Transform>().gameObject.transform;


            }

        }

    }


    public void SetPlayer(GameObject instance)
    {
        player = instance;
    }

}
