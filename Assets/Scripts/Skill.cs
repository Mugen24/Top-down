using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public bool isSkillAvailable = true;
    public bool isSkillInProgress = false;
    protected float second_SkillDuration;
    protected float second_SkillCoolDown;
    protected GameObject playerRef;

    protected void SetUp(GameObject playerRef, float skillDuration, float skillCoolDown) {
        this.second_SkillDuration = skillDuration;
        this.second_SkillCoolDown = skillCoolDown;
        this.playerRef = playerRef;
    }

    public virtual void Before() { return;  }
    public virtual void After() { return;  }

    public virtual IEnumerator _UseSkill(bool blockControl) {
        if (!isSkillAvailable) { yield break; }
        isSkillAvailable = false;
        isSkillInProgress = true;

        if (blockControl)
        {
            playerRef.GetComponent<PlayerMovement>().blockControl = true;
        }

        Before();
        Activate();


        yield return new WaitForSeconds(second_SkillDuration);

        isSkillInProgress = false;

        if (blockControl)
        {
            playerRef.GetComponent<PlayerMovement>().blockControl = false;
        }

        After();

        yield return new WaitForSeconds(second_SkillCoolDown);
        isSkillAvailable= true;

    }

    public abstract void Activate();

    public void UseSkill(bool blockControl = false) {
        StartCoroutine(_UseSkill(blockControl));
    }
}
