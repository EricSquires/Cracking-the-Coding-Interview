﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListNode<T> : IEquatable<LinkedListNode<T>>
    {
        public T Value { get; set; }

        public int Length { get; set; }

        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Last { get; set; }

        public LinkedListNode(IEnumerable<T> values)
        {
            foreach(var val in values)
            {
                Add(val);
            }
        }

        public LinkedListNode(params T[] values) : this((IEnumerable<T>)values) { }

        public LinkedListNode(T value)
        {
            Value = value;
            Length = 1;
        }

        public LinkedListNode() { }

        public LinkedListNode<T> Add(T value)
        {
            if(Length == 0)
            {
                Value = value;

                Length++;
                return this;
            }
            else
            {
                return Add(new LinkedListNode<T>(value));
            }
        }
        
        /// <returns>The head node</returns>
        public LinkedListNode<T> Add(LinkedListNode<T> node)
        {
            Length++;

            if(Next == null)
            {
                Next = node;
            }
            else
            {
                Next.Add(node);
            }

            return this;
        }

        public void Remove()
        {
            if(Last != null)
            {
                Last.Next = Next;
            }

            if(Next != null)
            {
                Next.Last = Last;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is LinkedListNode<T> && Equals((LinkedListNode<T>)obj);
        }

        public bool Equals(LinkedListNode<T> other)
        {
            return Equals(other, Direction.Forward | Direction.Back);
        }

        private bool Equals(LinkedListNode<T> other, Direction direction)
        {
            if(!Value.Equals(other.Value))
            {
                return false;
            }

            if(direction.HasFlag(Direction.Back))
            {
                if(Last != null && other.Last != null)
                {
                    if(!Last.Equals(other.Last, Direction.Back))
                    {
                        return false;
                    }
                }
                else if(Last != other.Last)
                {
                    return false;
                }
            }

            if(direction.HasFlag(Direction.Forward))
            {
                if (Next != null && other.Next != null)
                {
                    if(!Next.Equals(other.Next, Direction.Forward))
                    {
                        return false;
                    }
                }
                else if(Next != other.Next)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return GetString(Direction.Back | Direction.Forward, true);
        }

        private string GetString(Direction direction, bool isOrigin = false)
        {
            string ret = Value.ToString();

            if(isOrigin)
            {
                ret = "{" + ret + "}";
            }

            if(direction.HasFlag(Direction.Back) && Last != null)
            {
                ret = Last.GetString(Direction.Back) + ", " + ret;
            }

            if(direction.HasFlag(Direction.Forward))
            {
                if(Next != null)
                {
                    ret += ", ";
                }

                ret += Next?.GetString(Direction.Forward);
            }

            return ret;
        }

        [Flags]
        private enum Direction
        {
            Back = 1,
            Forward = 2
        }
    }
}
