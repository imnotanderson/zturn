using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_ACTION{
    NONE,LEFT,RIGHT,JUMP,
}


public class Player
{
    public float fSpeed = 5;
    public Vector2 speed = Vector2.zero;
    public Vector2 pos;
    public int intPosX
    {
        get { return Mathf.RoundToInt(pos.x); }
    }
    public int intPosY
    {
        get { return Mathf.FloorToInt(pos.y); }
    }

    Queue<PLAYER_ACTION> actionQueue = new Queue<PLAYER_ACTION>();

    public Player(Vector2 pos)
    {
        this.pos = pos;
    }

    public void AddAction(PLAYER_ACTION action)
    {
        actionQueue.Enqueue(action);
    }

    public PLAYER_ACTION GetAction()
    {
        if (actionQueue.Count <= 0)
        {
            return PLAYER_ACTION.NONE;
        }
        return actionQueue.Dequeue();
    }

    public Vector3 GetActionSpeed(float stepTime)
    {
        switch (GetAction())
        {
            case PLAYER_ACTION.NONE:
                return Vector3.zero;
            case PLAYER_ACTION.LEFT:
                return Vector3.left * fSpeed;
            case PLAYER_ACTION.RIGHT:
                return Vector3.right * fSpeed;
            case PLAYER_ACTION.JUMP:
                this.speed += Vector2.up * 300 * stepTime;
                break;
            default:
                break;
        }
        return Vector3.zero;
    }
}