﻿using System.Linq;
using DotNetUtils;
using DotNetUtils.Annotations;
using Newtonsoft.Json;

namespace LicenseUtils
{
    /// <summary>
    ///     A copyrightable piece of software.
    /// </summary>
    [UsedImplicitly]
    public class Work
    {
        /// <summary>
        ///     The full title of the software program.
        /// </summary>
        /// <example>
        ///     <c>"MKVToolNix"</c>
        /// </example>
        [JsonProperty("name")]
        public string Name;

        /// <summary>
        ///     Brief summary of the software program's key features.
        /// </summary>
        [JsonProperty("description")]
        public string Description;

        /// <summary>
        ///     List of primary authors who contributed to this work.
        /// </summary>
        [JsonProperty("authors")]
        public Author[] Authors;

        /// <summary>
        ///     Set of URLs to the software's source code, homepage, article, and NuGet package.
        /// </summary>
        [JsonProperty("urls")]
        public Urls Urls;

        /// <summary>
        ///     <see cref="LicenseUtils.License.Id"/>.
        /// </summary>
        [JsonProperty("license_id")]
        public string LicenseId;

        /// <summary>
        ///     The license under which this work is released.
        /// </summary>
        [JsonIgnore]
        public License License;

        public override string ToString()
        {
            var authors = string.Join<Author>(", ", Authors);
            var license = License != null ? " under " + License.ToStringDescriptive() : "";
            return string.Format("{0}: © {1}{2}",
                                 Name, authors, license);
        }
    }
}
