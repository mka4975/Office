using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class TagObject
    {
        public long TagId { get; set; }

        public DateTime Datetime { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public TagObject()
        {
        }

        public TagObject(int tagId, DateTime datetime, int x, int y)
        {
            TagId = tagId;
            Datetime = datetime;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(TagId)}: {TagId}, {nameof(Datetime)}: {Datetime}, {nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
