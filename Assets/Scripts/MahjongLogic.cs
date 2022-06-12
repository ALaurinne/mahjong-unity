using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MahjongLogic : MonoBehaviour
{
    [SerializeField] TilesController tilesController;
    [SerializeField] List<Tiles> tilesType;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] List<GameObject> slots;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] int points = 0;
    [SerializeField] GameObject finishGame;

    private void Start() {
        PlayGame();
    }
    
    void Update()
    {
        if(points == 3200){
            finishGame.SetActive(true);
        }
    }

    public void UpdatePoints(){
        points += 100;
        pointsText.SetText(points.ToString());
    }

    public void CanClickUpdate(int[] ids){
        foreach(var id in ids){
            if(((id+1) <= (slots.Count - 1))
                && slots[id+1] != null
                && !slots[id+1].GetComponent<Tiles>().canClick)
            {
                slots[id+1].GetComponent<Tiles>().canClick = true;
            }
            else if((id-1 >= 0)
                && slots[id-1] != null
                && !slots[id-1].GetComponent<Tiles>().canClick)
            {
                 slots[id-1].GetComponent<Tiles>().canClick = true;
            }
        }
    }

    void ClearPoints(){
        points = 0;
        pointsText.SetText(points.ToString());
    }

    public void PlayGame(){
        finishGame.SetActive(false);
        ClearPoints();
        var tiles = GenerateTiles();
        Shuffle(tiles); 
        InstantiateTiles(tiles);
    }

    public List<Tiles> GenerateTiles(){
        List<Tiles> newTiles = new List<Tiles>();

        for(int i = 0; i < (64/tilesType.Count); i++){
            foreach(var j in tilesType){
                newTiles.Add(j);
            }
        }

        return newTiles;
    }

    void Shuffle<T>(List<T> list){
        System.Random random = new System.Random();
        int n = list.Count;
        while(n>1){
            int i = random.Next(n);
            n--;

            T temp = list[i];
            list[i] = list[n];
            list[n] = temp;
        }
    }

    void InstantiateTiles(List<Tiles> tiles){

        var factor = 0;
        while(factor < 61){
            for(int i = 0; i < 4; i++){
                slots[i+factor].SetActive(true);

                var tileComponent = slots[i+factor].GetComponent<Tiles>();
                tileComponent.UpdateTile(tiles[i + factor], i+factor, tilesController, false, false);

                if(i == 0 || i == 3)
                {
                    tileComponent.canClick = true;
                }
            }
            factor += 4;
        }
        
    }
}
