using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pseudocode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
Pseudocoding:

Map level controller:
START
    Transition in from SETUP
    Obtain waypoints
    Obtain random features
    Obtain creatures, create list
    Obtain players, create list
    Place random features
    Place creatures
    Determine initiative of each (value +/- randomiser)
    Order the initiative list
    Turn = 0
    Enable player placement in predetermined area
    On placement finish, enter turn mode
TURN
    Turn += 1
    For character (Active creature/player) in initiative:
        PLAYER/CREATURE ACTIONS
        Receive messages from killed characters, store in killed list, experience tally += value
            If no more live creatures - Victory
            If no more live players - Defeat
    Clean up, remove killed characters from initiative list
    Next turn 
END
    Message out total experience, class experience
    Transition out to RESULTS


Player/Creature controller (Move and an Action.):
START
    Message character type to map
    Message initiative to map
TURN
    moved = False
    actioned = False
    Display UI for player OR enable creature AI
        If character chooses a move: 
            moved = True
            perform move, cannot move any more
        If character chooses an action: 
            actioned = True
            perform action, cannot perform more actions
            message damage/healing/afflictions etc to targets
            Character class experience += skill value
    Any affliction counters -= 1
    End character turn
CONSTANT
    On death:
        Message character type and ID to map killed list
        if creature message experience value to experience tally

Camera:
    (Fixed, whole map)
    Create list of fixed camera transforms (positions/rotations)
    currentPosition = list[a].position
    currentRotation = list[a].rotation
    On command
    newPosition = list[b].position
    newRotation = list[b].rotation
    Delta current to new position/rotation
    
    (Non-fixed, character focused)
    List of camera offsets(variable X,Z, fixed Y) & rotations (fixed X,Z, variable Y)
    currentOffset = P_list[a]
    currentRotation = R_list[a], or simply a Y-axis value
    At start of each characters turn, focus key pressed:
    currentPosition = active character + offsets
    Free panning (X, Z) from that position
    On command:
    newOffset = P_list[b]
    newPosition = currentPosition - currentOffset + newOffset
    newRotation = R_list[b], or +/- Y value
    Delta to new position/rotation
    
    
*/