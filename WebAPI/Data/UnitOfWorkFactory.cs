using Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        IUnitOfWork Begin();
    }

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConfig _config;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWorkFactory(IConfig config, ILogger<UnitOfWork> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_config, _logger);
        }

        public IUnitOfWork Begin()
        {
            var work = Create();
            work.Begin();
            return work;
        }
    }
}
