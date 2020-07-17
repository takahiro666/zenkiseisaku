﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarHi : MonoBehaviour
{
   public static BoarHi Instance { set; get; }

    public GameObject highligtPrefab;
    private List<GameObject> highlights;

   private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
    }

    private GameObject GetHighlightObject()
    {
        GameObject go = highlights.Find(g => !g.activeSelf);

        if(go ==null)
        {
            go = Instantiate(highligtPrefab);
            highlights.Add(go);
        }
        return go;
    }
   
    public void HighlightAllowedMoves(bool[,]moves)//駒の動ける範囲にplanを生成しわかりやすくする
    {
        for(int i = 0; i<10;i++)
        {
            for(int j =0;j<10;j++)
            {
                if(moves[i,j])
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i+1f, 0.51f, j+1f);
                }
            }
        }
    }

    public void Hidehighlights()
    {
        foreach (GameObject go in highlights)
            go.SetActive(false);
    }
}