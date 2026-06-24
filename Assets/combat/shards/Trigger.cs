using UnityEngine;

namespace Combat.Shards{
    [System.Serializable]
    public class Trigger{
        public TriggerCondition triggerCondition;
        public float threshold=1f;
        [Range(1, 20)] public int triggerAmount=1;
    }
}