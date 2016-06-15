using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
    public static class Enumerable
    {
        // Untested, should be fine.
        public static void RunInBatches<TType>(this IEnumerable<TType> listOfStuffToRunInBatches, int batchSize, Action<IEnumerable<TType>> actionToRun)
        {
            var batches = listOfStuffToRunInBatches.Batch(batchSize);
            foreach (var batch in batches)
            {
                actionToRun.Invoke(batch);
            }
        }

        public static List<List<TTypeToBatch>> Batch<TTypeToBatch>(this IEnumerable<TTypeToBatch> thingsToBatch, int batchSize)
        {
            var result = new List<List<TTypeToBatch>>();

            var batch = new List<TTypeToBatch>();

            foreach (var item in thingsToBatch)
            {
                batch.Add(item);

                if (batch.Count == batchSize)
                {
                    result.Add(batch);
                    batch.Clear();
                }
            }

            if (batch.Count > 0)
            {
                result.Add(batch);
            }

            return result;
            ;
        }
    }
}
