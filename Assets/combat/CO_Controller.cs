using Combat.Shards;
using Enemies;
using UnityEngine;
using Util;

namespace Combat{
    public class CO_Controller : MonoSingleton<CO_Controller>{        
        
        public bool canAttack;
        public float damage;
        public float attackCD=0.2f;

        public Trigger[] triggers;

        public void HandleDamageDealt(){

        }

        
       

        void OnTriggerEnter2D(Collider2D other){
            if(other.IsEntity(out ENM_Controller enm) && canAttack){
                _ = Bool.SetBoolAfterDelay(() => canAttack = false, attackCD);
                enm.TakeDamage(damage);
            }
        }
    }
}