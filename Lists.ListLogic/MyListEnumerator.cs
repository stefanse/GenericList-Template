using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lists.ListLogic
{
    internal class MyListEnumerator<T> : IEnumerator<T>
    {
        private Node<T>  _head;
        private Node<T>  _actualNode;
        private bool _isReset;
        public MyListEnumerator(Node<T> head) 
        {
            _head = head;
            Reset();
        }



        public bool MoveNext()
        {
            if (_isReset)
            {
                _actualNode = _head;
                _isReset = false;
            }
            else
            {
                _actualNode = _actualNode.Next;
            }
            return _actualNode != null;
        }

        public void Reset()
        {
            _actualNode =null;
            _isReset = true;
        }

        public void Dispose()
        {
            return;
        }

 
       public T Current 
        { 
           get { return _actualNode.DataObject; } 
        }

        /*
         object IEnumerator.Current 
        {
            get { return Current; } //get{return _actualNode.DataObject}
        }
        */
        object IEnumerator.Current
        {
           get{ return _actualNode.DataObject; }
        }

        T IEnumerator<T>.Current { get { return _actualNode.DataObject; } }


        //object IEnumerator.Current => Current;
        //T IEnumerator<T>.Current => _actualNode.DataObject;

    }
}