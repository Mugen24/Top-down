using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShieldStatusManager : MonoBehaviour
{
    static int DEFAULT_HEALTH = 3;
    int health = DEFAULT_HEALTH;
    public GameObject playerRef;

    //Saves original scaling to initialse later
    Vector3 _originalLocalScale;


    //Takes care of de-initialising Object depending on SetActive 
    void toggleActiveCleanUp(Vector3 scale) {
        if (gameObject.activeSelf)
        {
            health = DEFAULT_HEALTH;
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.transform.localScale = scale;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else { 
            gameObject.GetComponent<Collider2D>().enabled = false;
            //Hides gameObject from viewport
            gameObject.transform.localScale = new Vector3(0, 0, 0);

            //DISABLE YOUR SCRIPT HERE
        }
        
    }

    async void _Timer(bool visibility, int miliseconds) {
        await Task.Delay(miliseconds);
        gameObject.SetActive(visibility);
        toggleActiveCleanUp(_originalLocalScale);

    }

    public int CalHP(int deltaHP) { 
        health = health + deltaHP;

        if (health <= 0) {
            gameObject.SetActive(false);
            toggleActiveCleanUp(_originalLocalScale);
            _Timer(true, 5000);
        }

        return health;
    }

    public int returnHP() { return health; }

    // Start is called before the first frame update
    void Start()
    {
         _originalLocalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Shield");
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Shield Collided");
        Debug.Log(col.gameObject.name);
        CalHP(-1);
        
        playerRef.GetComponent<StatusManager>().CollisionDetected(gameObject);
    }
}
