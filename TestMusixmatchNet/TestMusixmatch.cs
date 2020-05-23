using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MusixmatchNet;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace TestMusixmatchNet
{
    [TestClass]
    public class TestMusixmatchBase
    {
        
    }
    [TestClass]
    public class TestMusixmatchTrack
    {

    }
    [TestClass]
    public class TestMusixmatchArtist
    {
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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
            }
        }
        [TestMethod]
        public void TestGetArtistsChartValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetArtistsChart("us").ElementAt(0).ArtistCountry;
            String expected = "US";

            Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");

        }
        [TestMethod]

        public void TestGetArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            String actual = Musixmatch.GetArtist("123").ArtistName;
            String expected = "Sheryl Crow";

            Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");

        }
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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
            }

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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
            }

        }
        [TestMethod]
        public void TestSearchArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
                List<Artist> ArtistList = Musixmatch.SearchArtist("Sia");
                String actual = ArtistList.ElementAt(0).ArtistName;
                String expected = "Sia";
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
            }

        }
        [TestMethod]
        public void TestGetRelatedArtistValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            List<Artist> ArtistList = Musixmatch.GetRelatedArtist("56");
            String actual = ArtistList.ElementAt(0).ArtistName;
            String expected = "OutKast";
            Assert.AreEqual(expected,actual, $"Expected {expected} Was {actual}");
        }
    }
    [TestClass]
    public class TestMusixmatchAlbum
    {
        [TestMethod]
        public void TestGetArtistAlbumsValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            List<Album> AlbumList = Musixmatch.GetArtistAlbums("41659");

            String actual = AlbumList[0].ArtistName;
            String expected = "Sia";

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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
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
                Assert.AreEqual(expected, actual, $"Expected {expected} Was {actual}");
            }
        }
    }
    [TestClass]
    public class TestMusixmatchLyrics
    {

    }  
    [TestClass]
    public class TestMusixmatchSubtitle
    {

    }   
    [TestClass]
    public class TestMusixmatchSnippet
    {

    }  
    [TestClass]
    public class TestMusixmatchCustom
    {

    }
}
