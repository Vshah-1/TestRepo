using System;
using System.Collections.Generic;
using System.Linq;

namespace StrainExercise
{

    public static class Strain
    {

        // Class with two methods: Keep and Discard
        // Keep and Discard are both lists of Ienumerables, this is to hold the values for the methods,
            // What we want to keep, and what we want to discard 
        // Within the method parameters are passed an identical list called collection
            // Within collection, we decide which values go into Keep, and which go into Discard 
        // We decide what comes out of collection into a method by,
            // assessing how the data fares with the Function predicate
        // predicate Function has a bool output, and a generic input 
        public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> keep = new List<T>();
            var i = 0;
            foreach (var item in collection)
            {
                if (predicate(item).Equals(true))
                {
                    keep.Add(item);
                    i++;
                }

            }
            return keep;
        }

        public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {

            List<T> discard = new List<T>();
            var i = 0;
            foreach (var item in collection)
            {
                if (predicate(item).Equals(false))
                {
                    discard.Add(item);
                    i++;
                }

            }
            return discard;
        }
    }
}