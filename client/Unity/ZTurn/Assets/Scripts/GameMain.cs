using UnityEngine;

public class GameMain :MonoBehaviour {

    Game game;

    void Start(){
        game = new Game();
        InitMap();
        game.AddPlayer(Vector2.up*2);
    }

    void InitMap(){
        for (int i=-10;i<10;i++)
            game.AddBox(i,0,BOX_TYPE.BRICK);
    }

    void OnDrawGizmos(){
        if(game==null)return;
        DebugDrawBox();
        DebugDrawPlayer();
    }

    void DebugDrawBox(){
        Gizmos.color = new Color(0.31764707f, 1.0f, 0.98039216f);
        foreach (var x in game.mapData.Keys){
            foreach (var y in game.mapData[x].Keys){
                switch (game.GetBox(x,y))
                {
                    case BOX_TYPE.BRICK:
                    Gizmos.DrawCube(new Vector3(x,y),Vector3.one);
                    break;
                }
            }
        }
    }

    void DebugDrawPlayer(){
        Gizmos.color = Color.red;
        foreach (var player in game.playerList){
            Gizmos.DrawCube(player.pos,Vector3.one);
        }
    }
}
