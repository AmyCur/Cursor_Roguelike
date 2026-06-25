using Combat.Shards;
using Enemies;
using UnityEngine;
using Util;

namespace Combat{
    public class CO_Controller : MonoSingleton<CO_Controller>{        
        
        public bool canAttack;
        public float damage;
        public float attackCD=0.2f;

        public Shard[] shards;


        // Triggered slot of -1 means that it is targeting an index
        // Anything else means it is targeting a direction from the slot
        // Might change this in future
        public void ForceTriggerSlot(int slot, int triggerAmount=1){
            if(shards[slot]!=null){
                if(triggerAmount==1) shards[slot].Trigger();
                else shards[slot].MassTrigger(triggerAmount);
            }
            
        }

        public void ForceTriggerSlot(ForceTriggerDirections direction, int offset=1, int triggerAmount=1){
            int directionMultiplier = direction == ForceTriggerDirections.left ? -1 : 1;
            Shard targetShard = shards[offset*directionMultiplier];
            if(targetShard!=null){
                if(triggerAmount==1) targetShard.Trigger();
                else targetShard.MassTrigger(triggerAmount);
            }
        }

        public void HandleDamageDealt(){
            foreach(Shard s in shards){
                foreach(Trigger t in s.triggers){
                    if(t.triggerCondition==TriggerCondition.deal_damage){
                        s.Trigger();
                    }
                }
            }
        }

        void Update(){
            foreach(Shard s in shards){
                if(!s.started) s.Start();
            }
        }




        void OnTriggerEnter2D(Collider2D other){
            if(other.IsEntity(out ENM_Controller enm) && canAttack){
                canAttack=false;
                _ = Bool.SetBoolAfterDelay(() => canAttack = true, attackCD);
                enm.TakeDamage(damage);
            }
        }
    }
}