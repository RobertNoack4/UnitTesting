using TestNinja.Mocking;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_repository.Object);
        }
        
        
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns(" ");

            _videoService = new VideoService();

            var result = _videoService.ReadVideoTitle(_fileReader.Object);

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AFewUnProcessedVideos_ReturnAStringWithIdOfUnProcessedVideos()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3},
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
