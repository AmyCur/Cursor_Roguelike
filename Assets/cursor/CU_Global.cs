using UnityEngine;

namespace Cursor{
    public static class Cursor{
        public static Vector2 position=>Camera. main.ScreenToWorldPoint(Input.mousePosition);
        public static Vector2 displacement(this GameObject obj) => position-(Vector2)obj.transform.position;
        public static float distance(this GameObject obj) => Vector2.Distance(position, (Vector2)obj.transform.position);
    }
}