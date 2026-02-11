/*
 Copyright (c) 2024 HigginsSoft, Alexander Higgins - https://github.com/alexhiggins732/

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 Source code and license this software can be found

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
*/

using IdentityServer8.Models;

namespace IdentityServer8.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for persisted grants.
    /// </summary>
    public static class PersistedGrantMappers
    {
        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static PersistedGrant ToModel(this Entities.PersistedGrant entity)
        {
            return entity == null
                ? null
                : new PersistedGrant
                {
                    ClientId = entity.ClientId,
                    CreationTime = entity.CreationTime,
                    Description = entity.Description,
                    Key = entity.Key,
                    Type = entity.Type,
                    ConsumedTime = entity.ConsumedTime,
                    Data = entity.Data,
                    Expiration = entity.Expiration,
                    SessionId = entity.SessionId,
                    SubjectId = entity.SubjectId
                };
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.PersistedGrant ToEntity(this PersistedGrant model)
        {
            return model == null
                ? null
                : new Entities.PersistedGrant
                {
                    ClientId = model.ClientId,
                    CreationTime = model.CreationTime,
                    Description = model.Description,
                    Key = model.Key,
                    Type = model.Type,
                    ConsumedTime = model.ConsumedTime,
                    Data = model.Data,
                    Expiration = model.Expiration,
                    SessionId = model.SessionId,
                    SubjectId = model.SubjectId
                };
        }

        /// <summary>
        /// Updates an entity from a model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        public static void UpdateEntity(this PersistedGrant model, Entities.PersistedGrant entity)
        {
            entity.ClientId = model.ClientId;
            entity.CreationTime = model.CreationTime;
            entity.Description = model.Description;
            entity.Key = model.Key;
            entity.Type = model.Type;
            entity.ConsumedTime = model.ConsumedTime;
            entity.Data = model.Data;
            entity.Expiration = model.Expiration;
            entity.SessionId = model.SessionId;
            entity.SubjectId = model.SubjectId;
        }
    }
}