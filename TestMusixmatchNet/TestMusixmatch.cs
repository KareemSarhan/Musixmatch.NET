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

            Assert.AreEqual(actual, expected, $"Artist name Expected {expected} Was {actual}");
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
                Assert.AreEqual(actual, expected, $"Expected {expected} Was {actual}");
            }
        }

        [TestMethod]
        public void TestGetAlbumValid()
        {
            Musixmatch Musixmatch = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            Album Album = Musixmatch.GetAlbum("14250417");

            String actual = Album.ArtistName;
            String expected = "LMFAO";

            Assert.AreEqual(actual, expected, $"Artist name Expected {expected} Was {actual}");
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
                Assert.AreEqual(actual, expected, $"Expected {expected} Was {actual}");
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
