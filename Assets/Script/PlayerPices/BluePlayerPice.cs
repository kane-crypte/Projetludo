using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPice : PlayerPice
{
    // Start is called before the first frame update
    void Start()
    {
        //MovePlayer();
        StartCoroutine(MovePlayerCorountine());
    }

    public void MovePlayer(){
        for(int i = 0 ; i < 5; i++){
            transform.position = pathParent.CommenPathPoint[i].transform.position;
        }
    }

    IEnumerator MovePlayerCorountine(){
         for(int i = 0 ; i < 5; i++){
            transform.position = pathParent.CommenPathPoint[i].transform.position;
            yield return new WaitForSeconds(0.35f);
        }
    }
}
