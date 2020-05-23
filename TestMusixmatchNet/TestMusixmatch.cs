using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusixmatchNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMusixmatchNet
{
    [TestClass]
    public class TestMusixmatchAlbum
    {
        [TestMethod]
        public void TestGetAlbumNull()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                Album Album = Musixmatch.GetAlbum("696969696969696969");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetAlbumValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            Album Album = Musixmatch.GetAlbum("14250417");

            String actual = Album.ArtistName;
            String expected = "LMFAO";

            Assert.AreEqual(expected, actual, $"Artist name Expected {expected} Was {actual}");
        }

        [TestMethod]
        public void TestGetArtistAlbumsNull()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Album> AlbumList = Musixmatch.GetArtistAlbums("696969696969696969");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetArtistAlbumsValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            List<Album> AlbumList = Musixmatch.GetArtistAlbums("41659");

            String actual = AlbumList[0].ArtistName;
            String expected = "Sia";

            Assert.AreEqual(expected, actual, $"Artist name Expected {expected} Was {actual}");
        }
    }

    [TestClass]
    public class TestMusixmatchArtist
    {
        [TestMethod]
        public void TestGetArtistInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                Artist Artist = Musixmatch.GetArtist("999999999999");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetArtistsChartNull()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Artist> Album = Musixmatch.GetArtistsChart("ussssss");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetArtistsChartValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetArtistsChart("us").ElementAt(0).ArtistCountry;
            String expected = "US";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetArtist("123").ArtistName;
            String expected = "Sheryl Crow";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetRelatedArtistInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Artist> ArtistList = Musixmatch.GetRelatedArtist("-");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetRelatedArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            List<Artist> ArtistList = Musixmatch.GetRelatedArtist("56");
            String actual = ArtistList.ElementAt(0).ArtistName;
            String expected = "OutKast";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchArtistInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Artist> ArtistList = Musixmatch.SearchArtist("-");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestSearchArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            List<Artist> ArtistList = Musixmatch.SearchArtist("Sia");
            String actual = ArtistList.ElementAt(0).ArtistName;
            String expected = "Sia";
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class TestMusixmatchBase
    {
    }

    [TestClass]
    public class TestMusixmatchCustom
    {
    }

    [TestClass]
    public class TestMusixmatchLyrics
    {
    }

    [TestClass]
    public class TestMusixmatchSnippet
    {
    }

    [TestClass]
    public class TestMusixmatchSubtitle
    {
    }

    [TestClass]
    public class TestMusixmatchTrack
    {
        [TestMethod]
        public void TestGetAlbumTracksInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Track> Track = Musixmatch.GetAlbumTracks("-1", "");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetAlbumTracksValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetAlbumTracks("13750844").ElementAt(0).AlbumName;
            String expected = "Parachutes";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetMatcherTrackInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                Track Track = Musixmatch.GetMatcherTrack();
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 400 : The request had bad syntax or was inherently impossible to be satisfied.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetMatcherTrackValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetMatcherTrack("eminem", "lose yourself").AlbumName;
            String expected = "Let That Sink In";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetTrackInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                Track Track = Musixmatch.GetTrack("-1");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetTracksChartInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Track> Track = Musixmatch.GetTracksChart("-1", "");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGetTracksChartValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetTracksChart("it").ElementAt(0).AlbumName;
            String expected = "Insieme: Grandi Amori";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetTrackValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetTrack("5920049").AlbumName;
            String expected = "Five Leaves Left";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchTrackInvalid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            try
            {
                List<Track> Track = Musixmatch.SearchTrack("-1", "");
            }
            catch (StatusCodeException e)
            {
                String actual = e.Message;
                String expected = "STATUS CODE 404 : The requested resource was not found.";
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestSearchTrackValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.SearchTrack(q_artist: "justin bieber").ElementAt(0).AlbumName;
            String expected = "Scarlatti, Rameau & Chopin: Piano Works";

            Assert.AreEqual(expected, actual);
        }
    }
}