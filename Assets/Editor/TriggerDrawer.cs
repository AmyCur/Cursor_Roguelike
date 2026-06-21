using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System;
using UnityEditor.UIElements;

namespace Combat.Shards{
    [CanEditMultipleObjects]
    [CustomPropertyDrawer(typeof(Trigger))]
    public class TriggerDrawer : PropertyDrawer{
        Trigger t;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Create property container element.
            var container = new VisualElement();

            // Create property fields.
            var name = new PropertyField(property.FindPropertyRelative("name"), "Name");
            var triggerCondition = new PropertyField(property.FindPropertyRelative("triggerCondition"), "Condition");
            var triggerSlots = new PropertyField(property.FindPropertyRelative("triggerSlots"), "Trigger Slots");
            var threshold = new PropertyField(property.FindPropertyRelative("threshold"), "Threshold");
            var triggerAmount = new PropertyField(property.FindPropertyRelative("triggerAmount"), "Trigger Amount");


            // Add fields to the container.
            container.Add(name);
            container.Add(triggerCondition);
            container.Add(triggerSlots);
            container.Add(threshold);
            container.Add(triggerAmount);




            return container;
        }
    }
}
