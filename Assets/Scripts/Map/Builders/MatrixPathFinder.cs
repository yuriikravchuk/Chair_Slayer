using System;
using System.Collections.Generic;
using UnityEngine;

namespace algorithms
{
    class MatrixPathFinder
    {
        private readonly Cell[,] _cells;
        private readonly int _boundX;
        private readonly int _boundY;

        public MatrixPathFinder(int boundX, int boundY)
        {
            _boundX = boundX;
            _boundY = boundY;
            _cells = new Cell[_boundX, _boundY];

            for (int y = 0; y < _boundY; y++)
                for (int x = 0; x < _boundX; x++)
                    _cells[x, y] = new Cell(x, y);
        }
        public IEnumerable<Vector2Int> GetPath(Vector2Int startIndex, Vector2Int endIndex)
        {

            Cell root = _cells[startIndex.x, startIndex.y];
            Cell target = _cells[endIndex.x, endIndex.y];
            return GetPath(root, target);
        }

        private IEnumerable<Vector2Int> GetPath(Cell root, Cell target)
        {
            root.IsRoot = true;
            bool founded = false;
            while (!founded)
            {
                IEnumerable<Cell> tail = root.GetTail();
                foreach (var cell in tail)
                {
                    var neighborCells = new List<Cell>();
                    if (cell.X > 0)
                        neighborCells.Add(_cells[cell.X - 1, cell.Y]);

                    if (cell.X < _boundX - 1)
                        neighborCells.Add(_cells[cell.X + 1, cell.Y]);

                    if (cell.Y > 0)
                        neighborCells.Add(_cells[cell.X, cell.Y - 1]);

                    if (cell.Y < _boundY - 1)
                        neighborCells.Add(_cells[cell.X, cell.Y + 1]);

                    for (int j = 0; j < neighborCells.Count; j++)
                    {
                        Cell neighbor = neighborCells[j];
                        if (neighbor.Father == null && !neighbor.IsRoot)
                        {
                            neighbor.Father = cell;
                            cell.AddChild(neighbor);
                            if (neighbor == target)
                                return target.GetPath();
                        }
                    }
                }

            }

            throw new InvalidOperationException();
        }

       private class Cell
        {
            public int X { get; }
            public int Y { get; }
            public Cell Father
            {
                get => _father;
                set
                {
                    if (_father == null)
                        _father = value;
                }

            }
            public bool IsRoot;

            private List<Cell> _children;
            private Cell _father;

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
                _children = new List<Cell>();
            }

            public void AddChild(Cell child) 
                => _children.Add(child);

            public IEnumerable<Cell> GetTail()
            {
                var tail = new List<Cell>();

                if (_children.Count > 0)
                    for (int i = 0; i < _children.Count; i++)
                        tail.AddRange(_children[i].GetTail());
                else
                    tail.Add(this);
                return tail;
            }

            public IEnumerable<Vector2Int> GetPath()
            {
                var result = new List<Vector2Int> { new Vector2Int(X,Y) };
                if (!IsRoot)
                    result.AddRange(Father.GetPath());

                return result;
            }
        }
    }
}
