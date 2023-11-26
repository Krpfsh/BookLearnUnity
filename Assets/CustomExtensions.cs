using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomExtensions
{
    public static class StringExtensions
    {
        public static void FancyDebug(this string str)
        {
            Debug.Log($"This string contains {str.Length} characters.");

        }
    }
}
