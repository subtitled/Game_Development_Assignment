using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSelection: MonoBehaviour {

    //code for moving character after clicking move button
    public void MoveChar()
    {
        //pseudo
        //show grid based on unit movement stat
        //allow player to click which grid square they want to move to
        //move unit to square with A*?
        //end turn
    }
    //code for defending after clicking button
    public void Defend()
    {
        //unit stays in place
        //takes -x% damage from next attack or ability
        //end turn
    }
    //code for using first weapon after clicking button
    public void UseWepOne()
    {
        //show grid based on range of weapon
        //allow player to choose grid spot that contains enemy in range to attack
        //get weapon information + unit stats from unit sheet
        //calculate damage
        //take damage away from target health
        //end turn
    }
    //code for using second weapon after clicking button
    //code for using ability one after clicking button
    public void AbilityOne()
    {
        //show grid based on range of ability
        //allow player to choose grid spot that contains enemy in range to attack or friendly in range to support
        //get ability information + stats from unit sheet
        //calculate damage/healing/stat boost
        //apply to target
        //end turn
    }
    //code for using ability two after clicking button

}
