﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TagsCloudVisualization.ColorGenerators;

namespace TagsCloudVisualization.Tests
{
    public class CircularCloudLayouterTestsLogger
    {
        private readonly SizeF _cloudScale = new(0.7f, 0.7f);
        private readonly TagsCloudDrawer _drawer = new(new RainbowColorGenerator(new Random()));
        private readonly Size _imageSize = new(1000, 1000);
        private string _outputDirectory;

        public void Log(Rectangle[] rectangles, string testName)
        {
            if (string.IsNullOrEmpty(_outputDirectory))
                throw new Exception($"{nameof(_outputDirectory)} was null or empty");
            var path = Path.Combine(_outputDirectory, testName + ".bmp");
            var image = _drawer.Draw(rectangles, _imageSize, _cloudScale);
            image.Save(path, ImageFormat.Bmp);
            Console.WriteLine($"Tag cloud visualization saved to file {path}");
        }

        public void Init(string outputDirectory)
        {
            _outputDirectory = outputDirectory;
            RecreateDirectory(outputDirectory);
        }

        private static void RecreateDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var directoryInfo = new DirectoryInfo(directory);
                foreach (var file in directoryInfo.GetFiles()) file.Delete();
            }
            else
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}