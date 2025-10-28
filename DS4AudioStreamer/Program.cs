﻿using DS4AudioStreamer;
using DS4AudioStreamer.Sound;

// Allow sleep time durations less than 16 ms
//DS4Windows.NativeMethods.timeBeginPeriod(1);

var hidDevices = DeviceEnumerator.FindDevices();

var usedDevice = hidDevices.FirstOrDefault();

if (null == usedDevice)
{
    Console.WriteLine("No device found");
    return;
}

usedDevice.OpenDevice(true);

if (!usedDevice.IsOpen)
{
    Console.WriteLine("Could not open device exclusively :(");
    usedDevice.OpenDevice(false);
}

var captureWorker = new NewCaptureWorker(usedDevice);
captureWorker.Start();

while (usedDevice.IsConnected)
{
    Thread.Sleep(1000);
}

// Allow sleep time durations less than 16 ms
//DS4Windows.NativeMethods.timeEndPeriod(1);