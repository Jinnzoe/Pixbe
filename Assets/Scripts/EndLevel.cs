using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpened;
    private GameManager gameManager;
    private BoxCollider2D box;

    public bool finalLevel;

    // Start is called before the first frame update
    void Start()
    {
        doorOpened.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        box = GetComponent<BoxCollider2D>();
    }

    public void OpenDoor()
    {
        doorClosed.SetActive(false);
        doorOpened.SetActive(true);
        box.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.NextLevel(finalLevel);
        }
    }
}
