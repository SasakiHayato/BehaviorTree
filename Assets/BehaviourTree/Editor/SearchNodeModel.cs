using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System;
using System.Linq;

namespace BehaviourTree.Edit
{
    public class SearchNodeModel : ScriptableObject, ISearchWindowProvider
    {
        GraphView _view;

        internal void Initialize(GraphView view)
        {
            _view = view;
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> list = new List<SearchTreeEntry>();

            list.Add(new SearchTreeGroupEntry(new GUIContent("Create Data")));

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.IsClass && !a.IsAbstract && a.IsSubclassOf(typeof(BaseNode)))
                .ToList()
                .ForEach(a =>
                {
                    list.Add(new SearchTreeEntry(new GUIContent(a.Name)) { level = 1, userData = a });
                });

            return list;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            var type = SearchTreeEntry.userData as Type;
            var node = Activator.CreateInstance(type) as BaseNode;
            _view.AddElement(node);

            return true;
        }
    }
}