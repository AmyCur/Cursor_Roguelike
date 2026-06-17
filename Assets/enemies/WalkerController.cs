using System.Collections;
using UnityEngine;
using Cursor;

namespace Enemies{
    public sealed class WalkerController : ENM_Controller{

        public override bool shouldAttack => gameObject.distance() < range;
        [SerializeField] float moveSpeed=12f;

        public override void Attack(){
            Debug.Log("Attack");
            rb.linearVelocity=Vector2.zero;
        }

        public override void Hunt(){
            rb.linearVelocity=gameObject.displacement().normalized*moveSpeed;
            Debug.Log("Hunt");
        }

       

    }
}