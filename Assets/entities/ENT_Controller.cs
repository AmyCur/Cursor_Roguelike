using UnityEngine;
using Cursor;
using UnityEngine.Events;
using Combat;
using Enemies;
using Util;

namespace Entities{
    public abstract class ENT_Controller : MonoBehaviour{
        public Health health;
        public float damage;
        [SerializeField] protected bool canTakeDamage=true;
        public static float iFramesTime=0.3f; 



        
        public void HandleDamageAnimation(){}

        public virtual void Die(){
            Destroy(gameObject);
        }

        public void CheckHealth(){
            if(health<=0) Die();
        }

        public void TakeDamage(float damage){
            if(canTakeDamage){
                health=health-damage;
                health.Clamp();
                HandleDamageAnimation();
                if(gameObject.IsEntity<ENM_Controller>()) CO_Controller.Instance.HandleDamageDealt();

                canTakeDamage=false;
                _ = Bool.SetBoolAfterDelay(() => canTakeDamage=true, iFramesTime);
            }

            CheckHealth();
            
        }

        public ENT_Controller ChooseTarget(CombatPriority priority){
            ENT_Controller[] entities = GameObject.FindObjectsOfType<ENT_Controller>();

            ENT_Controller nearest=entities[0];
            ENT_Controller furthest=entities[0];
            ENT_Controller strongest=entities[0];
            ENT_Controller weakest=entities[0];
            ENT_Controller random=entities[Random.Range(0, entities.Length)];

            if(priority!=CombatPriority.random){
                foreach(ENT_Controller ec in entities){
                    if(ec.gameObject.distance() < nearest.gameObject.distance()) nearest=ec;
                    if(ec.gameObject.distance() > nearest.gameObject.distance()) furthest=ec;
                    if(ec.damage > nearest.damage) strongest=ec;
                    if(ec.damage < nearest.damage) weakest=ec;
                }
            }

            switch (priority){
                case CombatPriority.near:
                    return nearest;
                case CombatPriority.far:
                    return furthest;
                case CombatPriority.strong:
                    return strongest;
                case CombatPriority.weak:
                    return weakest;
                case CombatPriority.random:
                    return random;
                default:
                    Debug.LogError("Couldnt find any entities | Choosing Cursor as entity!");
                    return CU_Controller.instance;                
            }
        }
    }
}