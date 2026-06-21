using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entities{
    [Serializable]
    public class Health{

        public float health;
        public float maxHealth;

        public Health(float health){
            this.health=health;
        }


        public static Health operator +(Health a) => a;
        public static Health operator -(Health a) => new Health(-a.health);

        public static Health operator +(Health a, float b) => new Health(a.health+b);
        public static Health operator -(Health a, float b) => new Health(a.health-b);

        public static Health operator /(Health a, float b) {
            if(b==0) throw new DivideByZeroException();
            else return new Health(a.health/b);
        }

        public static Health operator *(Health a, float b) => new Health(a.health * b);

        public static Health operator ++(Health a) => new Health(a.health++);
        public static Health operator --(Health a) => new Health(a.health--);
    }
}