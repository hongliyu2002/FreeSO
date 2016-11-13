﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Server.Database.DA.Bookmarks
{
    public class SqlBookmarks : AbstractSqlDA, IBookmarks
    {
        public SqlBookmarks(ISqlContext context) : base(context)
        {
        }

        public void Create(DbBookmark bookmark)
        {
            Context.Connection.Execute("INSERT INTO fso_bookmarks (avatar_id, type, target_id) " +
                                        " VALUES (@avatar_id, @type, @target_id)"
                                        , bookmark);
        }

        public bool Delete(DbBookmark bookmark)
        {
            return Context.Connection.Execute("DELETE FROM fso_bookmarks WHERE avatar_id = @avatar_id AND type = @type AND target_id = @target_id", bookmark) > 0;
        }

        public List<DbBookmark> GetByAvatarId(uint avatar_id)
        {
            return Context.Connection.Query<DbBookmark>("SELECT * FROM fso_bookmarks WHERE avatar_id = @avatar_id", new { avatar_id = avatar_id }).ToList();
        }
    }
}
