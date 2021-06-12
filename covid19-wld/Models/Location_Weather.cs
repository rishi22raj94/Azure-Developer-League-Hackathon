using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace covid19_wld.Model
{
    public class Location_Weather
    {
        public partial class Weather
        {
            [JsonProperty("request")]
            public Request Request { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("current")]
            public Current Current { get; set; }
        }

        public partial class Current
        {
            [JsonProperty("observation_time")]
            public string ObservationTime { get; set; }

            [JsonProperty("temperature")]
            public long Temperature { get; set; }

            [JsonProperty("weather_code")]
            public long WeatherCode { get; set; }

            [JsonProperty("weather_icons")]
            public Uri[] WeatherIcons { get; set; }

            [JsonProperty("weather_descriptions")]
            public string[] WeatherDescriptions { get; set; }

            [JsonProperty("wind_speed")]
            public long WindSpeed { get; set; }

            [JsonProperty("wind_degree")]
            public long WindDegree { get; set; }

            [JsonProperty("wind_dir")]
            public string WindDir { get; set; }

            [JsonProperty("pressure")]
            public long Pressure { get; set; }

            [JsonProperty("precip")]
            public long Precip { get; set; }

            [JsonProperty("humidity")]
            public long Humidity { get; set; }

            [JsonProperty("cloudcover")]
            public long Cloudcover { get; set; }

            [JsonProperty("feelslike")]
            public long Feelslike { get; set; }

            [JsonProperty("uv_index")]
            public long UvIndex { get; set; }

            [JsonProperty("visibility")]
            public long Visibility { get; set; }

            [JsonProperty("is_day")]
            public string IsDay { get; set; }
        }

        public partial class Location
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("lat")]
            public string Lat { get; set; }

            [JsonProperty("lon")]
            public string Lon { get; set; }

            [JsonProperty("timezone_id")]
            public string TimezoneId { get; set; }

            [JsonProperty("localtime")]
            public string Localtime { get; set; }

            [JsonProperty("localtime_epoch")]
            public long LocaltimeEpoch { get; set; }

            [JsonProperty("utc_offset")]
            public string UtcOffset { get; set; }
        }

        public partial class Request
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("unit")]
            public string Unit { get; set; }
        }

        public partial class ClientIPAddress
        {
            public string ip { get; set; }
            public string type { get; set; }
            public string continent_code { get; set; }
            public string continent_name { get; set; }
            public string country_code { get; set; }
            public string country_name { get; set; }
            public string region_code { get; set; }
            public string region_name { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public Location location { get; set; }
        }

        public partial class Location
        {
            public int geoname_id { get; set; }
            public string capital { get; set; }
            public Language[] languages { get; set; }
            public string country_flag { get; set; }
            public string country_flag_emoji { get; set; }
            public string country_flag_emoji_unicode { get; set; }
            public string calling_code { get; set; }
            public bool is_eu { get; set; }
        }

        public partial class Language
        {
            public string code { get; set; }
            public string name { get; set; }
            public string native { get; set; }
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

        public partial class ValidIPAddress
        {
            public string status { get; set; }
            public string country { get; set; }
            public string countryCode { get; set; }
            public string region { get; set; }
            public string regionName { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string timezone { get; set; }
            public string isp { get; set; }
            public string org { get; set; }
            public string _as { get; set; }
            public string query { get; set; }
        }



    }
}
