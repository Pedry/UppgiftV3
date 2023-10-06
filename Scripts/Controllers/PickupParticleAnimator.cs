using UnityEngine;
using UnityEngine.U2D.Animation;

public class PickupParticleAnimator : MonoBehaviour
{

    float time;

    SpriteRenderer sr;

    int i;

    // Start is called before the first frame update
    void Start()
    {

        time = 0;

        sr = GetComponent<SpriteRenderer>();

        i = 0;

        sr.sprite = gameObject.GetComponent<SpriteLibrary>().GetSprite("ItemPickupParticles", "ItemPickupParticle_" + 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (time > 0.008)
        {


            if (gameObject.GetComponent<SpriteLibrary>().GetSprite("ItemPickupParticles", "ItemPickupParticle_" + i) == null)
            {

                Destroy(gameObject);

            }
            else
            {

                sr.sprite = gameObject.GetComponent<SpriteLibrary>().GetSprite("ItemPickupParticles", "ItemPickupParticle_" + i);

            }

            i++;
            time = 0;

        }


        time += Time.deltaTime;
        
    }
}
