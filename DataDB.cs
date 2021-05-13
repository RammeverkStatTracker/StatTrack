namespace StatTrack
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Datadb
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("platformInfo")]
        public PlatformInfo PlatformInfo { get; set; }

        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("metadata")]
        public DataMetadata Metadata { get; set; }

        [JsonProperty("segments")]
        public Segment[] Segments { get; set; }

        [JsonProperty("availableSegments")]
        public AvailableSegment[] AvailableSegments { get; set; }

        [JsonProperty("expiryDate")]
        public DateTimeOffset ExpiryDate { get; set; }
    }

    public partial class AvailableSegment
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("attributes")]
        public MetadataClass Attributes { get; set; }

        [JsonProperty("metadata")]
        public MetadataClass Metadata { get; set; }
    }

    public partial class MetadataClass
    {
    }

    public partial class DataMetadata
    {
        [JsonProperty("currentSeason")]
        public long CurrentSeason { get; set; }

        [JsonProperty("activeLegend")]
        public string ActiveLegend { get; set; }

        [JsonProperty("activeLegendName")]
        public string ActiveLegendName { get; set; }

        [JsonProperty("activeLegendStats")]
        public object[] ActiveLegendStats { get; set; }
    }

    public partial class PlatformInfo
    {
        [JsonProperty("platformSlug")]
        public string PlatformSlug { get; set; }

        [JsonProperty("platformUserId")]
        public string PlatformUserId { get; set; }

        [JsonProperty("platformUserHandle")]
        public string PlatformUserHandle { get; set; }

        [JsonProperty("platformUserIdentifier")]
        public string PlatformUserIdentifier { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("additionalParameters")]
        public object AdditionalParameters { get; set; }
    }

    public partial class Segment
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("attributes")]
        public SegmentAttributes Attributes { get; set; }

        [JsonProperty("metadata")]
        public SegmentMetadata Metadata { get; set; }

        [JsonProperty("expiryDate")]
        public DateTimeOffset ExpiryDate { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }

    public partial class SegmentAttributes
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class SegmentMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }

        [JsonProperty("tallImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri TallImageUrl { get; set; }

        [JsonProperty("bgImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri BgImageUrl { get; set; }

        [JsonProperty("isActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActive { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Level { get; set; }

        [JsonProperty("kills", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Kills { get; set; }

        [JsonProperty("shotgunKills", NullValueHandling = NullValueHandling.Ignore)]
        public Kills ShotgunKills { get; set; }

        [JsonProperty("sniperKills", NullValueHandling = NullValueHandling.Ignore)]
        public Kills SniperKills { get; set; }

        [JsonProperty("rankScore", NullValueHandling = NullValueHandling.Ignore)]
        public RankScore RankScore { get; set; }

        [JsonProperty("season5Wins", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Season5Wins { get; set; }

        [JsonProperty("season5Kills", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Season5Kills { get; set; }

        [JsonProperty("season6Wins", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Season6Wins { get; set; }

        [JsonProperty("season6Kills", NullValueHandling = NullValueHandling.Ignore)]
        public Kills Season6Kills { get; set; }
    }

    public partial class Kills
    {
        [JsonProperty("rank")]
        public long? Rank { get; set; }

        [JsonProperty("percentile")]
        public double? Percentile { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("displayCategory")]
        public DisplayCategory DisplayCategory { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("metadata")]
        public MetadataClass Metadata { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("displayType")]
        public DisplayType DisplayType { get; set; }
    }

    public partial class RankScore
    {
        [JsonProperty("rank")]
        public object Rank { get; set; }

        [JsonProperty("percentile")]
        public object Percentile { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("displayCategory")]
        public DisplayCategory DisplayCategory { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("metadata")]
        public RankScoreMetadata Metadata { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("displayValue")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long DisplayValue { get; set; }

        [JsonProperty("displayType")]
        public DisplayType DisplayType { get; set; }
    }

    public partial class RankScoreMetadata
    {
        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("rankName")]
        public string RankName { get; set; }
    }

    public partial class UserInfo
    {
        [JsonProperty("userId")]
        public object UserId { get; set; }

        [JsonProperty("isPremium")]
        public bool IsPremium { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isInfluencer")]
        public bool IsInfluencer { get; set; }

        [JsonProperty("isPartner")]
        public bool IsPartner { get; set; }

        [JsonProperty("countryCode")]
        public object CountryCode { get; set; }

        [JsonProperty("customAvatarUrl")]
        public object CustomAvatarUrl { get; set; }

        [JsonProperty("customHeroUrl")]
        public object CustomHeroUrl { get; set; }

        [JsonProperty("socialAccounts")]
        public object[] SocialAccounts { get; set; }

        [JsonProperty("pageviews")]
        public long Pageviews { get; set; }

        [JsonProperty("isSuspicious")]
        public object IsSuspicious { get; set; }
    }

    public enum TypeEnum { Legend, Overview };

    public enum DisplayCategory { Combat, Game, Weapons };

    public enum DisplayType { Unspecified };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                DisplayCategoryConverter.Singleton,
                DisplayTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "legend":
                    return TypeEnum.Legend;
                case "overview":
                    return TypeEnum.Overview;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Legend:
                    serializer.Serialize(writer, "legend");
                    return;
                case TypeEnum.Overview:
                    serializer.Serialize(writer, "overview");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class DisplayCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DisplayCategory) || t == typeof(DisplayCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Combat":
                    return DisplayCategory.Combat;
                case "Game":
                    return DisplayCategory.Game;
                case "Weapons":
                    return DisplayCategory.Weapons;
            }
            throw new Exception("Cannot unmarshal type DisplayCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DisplayCategory)untypedValue;
            switch (value)
            {
                case DisplayCategory.Combat:
                    serializer.Serialize(writer, "Combat");
                    return;
                case DisplayCategory.Game:
                    serializer.Serialize(writer, "Game");
                    return;
                case DisplayCategory.Weapons:
                    serializer.Serialize(writer, "Weapons");
                    return;
            }
            throw new Exception("Cannot marshal type DisplayCategory");
        }

        public static readonly DisplayCategoryConverter Singleton = new DisplayCategoryConverter();
    }

    internal class DisplayTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DisplayType) || t == typeof(DisplayType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Unspecified")
            {
                return DisplayType.Unspecified;
            }
            throw new Exception("Cannot unmarshal type DisplayType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DisplayType)untypedValue;
            if (value == DisplayType.Unspecified)
            {
                serializer.Serialize(writer, "Unspecified");
                return;
            }
            throw new Exception("Cannot marshal type DisplayType");
        }

        public static readonly DisplayTypeConverter Singleton = new DisplayTypeConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
