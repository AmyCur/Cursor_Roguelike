using System;
using UnityEngine;

namespace Combat.Shards{
    [Serializable]
    public abstract class Shard : ScriptableObject{

        public uint upgradeLevel=1;

        public virtual void Start(){}

        public Trigger[] triggers;
        public abstract void Triggered();
    }
}