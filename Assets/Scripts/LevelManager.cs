using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject MeteorManager;
    public GameObject Player;
    public GameObject BindingController;
    int SECOND_ROUNDTIMER = 30;
    int second_Timer = 0;

    int level = 0;

    public MeteorSpawner meteorSpawner; 
    //public PlayerStatusManager playerStatusManager; 

    // Start is called before the first frame update
    void Start()
    {
        meteorSpawner = MeteorManager.GetComponent<MeteorSpawner>();
        //playerStatusManager = Player.GetComponent<PlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        second_Timer++;

        //Round ended
        if (second_Timer == SECOND_ROUNDTIMER) {
            second_Timer = 0;
            meteorSpawner.PauseSpawn();
            level++;

            List<GameObject> meteorList = meteorSpawner.meteorList;
            //Cleanup Meteors
            for (int i = 0; i < meteorList.Count; i++) {
                if (meteorList[i] != null) { 
                    Destroy(meteorList[i]);
                }
            }

            // playerStatusManager.SetMaxHealth(++Player.GetMaxHealth());

        

        }
    }

}
