using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    public bool isSkillAvailable = true;
    public bool isSkillInProgress = false;
    public float second_SkillDuration = 0.2f;
    public float second_SkillCoolDown = 3f;
    public float currCoolDown;

    public GameObject playerRef;

    /*
    protected void SetUp(GameObject playerRef, float skillDuration, float skillCoolDown) {
        this.second_SkillDuration = skillDuration;
        this.second_SkillCoolDown = skillCoolDown;
        this.playerRef = playerRef;
    }
    */

    public virtual void Before() { return;  }
    public virtual void After() { return;  }
    public virtual void DuringCoolDown(float currTimer, float skillCoolDown) { return;  }

    
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

        currCoolDown = 0;
        while (currCoolDown < second_SkillCoolDown)
        {
            currCoolDown += Time.deltaTime;
            //coolDownFilter.fillAmount = ( coolDownTimer / second_SkillCoolDown );
            DuringCoolDown(currCoolDown, second_SkillCoolDown);
            yield return currCoolDown;
        }

        //yield return new WaitForSeconds(second_SkillCoolDown);
        isSkillAvailable= true;

    }

    public abstract void Activate();

    public void UseSkill(bool blockControl = false) {
        StartCoroutine(_UseSkill(blockControl));
    }
}
