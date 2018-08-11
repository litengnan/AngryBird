using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public List<Bird> birds;
    public List<Pig> pigs;

    public static GameManger _instance;
    private Vector3 originPos;

    private void Awake()
    {
        _instance = this;
        if(birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    public void NextBirds()
    {
        if(pigs.Count > 0)
        {
            if(birds.Count > 0)
            {
                Initialized();
            }
            else //输
            {

            }
        }
        else //赢
        {

        }
    }
}
