﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;


namespace Kubility
{
    public class JsonMessageHead : MessageHead
    {

    }

    public sealed class JsonMessage : BaseMessage
    {

        public string jsonData
        {
            get
            {
                return DataBody.m_FirstValue;
            }
        }

        /// <summary>
        /// create send json data
        /// </summary>
        /// <param name="data">Data.</param>
        /// <param name="jhead">Jhead.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static JsonMessage Create<T>(T data, JsonMessageHead jhead = null)
        {

			if(MessageInfo.MessageType != MessageDataType.Json)
			{
				LogMgr.LogError("cant use Json message  because your MessageType is "+ MessageInfo.MessageType);
				return null;
			}
            JsonMessage message = new JsonMessage();
            message.messageType = KMessageType.None;
            message.DataBody.m_FirstValue = ParseUtils.Json_Serialize(data);
            if (jhead != null)
            {
                message.head = jhead;
                message.messageType = (KMessageType)jhead.CMD;
            }

            return message;
        }

        public static JsonMessage CreateAsNet(byte[] buffer, MessageHead jhead = null)
        {
			if(MessageInfo.MessageType != MessageDataType.Json)
			{
				LogMgr.LogError("cant use Json message  because your MessageType is "+ MessageInfo.MessageType);
				return null;
			}
            JsonMessage message = new JsonMessage();
            message.messageType = KMessageType.None;
            if (BitConverter.IsLittleEndian)
                Array.Reverse(buffer);

            message.DataBody.m_FirstValue = System.Text.Encoding.UTF8.GetString(buffer);
            if (jhead != null)
            {
                message.head = jhead;
                message.messageType = (KMessageType)jhead.CMD;
            }

            return message;
        }

        /// <summary>
        /// receive json data
        /// </summary>
        /// <param name="ev">Ev.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public override void Wait_Deserialize<T>(Action<T> ev)
        {
			if(MessageInfo.MessageType != MessageDataType.Json)
			{
				LogMgr.LogError("cant use Json message  because your MessageType is "+ MessageInfo.MessageType);
				return ;
			}

            MessageManager.mIns.PushToWaitQueue(this, delegate(string value)
            {
                T obj = default(T);
                if (!string.IsNullOrEmpty(value))
                {
                    obj = ParseUtils.Json_Deserialize<T>(value);
                }
                ev(obj);
            });
        }

        /// <summary>
        /// Serialize the send data
        /// </summary>

        public override byte[] Serialize(bool addHead = true)
        {
			if(MessageInfo.MessageType != MessageDataType.Json)
			{
				LogMgr.LogError("cant use Json message  because your MessageType is "+ MessageInfo.MessageType);
				return null;
			}
            ByteBuffer buffer = new ByteBuffer(1024);

            var bys = System.Text.Encoding.UTF8.GetBytes(DataBody.m_FirstValue);

            if (head != null && addHead)
            {
                head.bodyLen = (uint)bys.Length;
                buffer += head.Serialize();
            }

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bys);
            buffer += bys;

            return buffer.ConverToBytes();

        }

    }
}


