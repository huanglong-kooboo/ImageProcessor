﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PngFormat.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Provides the necessary information to support png images.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Imaging.Formats
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Provides the necessary information to support png images.
    /// </summary>
    public class PngFormat : FormatBase
    {
        /// <summary>
        /// Gets the file headers.
        /// </summary>
        public override byte[][] FileHeaders
        {
            get
            {
                return new[] { new byte[] { 137, 80, 78, 71 } };
            }
        }

        /// <summary>
        /// Gets the list of file extensions.
        /// Obviously png8 isn't a valid file extension but it's a neat way to 
        /// add the value to the format method detection.
        /// </summary>
        public override string[] FileExtensions
        {
            get
            {
                return new[] { "png" };
            }
        }

        /// <summary>
        /// Gets the standard identifier used on the Internet to indicate the type of data that a file contains. 
        /// </summary>
        public override string MimeType
        {
            get
            {
                return "image/png";
            }
        }

        /// <summary>
        /// Gets the <see cref="ImageFormat" />.
        /// </summary>
        public override ImageFormat ImageFormat
        {
            get
            {
                return ImageFormat.Png;
            }
        }

        /// <summary>
        /// Saves the current image to the specified output stream.
        /// </summary>
        /// <param name="stream">The <see cref="T:System.IO.Stream" /> to save the image information to.</param>
        /// <param name="image">The <see cref="T:System.Drawing.Image" /> to save.</param>
        /// <returns>
        /// The <see cref="T:System.Drawing.Image" />.
        /// </returns>
        public override Image Save(Stream stream, Image image)
        {
            if (this.IsIndexed)
            {
                image = new OctreeQuantizer(255, 8).Quantize(image);
            }

            return base.Save(stream, image);
        }

        /// <summary>
        /// Saves the current image to the specified file path.
        /// </summary>
        /// <param name="path">The path to save the image to.</param>
        /// <param name="image">The 
        /// <see cref="T:System.Drawing.Image" /> to save.</param>
        /// <returns>
        /// The <see cref="T:System.Drawing.Image" />.
        /// </returns>
        public override Image Save(string path, Image image)
        {
            if (this.IsIndexed)
            {
                image = new OctreeQuantizer(255, 8).Quantize(image);
            }

            return base.Save(path, image);
        }
    }
}