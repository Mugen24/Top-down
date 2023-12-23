using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dash : Skill
{
    public float dashMultiplier;
    public void SetUp(GameObject playerRef, float second_SkillDuration, float second_SkillCoolDown, float dashMultiplier) { 
        this.dashMultiplier = dashMultiplier;
        base.SetUp(playerRef, second_SkillDuration, second_SkillCoolDown);
    }

    public override void Activate() {
        Rigidbody2D rb = base.playerRef.GetComponent<Rigidbody2D>();
        rb.velocity = base.playerRef.transform.up * dashMultiplier;
    }

    public override IEnumerator _UseSkill(bool blockControl) {
        if (!isSkillAvailable) { yield break; }
        base.isSkillAvailable = false;
        base.isSkillInProgress = true;
        base.playerRef.GetComponent<PlayerMovement>().blockControl = true;
        
        
        Activate();
        yield return new WaitForSeconds(second_SkillDuration);

        isSkillInProgress = false;
        playerRef.GetComponent<PlayerMovement>().blockControl = false;

        Rigidbody2D rb = base.playerRef.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);

        yield return new WaitForSeconds(second_SkillCoolDown);
        isSkillAvailable= true;

    }
    
}
