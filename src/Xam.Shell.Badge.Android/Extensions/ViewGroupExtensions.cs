﻿using System.Collections.Generic;
using AViewGroup = Android.Views.ViewGroup;
using AView = Android.Views.View;

namespace Xam.Shell.Badge.Droid.Extensions
{
    internal static class ViewGroupExtensions
    {
        internal static IEnumerable<T> GetChildrenOfType<T>(this AViewGroup self) where T : AView
        {
            for (var i = 0; i < self.ChildCount; i++)
            {
                AView child = self.GetChildAt(i);
                var typedChild = child as T;
                if (typedChild != null)
                    yield return typedChild;

                if (child is AViewGroup)
                {
                    IEnumerable<T> myChildren = (child as AViewGroup).GetChildrenOfType<T>();
                    foreach (T nextChild in myChildren)
                        yield return nextChild;
                }
            }
        }
    }
}