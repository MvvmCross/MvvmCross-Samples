using System;
using Cirrious.MvvmCross.Droid.Support.Fragging;

namespace XPlatformMenus.Droid.Fragments
{
    internal sealed class CustomFragmentInfo : MvxCachedFragmentInfo
    {
        public bool IsRoot { get; set; }

        public CustomFragmentInfo(string tag, Type fragmentType, Type viewModelType, bool addToBackstack = false, bool isRoot = false)
            : base(tag, fragmentType, viewModelType, addToBackstack)
        {
            IsRoot = isRoot;
        }
    }
}