// Assembly         : nem1-sdk
// Author           : kailin
// Created          : 06-01-2018
//
// Last Modified By : kailin
// Last Modified On : 11-07-2018
// ***********************************************************************
// <copyright file="MultisigAccountInfo.cs" company="Nem.io">   
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

using System.Collections.Generic;

namespace io.nem1.sdk.Model.Accounts
{
    /// <summary>
    /// Class MultisigAccountInfo.
    /// </summary>
    public class MultisigAccountInfo
    {
        /// <summary>
        /// Returns multisig public account.
        /// </summary>
        /// <value>The account.</value>
        public PublicAccount Account { get; }

        /// <summary>
        /// Returns multisig account cosignatories.
        /// </summary>
        /// <value>The cosignatories.</value>
        public List<AccountInfo> Cosignatories { get; }
        /// <summary>
        /// Returns multisig accounts this account is cosigner of.
        /// </summary>
        /// <value>The multisig accounts.</value>
        public List<AccountInfo> CosginatoryOf { get; }
        /// <summary>
        /// Checks if an account is cosignatory of the multisig account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns><c>true</c> if the specified account has cosigners; otherwise, <c>false</c>.</returns>
        public bool HasCosigners(AccountInfo account) => Cosignatories.Contains(account);


        /// <summary>
        /// Initializes a new instance of the <see cref="MultisigAccountInfo"/> class.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="minApproval">The minimum approval.</param>
        /// <param name="minRemoval">The minimum removal.</param>
        /// <param name="cosignatories">The cosignatories.</param>
        /// <param name="multisigAccounts">The multisig accounts.</param>
        public MultisigAccountInfo(PublicAccount account, List<AccountInfo> cosignatories, List<AccountInfo> cosginatoryOf)
        {
            Account = account;
            Cosignatories = cosignatories;
            CosginatoryOf = cosginatoryOf;
        }
    }
}
