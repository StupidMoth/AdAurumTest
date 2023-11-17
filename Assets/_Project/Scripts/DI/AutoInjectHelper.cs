using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;
using VContainer;
using VContainer.Unity;

[ExecuteInEditMode]
[RequireComponent(typeof(LifetimeScope))]
public class AutoInjectHelper : MonoBehaviour
{
    private static AutoInjectHelper _instance;

    private LifetimeScope _lifetimeScope;


#if UNITY_EDITOR

    private void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(_instance);
        }

        _instance = this;

        EditorApplication.hierarchyChanged += OnHierarchyChanged;

        _lifetimeScope = GetComponent<LifetimeScope>();
    }

    private void OnDestroy()
    {
        EditorApplication.hierarchyChanged -= OnHierarchyChanged;
    }

    private void OnHierarchyChanged()
    {
        List<GameObject> gameObjects =
            FindObjectsOfType<MonoBehaviour>(includeInactive: true)
            .Where(mono => HasInjectAttribute(mono))
            .GroupBy(x => x.gameObject)
            .Select(x => x.First().gameObject)
            .ToList();

        FieldInfo autoInjectGameObjects = _lifetimeScope
            .GetType()
            .GetField("autoInjectGameObjects",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        autoInjectGameObjects.SetValue(_lifetimeScope, gameObjects);
    }

    private bool HasInjectAttribute(MonoBehaviour mono)
    {
        return CountMethodsWithAttribute(mono.GetType(), typeof(InjectAttribute)) >= 1;
    }

    public int CountMethodsWithAttribute(Type @class, Type attribute)
    {
        return @class
            .GetMethods()
            .Where(methodInfo => methodInfo.GetCustomAttributes(attribute, true).Length > 0)
            .Count();
    }

#endif

}