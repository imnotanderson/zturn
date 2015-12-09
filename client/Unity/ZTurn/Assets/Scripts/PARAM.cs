using System.Collections;
using System.Threading;
using UnityEngine;

public class PARAM : MonoBehaviour {

    public static PARAM m = null;
    public float fVal1 = 0,fVal2;

    void Awake(){
        m = this;
    }

}
