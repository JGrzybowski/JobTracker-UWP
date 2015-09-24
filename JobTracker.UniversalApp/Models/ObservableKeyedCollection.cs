using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public abstract class ObservableKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>, INotifyCollectionChanged, ISwappableCollection
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override void ClearItems()
        {
            base.ClearItems();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void InsertItem(int index, TItem item)
        {
            base.InsertItem(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected override void RemoveItem(int index)
        {
            TItem item = Items[index];
            base.RemoveItem(index);
            //FIX (NotifyCollectionChangedAction.Remove, item) throws strange exception
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void SetItem(int index, TItem item)
        {
            base.SetItem(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, index));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, e);
        }

        public void SwapItems(int indexA, int indexB)
        {
            if (this.Count < 1)
                throw new InvalidOperationException("There are no items to swap.");
            else if (indexA < 0 || indexA > this.Count - 1)
                throw new ArgumentOutOfRangeException("IndexA is out of range.");
            else if (indexB < 0 || indexB > this.Count - 1)
                throw new ArgumentOutOfRangeException("IndexB is out of range.");
            var temp = this[indexA];
            this[indexA] = this[indexB];
            this[indexB] = temp;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Move,
                new List<TItem> { this[indexA], this[indexB] },
                indexB, indexB));
        }

    }
}