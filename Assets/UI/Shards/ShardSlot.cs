using UnityEngine;

namespace UI.Shards
{
    [System.Serializable]
    public class ShardSlot{
        public GameObject shardSlot;
        [HideInInspector] public GameObject slotNumber;
        [HideInInspector] public SpriteRenderer slotIcon;

        public ShardSlot(GameObject shardSlot)
        {
            this.shardSlot=shardSlot;
            this.slotNumber=this.shardSlot.transform.GetChild(0).gameObject;
            this.slotIcon=this.shardSlot.transform.GetChild(1).GetComponent<SpriteRenderer>();
        }
    }
}