using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    public float timeToDestroy;
    public ParticleSystem destroyFx;
    SpriteRenderer sprite;

    bool destroying;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") && !destroying)
        {
            destroying = true;
            StartCoroutine(DestroyPlatform());
        }
    }

    private void Update()
    {
        if(destroying)
        {
            var a = sprite.color;
            a.a -= timeToDestroy * .003f;
            sprite.color = a;
        }
    }

    IEnumerator DestroyPlatform()
    {
        destroyFx.startLifetime = timeToDestroy;
        destroyFx.Play();
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
