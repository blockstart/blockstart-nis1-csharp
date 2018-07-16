// ***********************************************************************
// Assembly         : nem1-sdk
// Author           : kailin
// Created          : 06-01-2018
//
// Last Modified By : kailin
// Last Modified On : 11-07-2018
// ***********************************************************************
// <copyright file="MosaicId.cs" company="Nem.io">   
// Copyright 2018 NEM
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using io.nem1.sdk.Model.Namespace;

namespace io.nem1.sdk.Model.Mosaics
{
    /// <summary>
    /// A mosaicId describes an instance of a mosaic definition.
    /// Mosaics can be transferred by means of a transfer transaction.
    /// </summary>
    public class MosaicId
    {

        /// <summary>
        /// Gets the namespace identifier.
        /// </summary>
        /// <value>The namespace identifier.</value>
        public NamespaceId NamespaceId { get; }

        /// <summary>
        /// The mosaic name.
        /// </summary>
        /// <value>The name of the mosaic.</value>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; }

        /// <summary>
        /// Describes if the namespace name is present.
        /// </summary>
        /// <returns><c>true</c> if MosaicName is present, <c>false</c> otherwise.</returns>
        public bool IsNamePresent => Name != null;

        /// <summary>
        /// Describes if the full name is present.
        /// </summary>
        /// <returns><c>true</c> if FullName is present, <c>false</c> otherwise.</returns>
        public bool IsFullNamePresent => FullName != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicId"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public MosaicId(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) throw new ArgumentException(identifier + " is not valid");
            if (!identifier.Contains(":")) throw new ArgumentException(identifier + " is not valid");
            var parts = identifier.Split(':');
            if (parts.Length != 2) throw new ArgumentException(identifier + " is not valid");
            if (parts[0] == "") throw new ArgumentException(identifier + " is not valid");
            if (parts[1] == "") throw new ArgumentException(identifier + " is not valid");
            var namespaceName = parts[0];
            NamespaceId = new NamespaceId(namespaceName);
            Name = parts[1];
            FullName = identifier;
        }

        /// <summary>
        /// Create a Mosaic from an identifier and amount.
        /// </summary>
        /// <param name="identifier">The mosaic identifier. ex: nem:xem or test.namespace:token</param>
        /// <returns>A Mosaic instance</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public static MosaicId CreateFromMosaicIdentifier(string identifier)
        {
            return new MosaicId(identifier);
        } 
    }
}
