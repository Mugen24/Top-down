using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Dash : Skill
{
    public Image dashImage; //Don't really need this
    public Image coolDownFilter;
    public float dashMultiplier = 20;

/*
    public void SetUp(GameObject playerRef, float second_SkillDuration, float second_SkillCoolDown, float dashMultiplier, Image coolDownFilter) { 
        this.dashMultiplier = dashMultiplier;
        this.coolDownFilter = coolDownFilter;
        base.SetUp(playerRef, second_SkillDuration, second_SkillCoolDown);
        coolDownFilter.fillAmount = 1f;
    }
*/

    public override void Activate() {
        Rigidbody2D rb = base.playerRef.GetComponent<Rigidbody2D>();
        rb.velocity = base.playerRef.transform.up * dashMultiplier;
        coolDownFilter.fillAmount = 0f;
    }


    public override void Before() { 
        playerRef.GetComponent<PlayerMovement>().blockControl = true;
        coolDownFilter.fillAmount = 0f;
    }
    public override void After() { 
        playerRef.GetComponent<PlayerMovement>().blockControl = false;

        Rigidbody2D rb = playerRef.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    public override void DuringCoolDown(float currTimer, float skillCoolDown)
    {
        coolDownFilter.fillAmount = (currTimer / skillCoolDown);
    }

}
