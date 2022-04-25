using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KdTree<T> where T : Component
{
    private KdNode root;
    private KdNode last;
    private KdNode[] open;

    public int Count { get; private set; }

    public void Add(T item)
    {
        Add(new KdNode() { component = item });
    }


    public void RemoveAt(int i)
    {
        var list = new List<KdNode>(GetNodes());
        list.RemoveAt(i);
        Clear();
        foreach (var node in list)
        {
            node.next = null;
        }
        foreach (var node in list)
            Add(node);
    }

    public void Clear()
    {
        root = null;
        last = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = root;
        while (current != null)
        {
            yield return current.component;
            current = current.next;
        }
    }


    public List<T> ToList()
    {
        var list = new List<T>();
        foreach (var node in this)
            list.Add(node);
        return list;
    }

    private float Distance(Vector3 a, Vector3 b)
    {
            return (a.x - b.x) * (a.x - b.x) + (a.z - b.z) * (a.z - b.z);
    }
    private float GetSplitValue(int level, Vector3 position)
    {
            return (level % 2 == 0) ? position.x : position.z;
    }

    private void Add(KdNode newNode)
    {
        Count++;
        newNode.left = null;
        newNode.right = null;
        newNode.level = 0;
        var parent = FindParent(newNode.component.transform.position);
 
        if (last != null)
            last.next = newNode;
        last = newNode;

        if (parent == null)
        {
            root = newNode;
            return;
        }

        var splitParent = GetSplitValue(parent);
        var splitNew = GetSplitValue(parent.level, newNode.component.transform.position);

        newNode.level = parent.level + 1;

        if (splitNew < splitParent)
            parent.left = newNode;
        else
            parent.right = newNode;
    }

    private KdNode FindParent(Vector3 position)
    {
        var current = root;
        var parent = root;
        while (current != null)
        {
            var splitCurrent = GetSplitValue(current);
            var splitSearch = GetSplitValue(current.level, position);

            parent = current;
            if (splitSearch < splitCurrent)
                current = current.left;
            else
                current = current.right;

        }
        return parent;
    }

    public Vector3 FindClosest(Vector3 position)
    {
        if (root == null)
            return Vector3.zero;

        var nearestDist = float.MaxValue;
        KdNode nearest = null;

        if (open == null || open.Length < Count)
            open = new KdNode[Count];
        for (int i = 0; i < open.Length; i++)
            open[i] = null;

        var openAdd = 0;
        var openCur = 0;

        if (root != null)
            open[openAdd++] = root;

        while (openCur < open.Length && open[openCur] != null)
        {
            var current = open[openCur++];
            var nodeDist = Distance(position, current.component.transform.position);
            if (nodeDist < nearestDist)
            {
                nearestDist = nodeDist;
                nearest = current;
            }

            var splitCurrent = GetSplitValue(current);
            var splitSearch = GetSplitValue(current.level, position);

            if (splitSearch < splitCurrent)
            {
                if (current.left != null)
                    open[openAdd++] = current.left;
                if (Mathf.Abs(splitCurrent - splitSearch) * Mathf.Abs(splitCurrent - splitSearch) < nearestDist && current.right != null)
                    open[openAdd++] = current.right;
            }
            else
            {
                if (current.right != null)
                    open[openAdd++] = current.right;
                if (Mathf.Abs(splitCurrent - splitSearch) * Mathf.Abs(splitCurrent - splitSearch) < nearestDist && current.left != null)
                    open[openAdd++] = current.left;
            }
        }
        return nearest.component.transform.position;
    }

    private float GetSplitValue(KdNode node)
    {
        return GetSplitValue(node.level, node.component.transform.position);
    }

    private IEnumerable<KdNode> GetNodes()
    {
        var current = root;
        while (current != null)
        {
            yield return current;
            current = current.next;
        }
    }
    protected class KdNode
    {
        internal T component;
        internal int level;
        internal KdNode left;
        internal KdNode right;
        internal KdNode next;
    }
}