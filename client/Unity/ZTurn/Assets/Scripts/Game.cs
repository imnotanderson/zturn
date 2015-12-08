using System;
using System.Collections.Generic;
using UnityEngine;


public enum  BOX_TYPE{
    NONE,BRICK
}

public class Game {

    Vector2 g = new Vector2(0,-10);
    public Dictionary<int,Dictionary<int, BOX_TYPE>> mapData = new Dictionary<int, Dictionary<int, BOX_TYPE>>();
    public List<Player>playerList = new List<Player>();

    public void AddBox(int x,int y,BOX_TYPE boxType)
    {
        if(mapData.ContainsKey(x)==false){
            mapData[x] = new Dictionary<int,BOX_TYPE>();
        }
        mapData[x][y] = boxType;
    }

    public BOX_TYPE GetBox(int x,int y){
        if( mapData.ContainsKey(x)==false || mapData[x]==null || mapData[x].ContainsKey(y)==false)return BOX_TYPE.NONE;
        return mapData[x][y];
    }

    public void AddPlayer(Vector2 pos){
        Player player = new Player(pos);
        playerList.Add(player);
        testPlayer = player;
    }

    public void Loop(float stepTime)
    {
        TestControllor();
        foreach (Player player in playerList)
        {
            player.speed += g * stepTime;
            Vector2 actionSpeed = player.GetActionSpeed(stepTime);
            player.pos += (player.speed + actionSpeed) * stepTime;
            int x = player.intPosX;
            int y = player.intPosY;
            if (GetBox(x, y) == BOX_TYPE.BRICK)
            {
                player.pos = new Vector2(player.pos.x, y + 1);
                player.speed = Vector3.zero;
            }
        }
    }

    Player testPlayer = null;
    void TestControllor() {
        if (Input.GetKey(KeyCode.A))
        {
            testPlayer.AddAction(PLAYER_ACTION.LEFT);
        }
        if (Input.GetKey(KeyCode.D))
        {
            testPlayer.AddAction(PLAYER_ACTION.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            testPlayer.AddAction(PLAYER_ACTION.JUMP);
        }
        
    }
}
