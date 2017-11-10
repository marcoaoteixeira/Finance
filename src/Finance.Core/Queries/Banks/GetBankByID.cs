using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Finance.Core.Entities;
using Finance.Core.Properties;
using Nameless.WinFormsApplication;
using Nameless.WinFormsApplication.CQRS.Queries;
using Nameless.WinFormsApplication.Data;
using Nameless.WinFormsApplication.ObjectMapper;

namespace Finance.Core.Queries.Banks {

    public sealed class GetBankByIDQuery : IQuery<Bank> {

        #region Public Properties

        public int ID { get; set; }

        #endregion Public Properties
    }

    public sealed class GetBankByIDQueryHandler : IQueryHandler<Bank, GetBankByIDQuery> {

        #region Private Read-Only Fields

        private readonly IDatabase _database;
        private readonly IMapper _mapper;

        #endregion Private Read-Only Fields

        #region Public Constructors

        public GetBankByIDQueryHandler(IDatabase database, IMapper mapper) {
            Prevent.ParameterNull(database, nameof(database));
            Prevent.ParameterNull(mapper, nameof(mapper));

            _database = database;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region IQueryHandler<Bank, GetBankByIDQuery> Members

        public Task<Bank> HandleAsync(GetBankByIDQuery query, CancellationToken token = default(CancellationToken)) => Task.Run(() => {
            return _database.ExecuteReaderSingle(Resources.SQL_GetBankByID, _mapper.Map<Bank>, parameters: new[] {
                Parameter.CreateInputParameter(nameof(Bank.ID), query.ID, DbType.Int32)
            });
        }, token);

        #endregion IQueryHandler<Bank, GetBankByIDQuery> Members
    }
}