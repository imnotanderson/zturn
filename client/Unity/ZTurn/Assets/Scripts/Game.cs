using System;
using System.Collections.Generic;
using UnityEngine;


public enum  BOX_TYPE{
    NONE,BRICK
}

public class Game {

    Vector2 g = new Vector2(0,-1);
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
    }

    public void Loop(){

    }

}
