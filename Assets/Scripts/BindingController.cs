using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BindingController : MonoBehaviour
{
    public GameObject playerRef;
    public GameObject MeteorManager;
    public Image DashCoolDownFilter;

    KeyCode keyDash = KeyCode.E;
    KeyCode keyMagnet = KeyCode.Q;

    Dash dash;
    SkillMeteor skillMeteor;
    /*
        void Start() {
            //Extract necessary method script
            dash = gameObject.AddComponent<Dash>();
            dash.SetUp(playerRef: playerRef, second_SkillDuration: 0.2f, second_SkillCoolDown: 3f, dashMultiplier: 20f, coolDownFilter: DashCoolDownFilter);

            skillMeteor = gameObject.AddComponent<SkillMeteor>();
            skillMeteor.SetUp(playerRef: playerRef, second_SkillDuration: 2f, second_SkillCoolDown: 3f, speedMultiplier: 0.1f);
        }
    */
    private void Start()
    {
        dash = GetComponent<Dash>();
        skillMeteor = GetComponent<SkillMeteor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyDash))
        {
            dash.UseSkill(blockControl: true);
            DashCoolDownFilter.fillAmount = 0f;
            
        }

        else if (Input.GetKey(keyMagnet)) {
            skillMeteor.UseSkill(blockControl: false);
        }
        
    }
}
