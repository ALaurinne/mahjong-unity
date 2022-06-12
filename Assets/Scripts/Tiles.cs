using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour 
{   
   [SerializeField] Outline _outline;

   public string tileName;
   public int id;
   public Sprite tileSprite;
   public bool selected = false;
   public bool canClick = false;
   private TilesController tilesController;

   public void UpdateTile(Tiles newTiles, int id, TilesController controller, bool selected, bool canClick){
      this.tileName = newTiles.tileName;
      this.tileSprite = newTiles.tileSprite;
      this.id = id;
      this.tilesController = controller;
      this.selected = selected;
      this.canClick = canClick;

      var image = GetComponent<Image>();
      image.sprite = newTiles.tileSprite;
   }

   public void OnClick(){
      if(canClick){
         selected = !selected;
         tilesController.UpdateSelected(this);
      }
   }

   private void Update() {
      _outline.enabled = selected;
   }

}
