using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entities{
    [Serializable]
    public class Health{

        public float hValue;
        public float maxHealth;

        public void Clamp() => hValue=Mathf.Clamp(hValue, 0, maxHealth);
        

        public Health(float health, float maxHealth){
            this.hValue=health;
            this.maxHealth=maxHealth;
        }


        public static Health operator +(Health a) => a;
        public static Health operator -(Health a) => new Health(-a.hValue,a.maxHealth);

        public static Health operator +(Health a, float b) => new Health(a.hValue+b,a.maxHealth);
        public static Health operator -(Health a, float b) => new Health(a.hValue-b,a.maxHealth);

        public static bool operator <=(Health a, float b) => a.hValue<=b;
        public static bool operator >=(Health a, float b) => a.hValue>=b;
        public static bool operator ==(Health a, float b) => a.hValue==b;
        public static bool operator !=(Health a, float b) => a.hValue!=b;

        public static Health operator /(Health a, float b) {
            if(b==0) throw new DivideByZeroException();
            else return new Health(a.hValue/b,a.maxHealth);
        }

        public static Health operator *(Health a, float b) => new Health(a.hValue * b,a.maxHealth);

        public static Health operator ++(Health a) => new Health(a.hValue++,a.maxHealth);
        public static Health operator --(Health a) => new Health(a.hValue--,a.maxHealth);
    }
}