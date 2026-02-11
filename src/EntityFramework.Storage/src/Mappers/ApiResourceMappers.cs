/*
 Copyright (c) 2024 HigginsSoft, Alexander Higgins - https://github.com/alexhiggins732/

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 Source code and license this software can be found

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
*/

using IdentityServer8.EntityFramework.Entities;

namespace IdentityServer8.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for API resources.
    /// </summary>
    public static class ApiResourceMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.ApiResource ToModel(this ApiResource entity)
        {
            return entity == null
                ? null
                : new Models.ApiResource
                {
                    Enabled = entity.Enabled,
                    Name = entity.Name,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                    AllowedAccessTokenSigningAlgorithms = [entity.AllowedAccessTokenSigningAlgorithms],
                    ApiSecrets = entity.Secrets is null
                        ? []
                        : entity.Secrets.Select(x => new IdentityServer8.Models.Secret
                        {
                            Type = x.Type,
                            Value = x.Value,
                            Description = x.Description
                        }).ToHashSet(),
                    Scopes = entity.Scopes is null
                        ? []
                        : entity.Scopes.Select(x => x.Scope).ToHashSet(),
                    Properties = entity.Properties is null
                        ? []
                        : entity.Properties.ToDictionary(x => x.Key, x => x.Value),
                    UserClaims = entity.UserClaims is null
                        ? []
                        : entity.UserClaims.Select(x => x.Type).ToHashSet(),
                };
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static ApiResource ToEntity(this Models.ApiResource model)
        {
            return model == null
                ? null
                : new ApiResource
                {
                    Enabled = model.Enabled,
                    Name = model.Name,
                    DisplayName = model.DisplayName,
                    Description = model.Description,
                    ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                    AllowedAccessTokenSigningAlgorithms = model.AllowedAccessTokenSigningAlgorithms.FirstOrDefault(),
                    Secrets = model.ApiSecrets is null
                        ? []
                        : model.ApiSecrets?.Select(x => new ApiResourceSecret
                        {
                            Type = x.Type,
                            Value = x.Value,
                            Expiration = x.Expiration,
                            Description = x.Description,
                        }).ToList(),
                    Scopes = model.Scopes is null
                        ? []
                        : model.Scopes.Select(x => new ApiResourceScope
                        {
                            Scope = x
                        }).ToList(),
                    Properties = model.Properties is null
                        ? []
                        : model.Properties.Select(x => new ApiResourceProperty
                        {
                            Key = x.Key,
                            Value = x.Value
                        }).ToList(),
                    UserClaims = model.UserClaims is null
                        ? []
                        : model.UserClaims.Select(x => new ApiResourceClaim
                        {
                            Type = x
                        }).ToList(),
                };
        }
    }
}