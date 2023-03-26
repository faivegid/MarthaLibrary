using AutoMapper;
using marthaLibrary.Repos.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Managers.Base
{
    internal abstract class BaseManager
    {
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseManager(
            ILogger logger, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
