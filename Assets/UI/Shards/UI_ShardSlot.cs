using UnityEngine;

namespace UI.Shards
{
    [System.Serializable]
    public class ShardSlot{
        public GameObject shardSlot;
        public GameObject slotNumber;
        public GameObject slotIcon;

        public ShardSlot(GameObject shardSlot)
        {
            this.shardSlot=shardSlot;
            this.slotNumber=this.shardSlot.transform.GetChild(0).gameObject;
            this.slotIcon=this.shardSlot.transform.GetChild(1).gameObject;
        }
    }
}