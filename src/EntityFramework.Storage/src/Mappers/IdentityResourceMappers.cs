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
    /// Extension methods to map to/from entity/model for identity resources.
    /// </summary>
    public static class IdentityResourceMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.IdentityResource ToModel(this IdentityResource entity)
        {
            return entity == null
                ? null
                : new Models.IdentityResource()
                {
                    Enabled = entity.Enabled,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    Emphasize = entity.Emphasize,
                    Required = entity.Required,
                    ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                    Name = entity.Name,
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
        public static IdentityResource ToEntity(this Models.IdentityResource model)
        {
            return model == null
                ? null
                : new IdentityResource()
                {
                    Enabled = model.Enabled,
                    DisplayName = model.DisplayName,
                    Description = model.Description,
                    Emphasize = model.Emphasize,
                    Required = model.Required,
                    ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                    Name = model.Name,
                    NonEditable = false,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Properties = model.Properties is null
                        ? []
                        : model.Properties.Select(x => new IdentityResourceProperty
                        {
                            Key = x.Key,
                            Value = x.Value
                        }).ToList(),
                    UserClaims = model.UserClaims is null
                        ? []
                        : model.UserClaims.Select(x => new IdentityResourceClaim
                        {
                            Type = x
                        }).ToList()
                };
        }
    }
}