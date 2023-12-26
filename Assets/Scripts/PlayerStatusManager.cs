using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class StatusManager : MonoBehaviour
{
    private int MAXHEALTH = 10;
    private int health;
    private int exp = 10;

    public void SetMaxHealth(int maxHealth) { MAXHEALTH = maxHealth; }
    public int GetMaxHealth() { return MAXHEALTH; }

    public void Start() {
        health = MAXHEALTH;
    }

    public int CalHP(int healthDelta)
    { 
        health = health + healthDelta;
        if (health <= 0) {
            Destroy(gameObject);
        }
        return health;
    }

    public int GetHP()
    {
        return health;
    }

    public int CalExp(int expDelta)
    { 
        exp = exp + expDelta;
        Debug.Log($"Increase EXP:{exp}");

        return exp;
    }

    public int GetExp()
    {
        return exp;
    }

    void Update() {
        //Debug.Log(health);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Player");
        if (other.gameObject.name == "PlayerWrapper") { return; }

        if (other.gameObject.tag == "Color") { 
            Color selfColor = gameObject.GetComponent<SpriteRenderer>().color;
            Color otherColor = other.gameObject.GetComponent<SpriteRenderer>().color;

            if (selfColor == otherColor) {
                CalExp(1);
            } else { 
                CalHP(-1);
            }
        }


    }

    public void CollisionDetected(GameObject child) {
        Debug.Log(child.name);
        return; 
    }

}
