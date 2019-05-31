using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_2_4
{
    public static class Algorithm
    {
        private static void AddEntry(byte[] compressedData, ref int indexCompressed, byte current, int count)
        {
            compressedData[indexCompressed] = Convert.ToByte(count);
            ++indexCompressed;
            compressedData[indexCompressed] = current;
            ++indexCompressed;
        }

        private static byte[] MakeCompArray(byte[] data)
        {
            int size = 0;

            byte current = data[0];
            int count = 1;
            for (int i = 1; i < data.Length; ++i)
            {
                if (current == data[i])
                {
                    if (count == 1)
                    {
                        ++size;
                    }
                    ++count;
                    if (i == data.Length - 1)
                    {
                        break;
                    }
                }
                else
                {
                    current = data[i];
                    count = 1;
                    ++size;

                    if (i == data.Length - 1)
                    {
                        ++size;
                        break;
                    }
                }
            }

            var compressedData = new byte[size * 2];
            return compressedData;
        }

        public static byte[] Compression(byte[] data)
        {
            var compressedData = MakeCompArray(data);

            byte current = data[0];
            int count = 1;
            int indexCompressed = 0;

            for (int i = 1; i < data.Length; ++i)
            {
                if (current == data[i])
                {
                    ++count;
                    if (i == data.Length - 1)
                    {
                        AddEntry(compressedData, ref indexCompressed, current, count);
                        break;
                    }
                }
                else
                {
                    AddEntry(compressedData, ref indexCompressed, current, count);

                    current = data[i];
                    count = 1;

                    if (i == data.Length - 1)
                    {
                        AddEntry(compressedData, ref indexCompressed, current, count);
                        break;
                    }
                }
            }

            return compressedData;
        }

        private static byte[] MakeDecompArray(byte[] data)
        {
            int size = 0;
            for (int i = 0; i < data.Length - 1; ++i)
            {
                size += Convert.ToInt32(data[i]);
                ++i;
            }

            var decompressedData = new byte[size];
            return decompressedData;
        }

        public static byte[] Decompression(byte[] data)
        {
            var decompressedData = MakeDecompArray(data);
            int indexDecompressed = 0;

            for (int i = 0; i < data.Length - 1; i += 2)
            {
                int count = Convert.ToInt32(data[i]);
                byte current = data[i + 1];

                for (int k = 1; k <= count; ++k)
                {
                    decompressedData[indexDecompressed] = current;
                    ++indexDecompressed;
                }
            }

            return decompressedData;
        }
    }
}
