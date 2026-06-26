using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Combat.Shards{
    [Serializable]
    public abstract class Shard : ScriptableObject{

        const int massTriggerDelay=100;
        public uint upgradeLevel=1;
        public bool started;
        public Sprite sprite;

        public virtual void Start(){
            started=true;
        }

        public Trigger[] triggers;
        public abstract void Trigger();

        public async void MassTrigger(int triggerAmount){
            while(triggerAmount>0){
                Trigger();
                triggerAmount--;
                await Task.Delay(massTriggerDelay);
            }
        }
    }
}