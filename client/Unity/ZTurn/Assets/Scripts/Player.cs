using Mono.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public enum PLAYER_ACTION{
    NONE,LEFT,RIGHT,JUMP,
}


public class Player
{
    public float fSpeedMax = 50;
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

    public void HandleAction(float stepTime)
    {
        float fVal1 = PARAM.m.fVal1;
        float xSpeed = speed.x;
        switch (GetAction())
        {
            case PLAYER_ACTION.NONE:
                xSpeed = Mathf.MoveTowards(xSpeed,0,stepTime*fVal1);
                speed.x = xSpeed;
                return ;
            case PLAYER_ACTION.LEFT:
                xSpeed = Mathf.MoveTowards(xSpeed,-fSpeedMax,stepTime*fVal1);
                speed.x = xSpeed;
                return ;
            case PLAYER_ACTION.RIGHT:
                xSpeed = Mathf.MoveTowards(xSpeed,+fSpeedMax,stepTime*fVal1);
                speed.x = xSpeed;
            return ;
            case PLAYER_ACTION.JUMP:
                this.speed += Vector2.up * 300 * stepTime;
                break;
            default:
                break;
        }
    }
}