﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmUzerWeb.Tools.ExtensionMethods
{
    public static class ListExtensionMethods
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}