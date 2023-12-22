using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject playerRef; 
    public int impulseMultiplier;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            Rigidbody2D rg = GetComponent<Rigidbody2D>();

            rg.velocity = new Vector2(playerRef.transform.localScale.x * 30f, 0f);
        }
        
    }

    public void StartDash() {
    }
}
