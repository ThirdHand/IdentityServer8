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
    /// Extension methods to map to/from entity/model for scopes.
    /// </summary>
    public static class ScopeMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.ApiScope ToModel(this ApiScope entity)
        {
            return entity == null
                ? null
                : new Models.ApiScope
                {
                    Name = entity.Name,
                    Emphasize = entity.Emphasize,
                    Required = entity.Required,
                    Description = entity.Description,
                    DisplayName = entity.DisplayName,
                    Enabled = entity.Enabled,
                    ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
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
        public static ApiScope ToEntity(this Models.ApiScope model)
        {
            return model == null
                ? null
                : new ApiScope
                {
                    Name = model.Name,
                    Emphasize = model.Emphasize,
                    Required = model.Required,
                    Description = model.Description,
                    DisplayName = model.DisplayName,
                    Enabled = model.Enabled,
                    ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                    Properties = model.Properties is null
                        ? []
                        : model.Properties.Select(x => new ApiScopeProperty
                        {
                            Key = x.Key,
                            Value = x.Value,
                        }).ToList(),
                    UserClaims = model.UserClaims is null
                        ? []
                        : model.UserClaims.Select(x => new ApiScopeClaim
                        {
                            Type = x
                        }).ToList(),
                };
        }
    }
}