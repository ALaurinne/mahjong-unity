using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System;

public class TilesController : MonoBehaviour
{
    [SerializeField] MahjongLogic mahjongLogic;
    private Tiles selectedTile;

    public void UpdateSelected(Tiles tile){
        if(tile.selected == false){
            selectedTile = null;
            return;
        }

        if(selectedTile != null){
            CheckMatch(tile);
        } else {
            selectedTile = tile;
        }
    }

    private void CheckMatch(Tiles newTile){
        if(selectedTile.tileName == newTile.tileName){
            mahjongLogic.CanClickUpdate(new int[] {selectedTile.id, newTile.id});
            mahjongLogic.UpdatePoints();

            selectedTile.gameObject.SetActive(false);
            newTile.gameObject.SetActive(false);
            selectedTile = null;
        } else if( selectedTile != null) {
            selectedTile.selected = false;
            selectedTile = newTile;
        }
    }

    private void Update(){
        
    }
}
