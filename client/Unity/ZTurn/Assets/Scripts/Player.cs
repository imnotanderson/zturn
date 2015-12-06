using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_ACTION{
    LEFT,RIGHT,
}


public class Player {

    public Vector2 speed = Vector2.zero;
    public Vector2 pos;
    Queue<PLAYER_ACTION> actionQueue = new Queue<PLAYER_ACTION>();

    public Player(Vector2 pos){
        this.pos = pos;
    }

    public void AddAction(PLAYER_ACTION action)
    {
        actionQueue.Enqueue(action);
    }

    public PLAYER_ACTION GetAction(){
        return actionQueue.Dequeue();
    }


}
