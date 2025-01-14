﻿namespace Vinyld.Server.Models
{
    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var albumDetailsModel = AlbumDetailsModel.FromJson(jsonString);

    namespace QuickType
    {
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class AlbumDetailsModel
        {
            [JsonProperty("album")]
            public List<Dictionary<string, string>> Album { get; set; }
        }

        public partial class AlbumDetailsModel
        {
            public static AlbumDetailsModel FromJson(string json) => JsonConvert.DeserializeObject<AlbumDetailsModel>(json, QuickType.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this AlbumDetailsModel self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }

}
