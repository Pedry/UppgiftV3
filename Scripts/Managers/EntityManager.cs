using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    GameObject camera;

    public GameObject player;

    [SerializeField]
    GroundGeneration gg;

    // Start is called before the first frame update
    void Start()
    {

        player = Instantiate(playerPrefab);
        player.transform.SetParent(transform, false);
        player.transform.position = Vector2.zero;
        player.name = "Player";

        gg.SetPlayer(player);

        camera.transform.SetParent(player.transform, false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
