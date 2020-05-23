namespace MusixmatchNet
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ReturnJson
    {
        public static Album From_AlbumToAlbum(_Album _Album) 
        {
            Album TempAlbum = new Album(_Album);
            if (_Album._PrimaryGenres != null)
                    foreach (_MusicGenreList _MusicGenreList in _Album._PrimaryGenres._MusicGenreList)
                {
                    TempAlbum.MusicGenreList.Add(new MusicGenre(_MusicGenreList));
                }
            if(_Album._SecondaryGenres != null)
                foreach (_MusicGenreList _MusicGenreList in _Album._SecondaryGenres._MusicGenreList)
                {
                    TempAlbum.MusicGenreList.Add(new MusicGenre(_MusicGenreList));
                }
            return TempAlbum;
        }

        public static List<Album> FromRawJsonToAlbumList(RawJson RawJson) 
        {
            List<Album> AlbumList = new List<Album>();
            if(RawJson._Message._Body._AlbumList!=null)
                foreach (_AlbumList _AlbumList in RawJson._Message._Body._AlbumList)
                {
                    AlbumList.Add(From_AlbumToAlbum(_AlbumList._Album));
                }
            return AlbumList;
        }
        public static Artist From_ArtistToArtist(_Artist _Artist)
        {
            Artist TempArtist = new Artist(_Artist);
            if (_Artist._PrimaryGenres != null)
                foreach (_MusicGenreList _MusicGenreList in _Artist._PrimaryGenres._MusicGenreList)
                {
                    TempArtist.MusicGenreList.Add(new MusicGenre(_MusicGenreList));
                }
            if (_Artist._SecondaryGenres != null)
                foreach (_MusicGenreList _MusicGenreList in _Artist._SecondaryGenres._MusicGenreList)
                {
                    TempArtist.MusicGenreList.Add(new MusicGenre(_MusicGenreList));
                }
            if (_Artist._ArtistAliasList != null)
                foreach (_ArtistAliasList _ArtistAliasList in _Artist._ArtistAliasList)
                {
                    TempArtist.ArtistAliasList.Add(_ArtistAliasList._ArtistAlias);
                }
            if (_Artist._ArtistNameTranslationList != null)
                foreach (_ArtistNameTranslationList _ArtistNameTranslationList in _Artist._ArtistNameTranslationList)
                {
                        TempArtist.ArtistNameTranslationList.Add(new ArtistNameTranslation(_ArtistNameTranslationList));
                }
            return TempArtist;
        }
        public static List<Artist> FromRawJsonToArtistList(RawJson RawJson) 
        {
            List<Artist> ArtistList = new List<Artist>();
            if (RawJson._Message._Body._ArtistList != null)
                foreach (_ArtistList _ArtistList in RawJson._Message._Body._ArtistList)
                {
                    ArtistList.Add(From_ArtistToArtist(_ArtistList._Artist));
                }
            return ArtistList;
        }
    }

    public class Artist 
    {
        public Artist(_Artist _Artist)
        {
            this.ArtistVanityId = _Artist._ArtistVanityId;
            this.ArtistCountry = _Artist._ArtistCountry;
            this.ArtistComment = _Artist._ArtistComment;
            this.ArtistEditUrl = _Artist._ArtistEditUrl;
            this.ArtistMbid = _Artist._ArtistMbid;
            this.ArtistName = _Artist._ArtistName;
            this.Restricted = _Artist._Restricted;
            this.UpdatedTime = _Artist._UpdatedTime;
            this.ArtistEditUrl = _Artist._ArtistEditUrl;
            this.ArtistShareUrl = _Artist._ArtistShareUrl;
            this.ArtistId = _Artist._ArtistId;
            this.UpdatedTime = _Artist._UpdatedTime;
            this.Managed = _Artist._Managed;
            this.ArtistTwitterUrl = _Artist._ArtistTwitterUrl;
            this.ArtistRating = _Artist._ArtistRating;
            this.MusicGenreList =new List<MusicGenre>();
            this.ArtistAliasList=new List<String>();
            this.ArtistNameTranslationList=new List<ArtistNameTranslation>();
        }

        public ArtistCredits ArtistCredits { get; set; }

        public string ArtistMbid { get; set; }

        public string ArtistName { get; set; }

        public List<MusicGenre> MusicGenreList { get; set; }

        public List<String> ArtistAliasList { get; set; }

        public string ArtistVanityId { get; set; }

        public long Restricted { get; set; }

        public string ArtistCountry { get; set; }

        public string ArtistComment { get; set; }

        public List<ArtistNameTranslation> ArtistNameTranslationList { get; set; }

        public string ArtistEditUrl { get; set; }

        public string ArtistShareUrl { get; set; }

        public long ArtistId { get; set; }

        public string UpdatedTime { get; set; }

        public long Managed { get; set; }

        public string ArtistTwitterUrl { get; set; }

        public long ArtistRating { get; set; }

    }
    public class ArtistNameTranslation
    {
        public ArtistNameTranslation(_ArtistNameTranslationList _ArtistNameTranslationList)
        {
            this.Language = _ArtistNameTranslationList._ArtistNameTranslation._Language;
            this.Translation = _ArtistNameTranslationList._ArtistNameTranslation._Language;
        }
        public string Language { get; set; }

        public string Translation { get; set; }
    }
    public class ArtistCredits
    {
        [JsonProperty("artist_list")]
        public List<Artist> ArtistList { get; set; }
    }
    public class Album
    {
        public long AlbumId { get; set; }

        public string AlbumMbid { get; set; }

        public string AlbumName { get; set; }

        public long AlbumRating { get; set; }

        public string AlbumReleaseDate { get; set; }

        public long ArtistId { get; set; }

        public string ArtistName { get; set; }

        public List<MusicGenre> MusicGenreList { get; set; }

        public string AlbumPline { get; set; }

        public string AlbumCopyright { get; set; }

        public string AlbumLabel { get; set; }

        public long Restricted { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }

        public string AlbumCoverart { get; set; }

        public Album() { }

        public Album(_AlbumList _AlbumList) 
        {
            this.AlbumCopyright=_AlbumList._Album._AlbumCopyright;
            this.AlbumId=_AlbumList._Album._AlbumId;
            this.AlbumLabel=_AlbumList._Album._AlbumLabel;
            this.AlbumMbid=_AlbumList._Album._AlbumMbid;
            this.AlbumName=_AlbumList._Album._AlbumName;
            this.AlbumPline=_AlbumList._Album._AlbumPline;
            this.AlbumRating=_AlbumList._Album._AlbumRating;
            this.AlbumReleaseDate=_AlbumList._Album._AlbumReleaseDate;
            this.ArtistId=_AlbumList._Album._ArtistId;
            this.ArtistName = _AlbumList._Album._ArtistName;
            this.Restricted = _AlbumList._Album._Restricted;
            this.UpdatedTime = _AlbumList._Album._UpdatedTime;
            this.MusicGenreList = new List<MusicGenre>();
        }
        public Album(_Album _Album)
        {
            this.AlbumCopyright = _Album._AlbumCopyright;
            this.AlbumId = _Album._AlbumId;
            this.AlbumLabel = _Album._AlbumLabel;
            this.AlbumMbid = _Album._AlbumMbid;
            this.AlbumName = _Album._AlbumName;
            this.AlbumPline = _Album._AlbumPline;
            this.AlbumRating = _Album._AlbumRating;
            this.AlbumReleaseDate = _Album._AlbumReleaseDate;
            this.ArtistId = _Album._ArtistId;
            this.ArtistName = _Album._ArtistName;
            this.Restricted = _Album._Restricted;
            this.UpdatedTime = _Album._UpdatedTime;
            this.MusicGenreList = new List<MusicGenre>();
        }

    }

    public class MusicGenre
    {
        public long MusicGenreId { get; set; }

        public long MusicGenreParentId { get; set; }

        public string MusicGenreName { get; set; }

        public string MusicGenreNameExtended { get; set; }

        public string MusicGenreVanity { get; set; }
        public MusicGenre() { }

        public MusicGenre(_MusicGenreList _MusicGenreList) 
        {
            this.MusicGenreId = _MusicGenreList._MusicGenre._MusicGenreId;
            this.MusicGenreName = _MusicGenreList._MusicGenre._MusicGenreName;
            this.MusicGenreNameExtended = _MusicGenreList._MusicGenre._MusicGenreNameExtended;
            this.MusicGenreParentId = _MusicGenreList._MusicGenre._MusicGenreParentId;
            this.MusicGenreVanity = _MusicGenreList._MusicGenre._MusicGenreVanity;
        }
    }



}
