using System.Collections;
using Cursor;
using UnityEngine;

namespace Combat.Shards{
    [CreateAssetMenu(fileName = "Vampire Shard", menuName = "Create/Shard/Vampire Shard")]
    /// <summary>
    /// This shard will allow the player to heal a lot upon killing enemies, but over time their health will decrease
    /// </summary>
    /// Roguelike where you play for small bursts, getting coins and playing until death and then restarting and upgrading
    /// The round ends when the boss is defeated; the player will then advance to the next round until eventually they fight the 
    /// final boss
    public class VampireShard : Shard{

        public float healAmount = 3f;
        public float hurtAmount = 1f;
        public float hurtTime=10f;

        public override void Triggered(){
            CU_Controller.instance.health+=healAmount*upgradeLevel;
        }

        IEnumerator HurtSelf(){
            while(true){
                yield return new WaitForSeconds(hurtTime/upgradeLevel);
                CU_Controller.instance.TakeDamage(hurtAmount);
            }
        }

        public override void Start() => CU_Controller.instance.StartCoroutine(HurtSelf());

        
    }
}