using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerData
{
    public enum Packet
    {
        Spawn = 1,
        Move,
        Attack,
    }

    class Packet
    {
        private List<byte> buffer;
        private byte[] readableBuffer;
        private int readPos;
    }
}