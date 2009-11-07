﻿/* 
 * Copyright (C) 2008-2009, Bit Miracle
 * http://www.bitmiracle.com
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BitMiracle.LibTiff
{
    /// <summary>
    /// Holds a value of Tiff tag.
    /// Simply put, it is a wrapper around System.Object, that helps to deal with
    /// unboxing and conversion of types a bit easier.
    /// 
    /// Please take a look at:
    /// http://blogs.msdn.com/ericlippert/archive/2009/03/19/representation-and-identity.aspx
    /// </summary>
#if EXPOSE_LIBTIFF
    public
#endif
    struct FieldValue
    {
        private object m_value;
        
        internal FieldValue(object o)
        {
            m_value = o;
        }

        static internal FieldValue[] FromParams(params object[] list)
        {
            FieldValue[] values = new FieldValue[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] is FieldValue)
                    values[i] = new FieldValue(((FieldValue)(list[i])).Value);
                else
                    values[i] = new FieldValue(list[i]);
            }

            return values;
        }

        internal void Set(object o)
        {
            m_value = o;
        }

        public object Value
        {
            get { return m_value; }
        }

        public byte ToByte()
        {
            return Convert.ToByte(m_value);
        }

        public short ToShort()
        {
            return Convert.ToInt16(m_value);
        }

        public ushort ToUShort()
        {
            return Convert.ToUInt16(m_value);
        }

        public int ToInt()
        {
            return Convert.ToInt32(m_value);
        }

        public uint ToUInt()
        {
            return Convert.ToUInt32(m_value);
        }

        public float ToFloat()
        {
            return Convert.ToSingle(m_value);
        }

        public double ToDouble()
        {
            return Convert.ToDouble(m_value);
        }

        public new string ToString()
        {
            if (m_value is byte[])
                return Encoding.GetEncoding("Latin1").GetString(m_value as byte[]);

            return Convert.ToString(m_value);
        }

        public byte[] GetBytes()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is byte[])
                    return m_value as byte[];
                else if (m_value is short[])
                {
                    short[] temp = m_value as short[];
                    byte[] result = new byte[temp.Length * sizeof(short)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
                else if (m_value is ushort[])
                {
                    ushort[] temp = m_value as ushort[];
                    byte[] result = new byte[temp.Length * sizeof(ushort)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
                else if (m_value is int[])
                {
                    int[] temp = m_value as int[];
                    byte[] result = new byte[temp.Length * sizeof(int)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
                else if (m_value is uint[])
                {
                    uint[] temp = m_value as uint[];
                    byte[] result = new byte[temp.Length * sizeof(uint)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
                else if (m_value is float[])
                {
                    float[] temp = m_value as float[];
                    byte[] result = new byte[temp.Length * sizeof(float)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
                else if (m_value is double[])
                {
                    double[] temp = m_value as double[];
                    byte[] result = new byte[temp.Length * sizeof(double)];
                    int resultOffset = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(temp[i]);
                        Array.Copy(bytes, 0, result, resultOffset, bytes.Length);
                        resultOffset += bytes.Length;
                    }
                    return result;
                }
            }
            else if (m_value is string)
                return Encoding.GetEncoding("Latin1").GetBytes(m_value as string);

            return null;
        }

        public byte[] ToByteArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is byte[])
                    return m_value as byte[];
                else if (m_value is short[])
                {
                    short[] temp = m_value as short[];
                    byte[] result = new byte[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (byte)temp[i];

                    return result;
                }
                else if (m_value is ushort[])
                {
                    ushort[] temp = m_value as ushort[];
                    byte[] result = new byte[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (byte)temp[i];

                    return result;
                }
                else if (m_value is int[])
                {
                    int[] temp = m_value as int[];
                    byte[] result = new byte[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (byte)temp[i];

                    return result;
                }
                else if (m_value is uint[])
                {
                    uint[] temp = m_value as uint[];
                    byte[] result = new byte[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (byte)temp[i];

                    return result;
                }
            }
            else if (m_value is string)
                return Encoding.GetEncoding("Latin1").GetBytes(m_value as string);

            return null;
        }

        public short[] ToShortArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is short[])
                    return m_value as short[];
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    short[] result = new short[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (short)temp[i];

                    return result;
                }
                else if (m_value is ushort[])
                {
                    ushort[] temp = m_value as ushort[];
                    short[] result = new short[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (short)temp[i];

                    return result;
                }
                else if (m_value is int[])
                {
                    int[] temp = m_value as int[];
                    short[] result = new short[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (short)temp[i];

                    return result;
                }
                else if (m_value is uint[])
                {
                    uint[] temp = m_value as uint[];
                    short[] result = new short[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (short)temp[i];

                    return result;
                }
            }

            return null;
        }

        public ushort[] ToUShortArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is ushort[])
                    return m_value as ushort[];
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    ushort[] result = new ushort[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (ushort)temp[i];

                    return result;
                }
                else if (m_value is short[])
                {
                    short[] temp = m_value as short[];
                    ushort[] result = new ushort[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (ushort)temp[i];

                    return result;
                }
                else if (m_value is int[])
                {
                    int[] temp = m_value as int[];
                    ushort[] result = new ushort[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (ushort)temp[i];

                    return result;
                }
                else if (m_value is uint[])
                {
                    uint[] temp = m_value as uint[];
                    ushort[] result = new ushort[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (ushort)temp[i];

                    return result;
                }
            }

            return null;
        }

        public int[] ToIntArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is int[])
                    return m_value as int[];
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    int[] result = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (int)temp[i];

                    return result;
                }
                else if (m_value is short[])
                {
                    short[] temp = m_value as short[];
                    int[] result = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (int)temp[i];

                    return result;
                }
                else if (m_value is ushort[])
                {
                    ushort[] temp = m_value as ushort[];
                    int[] result = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (int)temp[i];

                    return result;
                }
                else if (m_value is uint[])
                {
                    uint[] temp = m_value as uint[];
                    int[] result = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (int)temp[i];

                    return result;
                }
            }

            return null;
        }

        public uint[] ToUIntArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is uint[])
                    return m_value as uint[];
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    uint[] result = new uint[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (uint)temp[i];

                    return result;
                }
                else if (m_value is short[])
                {
                    short[] temp = m_value as short[];
                    uint[] result = new uint[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (uint)temp[i];

                    return result;
                }
                else if (m_value is ushort[])
                {
                    ushort[] temp = m_value as ushort[];
                    uint[] result = new uint[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (uint)temp[i];

                    return result;
                }
                else if (m_value is int[])
                {
                    int[] temp = m_value as int[];
                    uint[] result = new uint[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (uint)temp[i];

                    return result;
                }
            }

            return null;
        }

        public float[] ToFloatArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is float[])
                    return m_value as float[];
                else if (m_value is double[])
                {
                    double[] temp = m_value as double[];
                    float[] result = new float[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (float)temp[i];

                    return result;
                }
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    int tempPos = 0; 
                    
                    int floatCount = temp.Length / sizeof(float);
                    float[] result = new float[floatCount];
                    
                    for (int i = 0; i < floatCount; i++)
                    {
                        float f = BitConverter.ToSingle(temp, tempPos);
                        result[i] = f;
                        tempPos += sizeof(float);
                    }

                    return result;
                }
            }

            return null;
        }

        public double[] ToDoubleArray()
        {
            if (m_value == null)
                return null;

            Type t = m_value.GetType();
            if (t.IsArray)
            {
                if (m_value is double[])
                    return m_value as double[];
                else if (m_value is float[])
                {
                    float[] temp = m_value as float[];
                    double[] result = new double[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                        result[i] = (double)temp[i];

                    return result;
                }
                else if (m_value is byte[])
                {
                    byte[] temp = m_value as byte[];
                    int tempPos = 0;

                    int floatCount = temp.Length / sizeof(double);
                    double[] result = new double[floatCount];

                    for (int i = 0; i < floatCount; i++)
                    {
                        double d = BitConverter.ToDouble(temp, tempPos);
                        result[i] = d;
                        tempPos += sizeof(double);
                    }

                    return result;
                }
            }

            return null;
        }
    }
}
