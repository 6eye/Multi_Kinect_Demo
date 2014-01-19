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
        /// <summary>
        /// A dictionary containing the list of Kinect IDs and image indexes associated with them for drawing
        /// to the screen.
        /// </summary>
        Dictionary<String, int> KinectIDs;

        /// <summary>
        /// The constructor for the main form.  This initializes the components and the variables used.
        /// </summary>
        public mainForm()
        {
            // Setup the dictionary containing the Kinect IDs.
            KinectIDs = new Dictionary<string, int>();
            // Initializes the components.
            InitializeComponent();
        }

        /// <summary>
        /// Called when the main form is loaded.  Handles initializing the Kinects.
        /// </summary>
        /// <param name="sender">The form calling the load method.</param>
        /// <param name="e">Any arguments to go with this event.</param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            // Count how many Kinects are attached.
            int kinectCount = 0;
            // Loop through each Kinect.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                // Add the Kinect's Unique ID as a key and the kinect sensor index as the count.
                KinectIDs.Add(kinect.UniqueKinectId, kinectCount);
                // Increment the Kinect count.
                kinectCount += 1;

                // Setup the color frame event handler;
                kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(mainForm_ColorFrameReady);
                // Enable the color stream at 640x480 resolution and 30 frames per second.
                kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                // Start the Kinect camera.
                kinect.Start();
            }
        }

        /// <summary>
        /// Sets the desired picture box image.  Can do so for up to 4 images.
        /// </summary>
        /// <param name="imageIndex">The index of the picture box image to set.</param>
        /// <param name="frame">The Kinect's color image frame to use.</param>
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
                // Switch through the image index.
                switch (imageIndex)
                {
                    case 0:
                        // Set the color image for the 1st picture box to the bmp image.
                        this.kinectPB1.Image = bmp;
                        break;
                    case 1:
                        // Set the color image for the 2nd picture box to the bmp image.
                        this.kinectPB2.Image = bmp;
                        break;
                    case 2:
                        // Set the color image for the 3rd picture box to the bmp image.
                        this.kinectPB3.Image = bmp;
                        break;
                    case 3:
                        // Set the color image for the 4th picture box to the bmp image.
                        this.kinectPB4.Image = bmp;
                        break;
                }

                // Dispose of the frame.
                frame.Dispose();
            }
        }

        /// <summary>
        /// The event called when a new color frame is recieved from a Kinect.
        /// </summary>
        /// <param name="sender">The Kinect that is calling this method.</param>
        /// <param name="e">The event arguements (such as the color image).</param>
        void mainForm_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            // Create a color frame to hold the color frame that was recieved.
            KinectSensor sensor = (KinectSensor)sender;
            // Create an image index.
            int imageIndex = 0;

            // Try to get the index associated with the Kinect's unique ID.
            if (KinectIDs.TryGetValue(sensor.UniqueKinectId, out imageIndex))
            {
                // Get the color frame from the device.
                ColorImageFrame frame = e.OpenColorImageFrame();
                // Set the picture box image at the specified index with the color image frame.
                setImage(imageIndex, frame);
            }
        }
    }
}
