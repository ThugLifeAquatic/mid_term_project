namespace OkayBooksAPITestingBranch
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class TheBooks
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("accessInfo")]
        public AccessInfo AccessInfo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }

        [JsonProperty("saleInfo")]
        public SaleInfo SaleInfo { get; set; }

        [JsonProperty("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
    }

    public partial class AccessInfo
    {
        [JsonProperty("epub")]
        public Epub Epub { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("accessViewStatus")]
        public string AccessViewStatus { get; set; }

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("publicDomain")]
        public bool PublicDomain { get; set; }

        [JsonProperty("textToSpeechPermission")]
        public string TextToSpeechPermission { get; set; }

        [JsonProperty("pdf")]
        public Pdf Pdf { get; set; }

        [JsonProperty("quoteSharingAllowed")]
        public bool QuoteSharingAllowed { get; set; }

        [JsonProperty("viewability")]
        public string Viewability { get; set; }

        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }
    }

    public partial class Epub
    {
        [JsonProperty("acsTokenLink")]
        public string AcsTokenLink { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }

    public partial class Pdf
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }

    public partial class SaleInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("listPrice")]
        public Price ListPrice { get; set; }

        [JsonProperty("buyLink")]
        public string BuyLink { get; set; }

        [JsonProperty("isEbook")]
        public bool IsEbook { get; set; }

        [JsonProperty("retailPrice")]
        public Price RetailPrice { get; set; }

        [JsonProperty("saleability")]
        public string Saleability { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }

    public partial class VolumeInfo
    {
        [JsonProperty("imageLinks")]
        public ImageLinks ImageLinks { get; set; }

        [JsonProperty("canonicalVolumeLink")]
        public string CanonicalVolumeLink { get; set; }

        [JsonProperty("authors")]
        public string[] Authors { get; set; }

        [JsonProperty("allowAnonLogging")]
        public bool AllowAnonLogging { get; set; }

        [JsonProperty("averageRating")]
        public long? AverageRating { get; set; }

        [JsonProperty("contentVersion")]
        public string ContentVersion { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maturityRating")]
        public string MaturityRating { get; set; }

        [JsonProperty("printType")]
        public string PrintType { get; set; }

        [JsonProperty("infoLink")]
        public string InfoLink { get; set; }

        [JsonProperty("industryIdentifiers")]
        public IndustryIdentifier[] IndustryIdentifiers { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("panelizationSummary")]
        public PanelizationSummary PanelizationSummary { get; set; }

        [JsonProperty("pageCount")]
        public long PageCount { get; set; }

        [JsonProperty("previewLink")]
        public string PreviewLink { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("readingModes")]
        public ReadingModes ReadingModes { get; set; }

        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }

        [JsonProperty("ratingsCount")]
        public long? RatingsCount { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class ImageLinks
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public partial class IndustryIdentifier
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PanelizationSummary
    {
        [JsonProperty("containsEpubBubbles")]
        public bool ContainsEpubBubbles { get; set; }

        [JsonProperty("containsImageBubbles")]
        public bool ContainsImageBubbles { get; set; }
    }

    public partial class ReadingModes
    {
        [JsonProperty("image")]
        public bool Image { get; set; }

        [JsonProperty("text")]
        public bool Text { get; set; }
    }

    public partial class TheBooks
    {
        public static TheBooks FromJson(string json) => JsonConvert.DeserializeObject<TheBooks>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TheBooks self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
