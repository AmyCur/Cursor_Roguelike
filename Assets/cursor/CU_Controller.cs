using UnityEngine;

namespace Cursor{
    public class CU_Controller : MonoBehaviour{        
        void Update(){
            transform.position=Cursor.position;
        }
    }
}