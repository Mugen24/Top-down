using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMeteor : Skill
{
    float DEFAULT_SPEED_MULTIPLIER = 1f;
    public float slowMultiplier = 0.1f;
/*
    public void SetUp(GameObject playerRef, float second_SkillDuration, float second_SkillCoolDown, float speedMultiplier) {
        base.SetUp(playerRef, second_SkillDuration, second_SkillCoolDown);
    }
*/

    public override void Activate() {
        Meteor.speedMultiplier = slowMultiplier;
    }

    public override void After() { 
        Meteor.speedMultiplier = DEFAULT_SPEED_MULTIPLIER;
    }



}
