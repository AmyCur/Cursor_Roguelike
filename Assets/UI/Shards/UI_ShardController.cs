using UnityEngine;
using System.Collections.Generic;
using Combat.Shards;
using Combat;

namespace UI.Shards
{
    public class UI_ShardController : MonoBehaviour{
        public List<ShardSlot> shardSlots;

        public void UpdateIcons()
        {
            for(int i = 0; i < shardSlots.Count; i++){
                try{
                    shardSlots[i].slotIcon.sprite = CO_Controller.Instance.shards[i].sprite;                   
                    
                }
                catch{
                    shardSlots[i].slotIcon.sprite = Resources.Load<Sprite>("sprites/Nothing");
                }
            }
        }

        public void Update(){
            UpdateIcons();
        }
    }
}