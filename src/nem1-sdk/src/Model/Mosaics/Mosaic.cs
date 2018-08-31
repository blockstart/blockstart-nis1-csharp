// ***********************************************************************
// Assembly         : nem1-sdk
// Author           : kailin
// Created          : 06-01-2018
//
// Last Modified By : kailin
// Last Modified On : 11-07-2018
// ***********************************************************************
// <copyright file="Mosaic.cs" company="Nem.io">   
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

namespace io.nem1.sdk.Model.Mosaics
{
    /// <summary>
    /// A mosaic describes an instance of a mosaic definition.
    /// Mosaics can be transferred by means of a transfer transaction.
    /// </summary>
    public class Mosaic
    {
        /// <summary>
        /// Gets the mosaic identifier.
        /// </summary>
        /// <value>The mosaic identifier.</value>
        public string MosaicName { get; }

        /// <summary>
        /// Gets the name of the namespace.
        /// </summary>
        /// <value>The name of the namespace.</value>
        public string NamespaceName { get; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public ulong Amount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mosaic"/> class.
        /// </summary>
        /// <param name="mosaicId">The identifier.</param>
        /// <param name="amount">The amount.</param>
        public Mosaic(string namespaceId, string mosaicId, ulong amount)
        {
            MosaicName = mosaicId ?? throw new ArgumentNullException(nameof(mosaicId));
            NamespaceName = namespaceId ?? throw new ArgumentNullException(nameof(namespaceId));
            Amount = amount;
        }

        /// <summary>
        /// Create a Mosaic from an identifier and an amount.
        /// </summary>
        /// <param name="identifier">The mosaic identifier. ex: nem:xem or test.namespace:token</param>
        /// <param name="amount">The mosaic amount.</param>
        /// <returns>A Mosaic instance</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public static Mosaic CreateFromIdentifier(string identifier, ulong amount)
        {
            if (string.IsNullOrEmpty(identifier)) throw new ArgumentException(identifier + " is not valid");
            if (!identifier.Contains(":")) throw new ArgumentException(identifier + " is not valid");
            var parts = identifier.Split(':');
            if (parts.Length != 2) throw new ArgumentException(identifier + " is not valid");
            if (parts[0] == "") throw new ArgumentException(identifier + " is not valid");
            
            if (parts[1] == "") throw new ArgumentException(identifier + " is not valid");
            
            return new Mosaic(parts[0], parts[1], amount);
        }
    }
}
