using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class AnimalShelter
    {
        public enum AnimalType
        {
            Dog,
            Cat
        }

        public class AnimalNode
        {
            public AnimalNode Next { get; set; }
            public AnimalNode Last { get; set; }

            public AnimalNode NextSame { get; set; }

            public AnimalType AnimalType { get; }

            public string Name { get; }

            public AnimalNode(AnimalType type, string name)
            {
                AnimalType = type;
                Name = name;
            }

            public override string ToString()
            {
                return $"{this.AnimalType}: {Name}";
            }
        }

        private AnimalNode _head;
        private AnimalNode _headDog;
        private AnimalNode _headCat;

        public bool IsEmpty => _head == null;

        public void Enqueue(AnimalNode node)
        {
            if(_head == null)
            {
                _head = node;
            }
            else
            {
                var current = _head;
                AnimalNode lastSame = current.AnimalType == node.AnimalType ? current : null;
            

                while (current.Next != null)
                {
                    current = current.Next;

                    if (current.AnimalType == node.AnimalType)
                    {
                        lastSame = current;
                    }
                }

                current.Next = node;
                node.Last = current;

                if (lastSame != null)
                {
                    lastSame.NextSame = node;
                }
            }

            if(node.AnimalType == AnimalType.Cat && _headCat == null)
            {
                _headCat = node;
            }
            else if(node.AnimalType == AnimalType.Dog && _headDog == null)
            {
                _headDog = node;
            }
        }

        public AnimalNode Dequeue()
        {
            var ret = _head;

            if(_head == _headDog)
            {
                _headDog = _headDog?.NextSame;
            }
            else
            {
                _headCat = _headCat?.NextSame;
            }

            _head = _head?.Next;

            return ret;
        }

        public AnimalNode Dequeue(AnimalType type)
        {
            AnimalNode ret = null;

            switch(type)
            {
                case AnimalType.Cat:
                    ret = _headCat;
                    _headCat.Last.Next = _headCat.Next;
                    _headCat = _headCat.NextSame;
                    break;

                case AnimalType.Dog:
                    ret = _headDog;
                    _headDog.Last.Next = _headDog.Next;
                    _headDog = _headDog.NextSame;
                    break;
            }

            if(ret == _head)
            {
                _head = _head.Next;
            }

            return ret;
        }
    }
}
