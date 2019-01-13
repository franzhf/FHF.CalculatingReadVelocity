using System;
using System.Collections.Generic;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Domain.ReadingActivity;

namespace TrackerActivity.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public override bool IsValid(Book entity)
        {
            return entity.ID != Guid.Empty && entity.ISBN != string.Empty;
        }
    }
}
