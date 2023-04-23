using System.Collections.Generic;
using UnityEngine;

public class KdTree<T>: IClosestTargetFinder where T : Component
{
    public int Count { get; private set; }

    private KdNode _root;
    private KdNode _last;
    private KdNode[] _open;

    public Vector3 GetClosestPosition(Vector3 position)
    {
        if (Count <= 0)
            return position;

        var nearestDist = float.MaxValue;
        KdNode nearest = null;

        if (_open == null || _open.Length < Count)
            _open = new KdNode[Count];
        for (int i = 0; i < _open.Length; i++)
            _open[i] = null;

        var openAdd = 0;
        var openCur = 0;

        if (_root != null)
            _open[openAdd++] = _root;

        while (openCur < _open.Length && _open[openCur] != null)
        {
            var current = _open[openCur++];
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
                    _open[openAdd++] = current.left;
                if (Mathf.Abs(splitCurrent - splitSearch) * Mathf.Abs(splitCurrent - splitSearch) < nearestDist && current.right != null)
                    _open[openAdd++] = current.right;
            }
            else
            {
                if (current.right != null)
                    _open[openAdd++] = current.right;
                if (Mathf.Abs(splitCurrent - splitSearch) * Mathf.Abs(splitCurrent - splitSearch) < nearestDist && current.left != null)
                    _open[openAdd++] = current.left;
            }
        }
        return nearest.component.transform.position;
    }

    public void Add(T item) 
        => Add(new KdNode() { component = item });

    public void Remove(T component)
    {
        int index = ToList().IndexOf(component);

        var list = new List<KdNode>(GetNodes());
        list.RemoveAt(index);
        ResetTree(list);
    }

    private void ResetTree(List<KdNode> list)
    {
        ClearList();
        foreach (var node in list)
            node.next = null;

        foreach (var node in list)
            Add(node);
    }

    public void ClearList()
    {
        _root = null;
        _last = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _root;
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
        => (a.x - b.x) * (a.x - b.x) + (a.z - b.z) * (a.z - b.z);
    private float GetSplitValue(int level, Vector3 position) 
        => (level % 2 == 0) ? position.x : position.z;

    private void Add(KdNode newNode)
    {
        Count++;
        newNode.left = null;
        newNode.right = null;
        newNode.level = 0;
        var parent = FindParent(newNode.component.transform.position);
 
        if (_last != null)
            _last.next = newNode;
        _last = newNode;

        if (parent == null)
        {
            _root = newNode;
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
        var current = _root;
        var parent = _root;
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

    private float GetSplitValue(KdNode node)
    {
        return GetSplitValue(node.level, node.component.transform.position);
    }

    private IEnumerable<KdNode> GetNodes()
    {
        var current = _root;
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