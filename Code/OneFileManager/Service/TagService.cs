using OneFileManager.DB;
using OneFileManager.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Service
{
    public class TagService
    {
        public List<TagEntity> GetTagsByPath(String path)
        {
            using (var db = new SQLLite3Context())
            {
                var tags = db.TagTable.Where(b => b.Path.Equals(path.ToLower()));
                if (tags == null || !tags.Any())
                {
                    return new List<TagEntity>();
                }
                return tags.ToList<TagEntity>();
            }
        }

        public List<TagEntity> GetTagsByTag(String tag)
        {
            using (var db = new SQLLite3Context())
            {
                var tags = db.TagTable.Where(b => b.Path.Equals(tag.ToLower()));
                if (tags == null || !tags.Any())
                {
                    return new List<TagEntity>();
                }
                return tags.ToList<TagEntity>();
            }
        }

        public bool IsExist(String tag, String path)
        {
            using (var db = new SQLLite3Context())
            {
                var tags = db.TagTable.Where(b => b.Tag.Equals(tag.ToLower()) && b.Path.Equals(path.ToLower()));
                if (tags == null || !tags.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public bool Add(String tag, String path)
        {
            if (IsExist(tag, path))
            {
                return false;
            }
            TagEntity tagEntity = new TagEntity(tag, path);
            using (var db = new SQLLite3Context())
            {
                db.TagTable.Add(tagEntity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Remove(String tag, String path)
        {
            using (var db = new SQLLite3Context())
            {
                db.TagTable.Where(b => b.Tag.Equals(tag.ToLower()) && b.Path.Equals(path.ToLower())).DeleteFromQuery();
                return db.SaveChanges() > 0;
            }
        }

        public bool RemoveByTag(String tag)
        {
            using (var db = new SQLLite3Context())
            {
                db.TagTable.Where(b => b.Tag.Equals(tag.ToLower())).DeleteFromQuery();
                return db.SaveChanges() > 0;
            }
        }

        public bool RemoveByPath(String path)
        {
            using (var db = new SQLLite3Context())
            {
                db.TagTable.Where(b => b.Path.Equals(path.ToLower())).DeleteFromQuery();
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdateTag(String path, string oldTag, string newTag)
        {
            if (!IsExist(path, oldTag))
            {
                return false;
            }

            using (var db = new SQLLite3Context())
            {
                var tagE = db.TagTable.Where(b => b.Tag.Equals(oldTag.ToLower()) && b.Path.Equals(path.ToLower())).FirstOrDefault();
                tagE.Tag = newTag.ToLower();
                tagE.OriginalTag = newTag;
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdatePath(String path, string oldTag, string newPath)
        {
            if (!IsExist(path, oldTag))
            {
                return false;
            }

            using (var db = new SQLLite3Context())
            {
                var tagE = db.TagTable.Where(b => b.Tag.Equals(oldTag.ToLower()) && b.Path.Equals(path.ToLower())).FirstOrDefault();
                tagE.Path = newPath.ToLower();
                tagE.OriginalPath = newPath;
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdateAllTag(string oldTag, string newTag)
        {
            using (var db = new SQLLite3Context())
            {
                db.TagTable.Where(b => b.Tag.Equals(oldTag.ToLower()))
                    .UpdateFromQuery(x => new TagEntity { Tag = newTag.ToLower(), OriginalTag = newTag });
                return db.SaveChanges() > 0;
            }
        }
    }
}