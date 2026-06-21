using System;
using Cursor;
using Enemies;
using Entities;
using UnityEngine;

public static class EntityUtil{
    public static bool IsEntity<T>(this object obj, out T comp){
        comp=default;

        if(obj is Collider2D) comp = (obj as Collider2D).GetComponent<T>();
        if(obj is RaycastHit2D ray) comp = ray.collider.GetComponent<T>();
        if(obj is GameObject) comp = (obj as GameObject).GetComponent<T>();
           
        return comp != null;      
    }

    public static bool IsEntity<T>(this object obj){
        if(obj is Collider2D) return (obj as Collider2D).GetComponent<T>()!=null;
        if(obj is RaycastHit2D ray) return ray.collider.GetComponent<T>()!=null;
        if(obj is GameObject) return (obj as GameObject).GetComponent<T>()!=null;
           
        return false;      
    }


}