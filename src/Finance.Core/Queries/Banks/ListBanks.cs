using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Finance.Core.Entities;
using Finance.Core.Properties;
using Nameless.WinFormsApplication;
using Nameless.WinFormsApplication.CQRS.Queries;
using Nameless.WinFormsApplication.Data;
using Nameless.WinFormsApplication.ObjectMapper;

namespace Finance.Core.Queries.Banks {

    public sealed class ListBanksQuery : IQuery<IEnumerable<Bank>> {
    }

    public sealed class ListBanksQueryHandler : IQueryHandler<IEnumerable<Bank>, ListBanksQuery> {

        #region Private Read-Only Fields

        private readonly IDatabase _database;
        private readonly IMapper _mapper;

        #endregion Private Read-Only Fields

        #region Public Constructors

        public ListBanksQueryHandler(IDatabase database, IMapper mapper) {
            Prevent.ParameterNull(database, nameof(database));
            Prevent.ParameterNull(mapper, nameof(mapper));

            _database = database;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region IQueryHandler<Bank, ListBanksQuery> Members

        public Task<IEnumerable<Bank>> HandleAsync(ListBanksQuery query, CancellationToken token = default(CancellationToken)) => Task.Run(() => {
            return _database.ExecuteReader(Resources.SQL_ListBanks, _mapper.Map<Bank>);
        }, token);

        #endregion IQueryHandler<Bank, ListBanksQuery> Members
    }
}