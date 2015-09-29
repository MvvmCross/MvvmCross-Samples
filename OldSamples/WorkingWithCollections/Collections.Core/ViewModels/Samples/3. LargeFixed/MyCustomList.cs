using System;
using System.Collections;
using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples.LargeFixed
{
    public class MyCustomList : IList<Kitten>, IList
    {
        private readonly MockDataRepository _dataRepository = new MockDataRepository();

        object IList.this[int index]
        {
            get { return this[index]; }
            set { throw new NotImplementedException(); }
        }

        public int Count
        {
            get { return _dataRepository.GetCount(); }
        }

        public Kitten this[int index]
        {
            get { return _dataRepository.GetKitten(index); }
            set { throw new NotImplementedException(); }
        }

        #region Not implemented

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized { get; private set; }

        public object SyncRoot { get; private set; }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize { get; private set; }

        public IEnumerator<Kitten> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Kitten item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Kitten item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Kitten[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Kitten item)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly { get; private set; }

        public int IndexOf(Kitten item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Kitten item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}