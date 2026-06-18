using System.Collections;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using Util;

namespace Enemies{
    public abstract class ENM_Controller : ENT_Controller{
        public virtual bool shouldHunt=>!shouldAttack;
        public virtual bool shouldAttack=>false;
        protected bool canAttack;
        public float attackCD = 0.2f;
        public float range=3f;
        protected Rigidbody2D rb;
        [SerializeField] bool hunting;

        float localTick=0;
        const int huntingDelay=100;

        public abstract void Attack();
        public abstract void Hunt();

        protected virtual void Start(){
            localTick=Random.Range(0, 5);
            rb=GetComponent<Rigidbody2D>();
        }

        protected virtual void Update(){
            localTick += Time.deltaTime;
            if(shouldAttack) hunting=false;
            HandleAction();
        }

        protected void HandleAction(){
            if(shouldAttack) HandleAttack();
            else if(shouldHunt && !hunting) HandleHunt();
            else Debug.Log(string.Format("<color={0}>{1} is idle</color>", "#ffff00", gameObject.name));
        }

        void HandleAttack(){
            _ = Bool.SetBoolAfterDelay(() => canAttack = false, attackCD);
            hunting=false;
            Attack();
        }

        async void HandleHunt(){
            hunting=true;
            while(shouldHunt){
                Hunt();
                await Task.Delay(huntingDelay);
            }
        }       
    }
}