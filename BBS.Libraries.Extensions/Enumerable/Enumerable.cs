//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace BBS.Libraries.Extensions
{
    public static class Enumerable
    {
        public static void RunInBatches<TType>(this IEnumerable<TType> listOfStuffToRunInBatches, int batchSize, Action<IEnumerable<TType>> actionToRun)
        {
            var batches = listOfStuffToRunInBatches.Batch(batchSize);
            foreach (var batch in batches)
            {
                actionToRun.Invoke(batch);
            }
        }

        public static IEnumerable<IEnumerable<TTypeToBatch>> Batch<TTypeToBatch>(this IEnumerable<TTypeToBatch> thingsToBatch, int batchSize)
        {
            var result = new List<List<TTypeToBatch>>() ;

            var batch = new List<TTypeToBatch>();

            foreach (var item in thingsToBatch)
            {
                batch.Add(item);

                if (batch.Count >= batchSize)
                {
                    result.Add(batch);

                    batch = new List<TTypeToBatch>();
                }
            }

            if (batch.Count > 0)
            {
                result.Add(batch);
            }

            return result;
        }
    }
}
