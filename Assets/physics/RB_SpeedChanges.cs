using System.Threading.Tasks;
using UnityEngine;

namespace Physics{
    public static class RB_SpeedChange{
        public static async void Accelerate(this Rigidbody2D rb, Vector3 currentVelocity, Vector3 targetVelocity, float lerpSpeed=1f){
            // Velocity
            Vector3 v = currentVelocity;
            const int delayTime = 10;

            while(v!=targetVelocity){
                v=Vector2.Lerp(v, targetVelocity, Time.deltaTime*lerpSpeed);
                rb.linearVelocity=v;
                await Task.Delay(delayTime);
            }
        }
    }
}