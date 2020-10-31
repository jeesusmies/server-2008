using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace server2008.server.tcp
{
    class PacketHandler {
        public PacketHandler() { }

        // Written by Eeveelution using Gulag as reference? idk he just gave these
        private static byte[] Write_Uleb128(int num) {
            List<byte> ret = new List<byte>();

            if (num == 0) {
                return new byte[] { 0x00 };
            }

            int length = 0;

            while (num > 0) {
                ret.Add((byte)(num & 127));
                num >>= 7;
                if (num != 0) {
                    ret[length] |= 128;
                }
                length += 1;
            }

            return ret.ToArray();
        }

        private static byte[] WriteString(string s) {

            if (s.Length == 0) {
                return new byte[] { 0x00 };
            }

            List<byte> ret = new List<byte>();

            ret.Add(11);

            ret.AddRange(Write_Uleb128(s.Length));
            ret.AddRange(Encoding.UTF8.GetBytes(s));

            return ret.ToArray();
        }

        public byte[] LoginPacket(int loginStatus) {
            byte[] data;
            using (MemoryStream ms = new MemoryStream()) {
                using (BinaryWriter wr = new BinaryWriter(ms)) {
                    wr.Write((short)0x05);
                    wr.Write((byte)0x00);
                    wr.Write((int)0x04);
                    wr.Write((int)loginStatus);
                }
                data = ms.ToArray();
            }
            return data;
        }

        public byte[] UserStatsPacket(long score) {
            byte[] data;
            int packetSize;
            using (MemoryStream ms = new MemoryStream()) {
                using (BinaryWriter wr = new BinaryWriter(ms)) {
                    // hard coded values, need to implement database stuff for these
                    // also thanks Eeveelution for what values osu needs for user stat packets
                    byte[] actionString = WriteString("lol"); // dunno for what yet
                    byte[] actionStringMD5 = WriteString("9cdfb439c7876e703e307864c9167a15");
                    packetSize = 35 + actionString.Length + actionStringMD5.Length;

                    wr.Write((short)12);
                    wr.Write((byte)0);
                    wr.Write((int)packetSize);
                    wr.Write((int)1);
                    
                    wr.Write((byte)1);
                    wr.Write((byte)1);
                    wr.Write((bool)true);
                    wr.Write(actionString);
                    wr.Write(actionStringMD5);
                    wr.Write((short)0x00);
                    
                    wr.Write((long)score); // score
                    wr.Write((float)90.00); // acc
                    wr.Write((int)12345); // playcount?
                    wr.Write((long)1235654); // some other score?
                    wr.Write((short)0); // rank
                    /*
                    */
                }
                data = ms.ToArray();
            }
            return data;
        }
    }
}
