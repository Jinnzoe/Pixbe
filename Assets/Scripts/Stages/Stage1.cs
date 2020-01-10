using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public PlayerController playerController;
    public GameObject[] objToDestroy;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && playerRb.bodyType != RigidbodyType2D.Dynamic)
        {
            playerController.canMove = false;
            playerRb.bodyType = RigidbodyType2D.Dynamic;
            for (int i = 0; i < objToDestroy.Length; i++)
            {
                DestroyGO(objToDestroy[i], 2);
            }
        }
    }

    void DestroyGO(GameObject @object, float time)
    {
        Destroy(@object, time);
    }
}
