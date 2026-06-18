using Entities;
using UnityEngine;

namespace Cursor{
    public class CU_Controller : ENT_Controller{      
        public static CU_Controller instance;

        public bool canAttack;

        [Header("Movement")]
        public float moveSpeed;

        [Header("Attacking")]
        [Header("Ball")]
        public float ballDamage;
        public float ballRange;
        public CombatPriority ballPriority=CombatPriority.near;

        void Update(){
            transform.position=Vector2.Lerp(transform.position, Cursor.position, moveSpeed);
        }

        void Awake(){
            if(instance==null) instance=this;
        }
    }
}