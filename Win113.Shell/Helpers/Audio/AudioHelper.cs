using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Win113.Shell.Helpers.Audio
{
    public static class AudioHelper
    {

        static Microsoft.VisualBasic.Devices.Audio myAudio = new Microsoft.VisualBasic.Devices.Audio();
        private static byte[] myWaveData;

        // Sample rate (Or number of samples in one second)
        private const int SAMPLE_FREQUENCY = 44100;
        // 60 seconds or 1 minute of audio
        private const int AUDIO_LENGTH_IN_SECONDS = 1;


        public static bool PlayDTMF(string keyPressed)
        {
            // DTMF sine waves frequencies
            SineGenerator row1 = new SineGenerator(697.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator row2 = new SineGenerator(770.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator row3 = new SineGenerator(852.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator row4 = new SineGenerator(941.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator column1 = new SineGenerator(1209.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator column2 = new SineGenerator(1336.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator column3 = new SineGenerator(1477.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);
            SineGenerator column4 = new SineGenerator(1633.0f, SAMPLE_FREQUENCY, AUDIO_LENGTH_IN_SECONDS);

            List<Byte> tempBytes = new List<byte>();

            WaveHeader header = new WaveHeader();
            FormatChunk format = new FormatChunk();
            DataChunk data = new DataChunk();

            SineGenerator leftData;
            SineGenerator rightData;

            // Create two sine waves corresponding to the pressed key
            switch (keyPressed.ToUpperInvariant())
            {
                case "1":
                    leftData = row1;
                    rightData = column1;
                    break;
                case "2":
                    leftData = row1;
                    rightData = column2;
                    break;
                case "3":
                    leftData = row1;
                    rightData = column3;
                    break;
                case "A":
                    leftData = row1;
                    rightData = column4;
                    break;

                case "4":
                    leftData = row2;
                    rightData = column1;
                    break;
                case "5":
                    leftData = row2;
                    rightData = column2;
                    break;
                case "6":
                    leftData = row2;
                    rightData = column3;
                    break;
                case "B":
                    leftData = row2;
                    rightData = column4;
                    break;

                case "7":
                    leftData = row3;
                    rightData = column1;
                    break;
                case "8":
                    leftData = row3;
                    rightData = column2;
                    break;
                case "9":
                    leftData = row3;
                    rightData = column3;
                    break;
                case "C":
                    leftData = row3;
                    rightData = column4;
                    break;

                case "*":
                    leftData = row4;
                    rightData = column1;
                    break;
                case "0":
                    leftData = row4;
                    rightData = column2;
                    break;
                case "#":
                    leftData = row4;
                    rightData = column3;
                    break;
                case "D":
                    leftData = row4;
                    rightData = column4;
                    break;

                default:
                    return false;
            }

            data.AddSampleData(leftData.Data, rightData.Data);

            header.FileLength += format.Length() + data.Length();

            tempBytes.AddRange(header.GetBytes());
            tempBytes.AddRange(format.GetBytes());
            tempBytes.AddRange(data.GetBytes());

            myWaveData = tempBytes.ToArray();

            myAudio.Play(myWaveData, AudioPlayMode.Background);
            return true;
        }

        public static void StopDTMF()
        {
            myAudio.Stop();
        }
    }
}
