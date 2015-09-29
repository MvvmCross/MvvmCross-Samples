using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Attributes;
using CrossUI.Touch.Dialog.Elements;

namespace DialogExamples.Touch.BindableElements
{
    public class BindableSection<TElementTemplate> : Section
        where TElementTemplate : Element, IBindableElement
    {
        private IEnumerable _itemsSource;
        private MvxNotifyCollectionChangedEventSubscription _subscription;

        public BindableSection()
            : base()
        {
        }

        public BindableSection(string caption)
            : base(caption)
        {
        }

        [MvxSetToNullAfterBinding]
        public IEnumerable ItemsSource
        {
            get { return _itemsSource; }
            set { SetItemsSource(value); }
        }

        protected virtual void SetItemsSource(IEnumerable value)
        {
            if (_itemsSource == value)
                return;
            if (_subscription != null)
            {
                _subscription.Dispose();
                _subscription = null;
            };
            _itemsSource = value;
            if (_itemsSource != null && !(_itemsSource is IList))
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,
                                      "Binding to IEnumerable rather than IList - this can be inefficient, especially for large lists");
            var newObservable = _itemsSource as INotifyCollectionChanged;
            if (newObservable != null)
                _subscription = newObservable.WeakSubscribe(OnItemsSourceCollectionChanged);
            NotifyDataSetChanged();
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }

        private void NotifyDataSetChanged()
        {
            var newElements = new List<Element>();
            if (_itemsSource != null)
            {
                foreach (var item in _itemsSource)
                {
                    var element = Activator.CreateInstance<TElementTemplate>();

                    element.DataContext = item;

                    newElements.Add((Element) element);
                }
            }

            Elements.Clear();
            Elements.AddRange(newElements);

            var root = this.Parent as RootElement;
            if (root == null) root = this.GetImmediateRootElement();

            if (root != null) root.TableView.ReloadData();
        }
    }
}