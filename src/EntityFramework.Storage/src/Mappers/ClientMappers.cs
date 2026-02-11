/*
 Copyright (c) 2024 HigginsSoft, Alexander Higgins - https://github.com/alexhiggins732/

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 Source code and license this software can be found

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
*/

using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Models;
using ClientClaim = IdentityServer8.Models.ClientClaim;
using Secret = IdentityServer8.Models.Secret;

namespace IdentityServer8.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for clients.
    /// </summary>
    public static class ClientMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.Client ToModel(this Entities.Client entity)
        {
            return new Models.Client
            {
                ClientId = entity.ClientId,
                ClientName = entity.ClientName,
                ClientUri = entity.ClientUri,
                Description = entity.Description,
                Enabled = entity.Enabled,
                AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = entity.AccessTokenLifetime,
                AccessTokenType = (AccessTokenType) entity.AccessTokenType,
                AllowAccessTokensViaBrowser = entity.AllowAccessTokensViaBrowser,
                AllowOfflineAccess = entity.AllowOfflineAccess,
                AllowPlainTextPkce = entity.AllowPlainTextPkce,
                AllowRememberConsent = entity.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
                AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = entity.BackChannelLogoutUri,
                ClientClaimsPrefix = entity.ClientClaimsPrefix,
                ConsentLifetime = entity.ConsentLifetime,
                DeviceCodeLifetime = entity.DeviceCodeLifetime,
                FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
                EnableLocalLogin = entity.EnableLocalLogin,
                IdentityTokenLifetime = entity.IdentityTokenLifetime,
                IncludeJwtId = entity.IncludeJwtId,
                LogoUri = entity.LogoUri,
                PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
                ProtocolType = entity.ProtocolType,
                RefreshTokenExpiration = (TokenExpiration) entity.RefreshTokenExpiration,
                RefreshTokenUsage = (TokenUsage) entity.RefreshTokenUsage,
                SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
                RequireClientSecret = entity.RequireClientSecret,
                RequireConsent = entity.RequireConsent,
                RequirePkce = entity.RequirePkce,
                RequireRequestObject = entity.RequireRequestObject,
                UserSsoLifetime = entity.UserSsoLifetime,
                UserCodeType = entity.UserCodeType,
                RedirectUris = entity.RedirectUris is null
                    ? []
                    : entity.RedirectUris?.Select(x => x.RedirectUri).ToList(),
                PostLogoutRedirectUris = entity.PostLogoutRedirectUris is null
                    ? []
                    : entity.PostLogoutRedirectUris?.Select(x => x.PostLogoutRedirectUri).ToList(),
                Properties = entity.Properties is null
                    ? []
                    : entity.Properties?.ToDictionary(x => x.Key, x => x.Value),
                IdentityProviderRestrictions = entity.IdentityProviderRestrictions is null
                    ? []
                    : entity.IdentityProviderRestrictions?.Select(x => x.Provider).ToHashSet(),
                Claims = entity.Claims is null
                    ? []
                    : entity.Claims.Select(x => new ClientClaim
                    {
                        Type = x.Type,
                        Value = x.Value,
                        ValueType = ClaimValueTypes.String
                    }).ToHashSet(),
                ClientSecrets = entity.ClientSecrets is null
                    ? []
                    : entity.ClientSecrets.Select(x => new Secret
                    {
                        Type = x.Type,
                        Value = x.Value,
                        Description = x.Description,
                        Expiration = x.Expiration
                    }).ToHashSet(),
                AllowedScopes = entity.AllowedScopes?.Select(x => x.Scope).ToHashSet(),
                AllowedCorsOrigins = entity.AllowedCorsOrigins is null
                    ? []
                    : entity.AllowedCorsOrigins.Select(x => x.Origin).ToHashSet(),
                AllowedGrantTypes = entity.AllowedGrantTypes is null
                    ? []
                    : entity.AllowedGrantTypes.Select(x => x.GrantType).ToList(),
                AllowedIdentityTokenSigningAlgorithms =
                    string.IsNullOrWhiteSpace(entity.AllowedIdentityTokenSigningAlgorithms)
                        ? []
                        : entity.AllowedIdentityTokenSigningAlgorithms.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Distinct().ToHashSet()
            };
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.Client ToEntity(this Models.Client model)
        {
            return new Entities.Client
            {
                ClientId = model.ClientId,
                ClientName = model.ClientName,
                ClientUri = model.ClientUri,
                Description = model.Description,
                Enabled = model.Enabled,
                AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = model.AccessTokenLifetime,
                AccessTokenType = (int) model.AccessTokenType,
                AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                AllowOfflineAccess = model.AllowOfflineAccess,
                AllowPlainTextPkce = model.AllowPlainTextPkce,
                AllowRememberConsent = model.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = model.BackChannelLogoutUri,
                ClientClaimsPrefix = model.ClientClaimsPrefix,
                ConsentLifetime = model.ConsentLifetime,
                DeviceCodeLifetime = model.DeviceCodeLifetime,
                FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                EnableLocalLogin = model.EnableLocalLogin,
                IdentityTokenLifetime = model.IdentityTokenLifetime,
                IncludeJwtId = model.IncludeJwtId,
                LogoUri = model.LogoUri,
                PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                ProtocolType = model.ProtocolType,
                RefreshTokenExpiration = (int) model.RefreshTokenExpiration,
                RefreshTokenUsage = (int) model.RefreshTokenUsage,
                SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                RequireClientSecret = model.RequireClientSecret,
                RequireConsent = model.RequireConsent,
                RequirePkce = model.RequirePkce,
                RequireRequestObject = model.RequireRequestObject,
                UserSsoLifetime = model.UserSsoLifetime,
                UserCodeType = model.UserCodeType,

                RedirectUris = model.RedirectUris is null
                    ? []
                    : model.RedirectUris.Select(x => new ClientRedirectUri
                    {
                        RedirectUri = x
                    }).ToList(),
                PostLogoutRedirectUris = model.PostLogoutRedirectUris is null
                    ? []
                    : model.PostLogoutRedirectUris.Select(x => new ClientPostLogoutRedirectUri
                    {
                        PostLogoutRedirectUri = x
                    }).ToList(),
                Properties = model.Properties is null
                    ? []
                    : model.Properties.Select(x => new ClientProperty
                    {
                        Key = x.Key,
                        Value = x.Value
                    }).ToList(),
                IdentityProviderRestrictions = model.IdentityProviderRestrictions is null
                    ? []
                    : model.IdentityProviderRestrictions.Select(x => new ClientIdPRestriction
                    {
                        Provider = x
                    }).ToList(),
                Claims = model.Claims is null
                    ? []
                    : model.Claims.Select(x => new IdentityServer8.EntityFramework.Entities.ClientClaim
                    {
                        Type = x.Type,
                        Value = x.Value,
                    }).ToList(),
                ClientSecrets = model.ClientSecrets is null
                    ? []
                    : model.ClientSecrets.Select(x => new ClientSecret
                    {
                        Type = x.Type,
                        Value = x.Value,
                        Expiration = x.Expiration,
                        Description = x.Description
                    }).ToList(),
                AllowedScopes = model.AllowedScopes is null
                    ? []
                    : model.AllowedScopes.Select(x => new ClientScope
                    {
                        Scope = x
                    }).ToList(),
                AllowedCorsOrigins = model.AllowedCorsOrigins is null
                    ? []
                    : model.AllowedCorsOrigins.Select(x => new ClientCorsOrigin
                    {
                        Origin = x
                    }).ToList(),
                AllowedGrantTypes = model.AllowedGrantTypes is null
                    ? []
                    : model.AllowedGrantTypes.Select(x => new ClientGrantType
                    {
                        GrantType = x
                    }).ToList(),
                AllowedIdentityTokenSigningAlgorithms =
                    model.AllowedIdentityTokenSigningAlgorithms is null
                    || model.AllowedIdentityTokenSigningAlgorithms.Count == 0
                        ? string.Empty
                        : model.AllowedIdentityTokenSigningAlgorithms.Aggregate((x, y) => $"{x},{y}")
            };
        }
    }
}