using DataService.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NineWebService.Models;
using NineWebService.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProcessRequestData_TwoShowsAllActiveShows_Processed()
        {
            // Arrange
            RequestDataProcessor processor = new RequestDataProcessor();
            int numActiveShows = 2;
            int numTotalShows = 2;
            var data = GetTestData(numActiveShows, numTotalShows);

            // Act
            var result = processor.ProcessRequestData(data).ToArray();

            // Assert
            Assert.AreEqual(numActiveShows, result.Length);
            Assert.AreEqual(numTotalShows, result.Length);
        }

        [TestMethod]
        public void ProcessRequestData_FourShowsNoActiveShows_Processed()
        {
            // Arrange
            RequestDataProcessor processor = new RequestDataProcessor();
            int numActiveShows = 0;
            int numTotalShows = 4;
            var data = GetTestData(numActiveShows, numTotalShows);

            // Act
            var result = processor.ProcessRequestData(data).ToArray();

            // Assert
            Assert.AreEqual(numActiveShows, result.Length);
        }

        [TestMethod]
        public void ProcessRequestData_OneActiveShowCheckDataConsistency_Processed()
        {
            // Arrange
            RequestDataProcessor processor = new RequestDataProcessor();
            int numActiveShows = 1;
            int numTotalShows = 1;
            var data = GetTestData(numActiveShows, numTotalShows);

            // Act
            var result = processor.ProcessRequestData(data).Select(d => d as Show).ToArray();

            // Assert
            Assert.AreEqual("The slug", result[0].Slug);
            Assert.AreEqual("The title", result[0].Title);
            Assert.AreEqual("url image", result[0].Image);
        }

        private IEnumerable<Payload> GetTestData(int numActiveShows, int numTotalShows)
        {
            string slug = "The slug";
            string title = "The title";
            Image image = new Image { ShowImage = "url image" };
            Random random = new Random();
            int activeShowsCounter = 0;

            Payload[] payload = new Payload[numTotalShows];

            for (int i = 0; i < numTotalShows; i++)
            {
                if (activeShowsCounter < numActiveShows)
                {
                    activeShowsCounter++;

                    payload[i] = new Payload
                    {
                        Image = image,
                        Drm = true,
                        EpisodeCount = random.Next(1, 11),
                        Slug = slug,
                        Title = title
                    };
                }
                else
                {
                    payload[i] = new Payload
                    {
                        Image = image,
                        Drm = (i % 2 == 0) ? true : false,
                        EpisodeCount = 0,
                        Slug = slug,
                        Title = title
                    };
                }
            }


            return payload;
        }
    }
}
