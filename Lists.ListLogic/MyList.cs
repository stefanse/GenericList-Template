using System;
using System.Collections;
using System.Collections.Generic;


namespace Lists.ListLogic
{
    /// <summary>
    /// Die Liste verwaltet beliebige Elemente und implementiert
    /// das IList-Interface und damit auch ICollection und IEnumerable
    /// </summary>
    public class MyList<T>: IList<T>
    {
        Node<T> _head;
        //public int _addindex = 1;

        #region IList Members

        /// <summary>
        /// Ein neues Objekt wird in die Liste am Ende
        /// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
        /// nicht behandelt und lösen eine Exception aus.
        /// </summary>
        /// <param name="value">Einzufügender Datensatz</param>
        /// <returns>Index des Werts in der Liste</returns>
     
      
        public void Add (T value)
        {

            Node<T> insertNode = new Node<T>(value);
            if (_head == null)
            {
                _head = insertNode;
                /// _addindex = 0;
                // return 0;
            }
            else
            {
                Node<T> searchNode = _head;
                //   _addindex = 1; 
                while (searchNode.Next != null)
                {
                    searchNode = searchNode.Next;
                    // _addindex++;
                }
                searchNode.Next = insertNode;
                //_addindex = 0;
            }
        }

        /// <summary>
        /// Die Liste wird geleert. Die Elemente werden einfach ausgekettet.
        /// Der GC räumt dann schon auf.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        /// <summary>
        /// Gibt es den gesuchten DataObject zumindest ein mal?
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return IndexOf(value) >= 0;
        }

        /// <summary>
        /// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>
        /*
        public int IndexOf(T value)
        {
            Node<T> searchNode = _head;
            int index = 0;
    
            while (searchNode != null && !(searchNode.DataObject.ToString().Equals(value.ToString())) )
            {
                searchNode = searchNode.Next;
                index++;
                
            }

            if (searchNode == null)
            {
                return -1;
            }
            return index;
        }*/

        public int IndexOf(T value)
        {
            Node<T> searchNode = _head;
            int index = 0;
            while (searchNode != null && !searchNode.DataObject.Equals(value))
            {
                searchNode = searchNode.Next;
                index++;
            }
            if (searchNode == null)
            {
                return -1;
            }
            return index;
        }

        /* int IList.IndexOf(object item)
         {
             if (List<T>.IsCompatibleObject(item))
                 return this.IndexOf((T)item);
             return -1;
         } */

        /// <summary>
        /// DataObject an bestimmter Position in Liste einfügen.
        /// Es ist auch erlaubt, einen DataObject hinter dem letzten Element
        /// (index == count) einzufügen.
        /// </summary>
        /// <param name="index">Einfügeposition</param>
        /// <param name="value">Einzufügender DataObject</param>
        public void Insert(int index, T value)
        {
            if (index > Count || index < 0)
            {
                return;
            }
            Node<T> newNode = new Node<T>(value);
            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
                return;
            }
            Node<T> searchNode = _head;
            for (int i = 1; i < index; i++)
            {
                searchNode = searchNode.Next;
            }
            newNode.Next = searchNode.Next;
            searchNode.Next = newNode;
        }

        public void MyInsert (int index, T value)
        {
            int countindex = 0;
            if (index > Count || index < 0)
            {
                return;
            }
            if (index == 0)
            {
                _head.DataObject = value;
            }

            Node<T> searchNode = _head;
            while (index != countindex)
            {
                searchNode = searchNode.Next;
                countindex++;
            }
            if (countindex == index)
            {
                searchNode.DataObject = value;
            }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Ein DataObject wird aus der Liste entfernt, wenn es ihn 
        /// zumindest ein mal gibt.
        /// </summary>
        /// <param name="value">zu entfernender DataObject</param>
        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false; //Kollege hat false in einem else
            }
        }

        /// <summary>
        /// Der DataObject an der Position Index wird entfernt.
        /// Gibt es die Position nicht, geschieht nichts.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return;
            }
            if (index == 0)
            {
                _head = _head.Next;
                return;
            }
            Node<T> searchNode = _head;
            for (int i = 1; i < index; i++)
            {
                searchNode = searchNode.Next;
            }
            searchNode.Next = searchNode.Next.Next;
        }

        /// <summary>
        /// Indexer zum Einfügen und Lesen von Werten an
        /// gesuchten Positionen.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    return default(T);
                }
                Node<T> searchNode = _head;
                for (int i = 0; i < index; i++)
                {
                    searchNode = searchNode.Next;
                }
                return searchNode.DataObject;
            }
            set
            {
                MyInsert(index, value);
                
            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Werte in ein bereits angelegtes Array kopieren.
        /// Ist das übergebene Array zu klein, oder stimmt der
        /// Startindex nicht, geschieht nichts.
        /// </summary>
        /// <param name="array">Zielarray, existiert bereits</param>
        /// <param name="index">Startindex</param>
        public void CopyTo(T[] array, int index)
        {
            if (array.Length < Count - index)
            {
                return;
            }
            Node<T> searchNode = _head;
            for (int i = 0; i < index; i++)
            {
                searchNode = searchNode.Next;
            }
            int targetIndex = 0;
            while (searchNode != null)
            {
                array.SetValue(searchNode.DataObject, targetIndex);
                searchNode = searchNode.Next;
                targetIndex++;
            }
        }

        /// <summary>
        /// Die Anzahl von Elementen in der Liste wird immer 
        /// explizit gezählt und ist nicht redundant gespeichert.
        /// </summary>
        public int Count
        {
            get
            {
                int counter = 0;
                Node<T> searchNode = _head;
                while (searchNode != null)
                {
                    searchNode = searchNode.Next;
                    counter++;
                }
                return counter;
            }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion


        
       //public IEnumerator<T> GetEnumerator() => new MyListEnumerator<T>(_head);
      // IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  
        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(_head);
        }
         IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }

        public  void BubbleSort ()
        {

            int i = 0;
            int j = 0;
            IComparable obj1;
            IComparable obj2;
            IComparable temp; 

            for( i = 0; i < Count-1 ; i++)
            {
                for ( j = i + 1; j < Count; j++)
                {
                    obj1 = this[i] as IComparable;
                    obj2 = this[j] as IComparable;  

                    if (obj1 != null && obj2 != null)
                    {
                        if (obj1.CompareTo(obj2) < 0) //obj1 < obj2
                        {
                            temp = obj1;
                            this[i] = (T)obj2;
                            this[j] = (T)temp;
                        }
                    }
                }
            }
        }
        
       
    }
}