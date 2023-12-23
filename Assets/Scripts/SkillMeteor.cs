using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMeteor : Skill
{
    public void SetUp(GameObject playerRef, float second_SkillDuration, float second_SkillCoolDown, float speedMultiplier) {
        base.SetUp(playerRef, second_SkillDuration, second_SkillCoolDown);
    }

    public override void Activate() {
        Meteor.speedMultiplier = 0.1f;
        //Meteor.speedMultiplier = speedMultiplier;
    }

    public override void After() { 
        Meteor.speedMultiplier = 1f;
    }



}
