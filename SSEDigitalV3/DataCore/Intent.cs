using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    public class Intent
    {
        public struct KeyValue
        {
            public string key;
            public string value;
        }
        List<Intent.KeyValue> l_values;
        public Intent()
        {
            l_values = new List<Intent.KeyValue>();
        }
        public void putValue(string key, string value)
        {
            Intent.KeyValue to_put = new Intent.KeyValue();
            to_put.key = key;
            to_put.value = value;
            l_values.Add(to_put);
        }
        public string getString(string key)
        {
            foreach (Intent.KeyValue iterator in l_values)
            {
                if (iterator.key.Equals(key))
                {
                    return iterator.value;
                }
            }
            return null;
        }
    }
}
