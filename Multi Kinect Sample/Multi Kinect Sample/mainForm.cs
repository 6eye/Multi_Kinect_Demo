using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Drawing.Imaging;

namespace Multi_Kinect_Sample
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            int kinectCount = 0;
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                switch (kinectCount)
                {
                    case 0:
                        kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(mainForm_ColorFrameReady1);
                        break;
                    case 1:
                        kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(mainForm_ColorFrameReady2);
                        break;
                    case 2:
                        kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(mainForm_ColorFrameReady3);
                        break;
                    case 3:
                        kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(mainForm_ColorFrameReady4);
                        break;
                }
                kinect.DepthStream.Disable();
                kinect.SkeletonStream.Disable();
                // Enable the color stream at 640x480 resolution and 30 frames per second.
                kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                // Start the Kinect camera.
                kinect.Start();
                kinectCount += 1;
            }
        }

        void setImage(int imageIndex, ColorImageFrame frame)
        {
            // Check that the frame is not empty.
            if (frame != null)
            {
                // Create an array of bytes to hold the data.
                byte[] pixelData = new byte[frame.PixelDataLength];
                // Copy the pixel data to the array.
                frame.CopyPixelDataTo(pixelData);

                // Create a bmp to hold the actual image.
                Bitmap bmp = new Bitmap(frame.Width, frame.Height, PixelFormat.Format32bppRgb);
                // Create the bitmap data to hold the data for the image.
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                // Create the pointer to the bmp data.
                IntPtr ptr = bmpData.Scan0;
                // Then copy the actual data to the bmp.
                System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, ptr, frame.PixelDataLength);
                // Unlock the bmp data bits so they can be used.
                bmp.UnlockBits(bmpData);
                switch (imageIndex)
                {
                    case 0:
                        // Set the color image to the bmp image.
                        this.kinectPB1.Image = bmp;
                        break;
                    case 1:
                        // Set the color image to the bmp image.
                        this.kinectPB2.Image = bmp;
                        break;
                    case 2:
                        // Set the color image to the bmp image.
                        this.kinectPB3.Image = bmp;
                        break;
                    case 3:
                        // Set the color image to the bmp image.
                        this.kinectPB4.Image = bmp;
                        break;
                }

                // Dispose of the frame.
                frame.Dispose();
            }
        }

        void mainForm_ColorFrameReady(int imageIndex, object sender, ColorImageFrameReadyEventArgs e)
        {
            // Create a color frame to hold the color frame that was recieved.
            ColorImageFrame frame = e.OpenColorImageFrame();
            setImage(imageIndex, frame);
        }

        void mainForm_ColorFrameReady1(object sender, ColorImageFrameReadyEventArgs e)
        {
            mainForm_ColorFrameReady(0, sender, e);
        }
        void mainForm_ColorFrameReady2(object sender, ColorImageFrameReadyEventArgs e)
        {
            mainForm_ColorFrameReady(1, sender, e);
        }
        void mainForm_ColorFrameReady3(object sender, ColorImageFrameReadyEventArgs e)
        {
            mainForm_ColorFrameReady(2, sender, e);
        }
        void mainForm_ColorFrameReady4(object sender, ColorImageFrameReadyEventArgs e)
        {
            mainForm_ColorFrameReady(3, sender, e);
        }
    }
}
